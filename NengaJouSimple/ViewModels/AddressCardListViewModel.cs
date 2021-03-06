using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NengaJouSimple.ViewModels.Entities.Addresses;
using NengaJouSimple.Services;
using NengaJouSimple.Extensions;
using Prism.Services.Dialogs;
using System.Linq;
using Prism.Regions;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.ViewModels.Entities.Settings;
using Prism.Events;
using NengaJouSimple.ViewModels.PubSubEvents;

namespace NengaJouSimple.ViewModels
{
    public class AddressCardListViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private readonly IEventAggregator eventAggregator;

        private readonly AddressCardService addressCardService;

        private readonly ApplicationSettingViewModel applicationSetting;

        private AddressCardViewModel addressCard;

        private AddressCardViewModel selectedAddressCard;

        private int selectedSenderAddressCardId;

        private bool isSearchingByWebService;

        public AddressCardListViewModel(
            IRegionManager regionManager,
            IDialogService dialogService,
            IEventAggregator eventAggregator,
            ApplicationSettingService applicationSettingService,
            AddressCardService addressCardService,
            SenderAddressCardService senderAddressCardService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.addressCardService = addressCardService;

            applicationSetting = applicationSettingService.Load();

            AddressCard = new AddressCardViewModel();

            SelectedAddressCard = new AddressCardViewModel();

            var allAddressCards = addressCardService.LoadAll();

            AddressCards = new ObservableCollection<AddressCardViewModel>(allAddressCards);

            Honorifics = applicationSetting.Honorifics;

            AddressCard.MainName.Honorific = applicationSetting.DefaultHonorific;

            SenderAddressCards = senderAddressCardService.LoadAll();

            SelectedSenderAddressCardId = 1;

            ClearSelectedAddressCommand = new DelegateCommand(ClearSelectedAddress);
            SelectAddressCardCommand = new DelegateCommand(SelectAddressCard);
            SearchByPostalCodeCommand = new DelegateCommand<string>(SearchByPostalCode);
            RegisterAddressCommand = new DelegateCommand(RegisterAddress);
            DeleteAddressCommand = new DelegateCommand(DeleteAddress);
            ChangePrintTargetCommand = new DelegateCommand<AddressCardViewModel>(ChangePrintTarget);
            EditSenderAddressCardsCommand = new DelegateCommand(EditSenderAddressCards);
            PrintAddressCardsCommand = new DelegateCommand(PrintAddressCards);
        }

        public AddressCardViewModel AddressCard
        {
            get { return addressCard; }
            set { SetProperty(ref addressCard, value); }
        }

        public AddressCardViewModel SelectedAddressCard
        {
            get { return selectedAddressCard; }
            set { SetProperty(ref selectedAddressCard, value); }
        }

        public ObservableCollection<AddressCardViewModel> AddressCards { get; }

        public List<string> Honorifics { get; }

        public List<SenderAddressCardViewModel> SenderAddressCards { get; }

        public int SelectedSenderAddressCardId
        {
            get { return selectedSenderAddressCardId; }
            set { SetProperty(ref selectedSenderAddressCardId, value); }
        }

        public bool IsSearchingByWebService
        {
            get { return isSearchingByWebService; }
            set { SetProperty(ref isSearchingByWebService, value); }
        }

        public DelegateCommand ClearSelectedAddressCommand { get; }

        public DelegateCommand SelectAddressCardCommand { get; }

        public DelegateCommand<string> SearchByPostalCodeCommand { get; }

        public DelegateCommand RegisterAddressCommand { get; }

        public DelegateCommand DeleteAddressCommand { get; }

        public DelegateCommand<AddressCardViewModel> ChangePrintTargetCommand { get; }

        public DelegateCommand EditSenderAddressCardsCommand { get; }

        public DelegateCommand PrintAddressCardsCommand { get; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 他の画面からこの画面に遷移したときの処理
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // 画面のインスタンスを使いまわす
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // この画面から他の画面に遷移するときの処理
        }

        private void ClearSelectedAddress()
        {
            AddressCard.Clear();

            AddressCard.MainName.Honorific = applicationSetting.DefaultHonorific;

            RaisePropertyChanged(nameof(AddressCard));

            SelectedSenderAddressCardId = 1;
        }

        private void SelectAddressCard()
        {
            if (SelectedAddressCard == null)
            {
                return;
            }

            AddressCard = SelectedAddressCard.Clone();

            AddressCard.IsRegisterdCard = true;

            RaisePropertyChanged(nameof(AddressCard));

            SelectedSenderAddressCardId = SelectedAddressCard.SenderAddressCard.Id;
        }

        private async void SearchByPostalCode(string postalCode)
        {
            IsSearchingByWebService = true;

            var response = await addressCardService.SearchAddressByPostalCode(AddressCard.PostalCode.ToString());

            if (string.IsNullOrEmpty(response))
            {
                var message = "指定した郵便番号に一致する住所が見つかりませんでした。";

                dialogService.ShowInformationDialog(message);
            }
            else
            {
                AddressCard.Address1 = response;

                RaisePropertyChanged(nameof(AddressCard));

                eventAggregator.GetEvent<FocusAddress2Event>().Publish();
            }

            IsSearchingByWebService = false;
        }

        private void RegisterAddress()
        {
            var validAddressCard = ValidAddressCard();

            if (!validAddressCard.IsValid)
            {
                dialogService.ShowInformationDialog(validAddressCard.ErrorMessage);

                return;
            }

            AddressCard.SenderAddressCard = SenderAddressCards.FirstOrDefault(senderAddressCard => senderAddressCard.Id == SelectedSenderAddressCardId);

            addressCardService.Register(AddressCard);

            ReplaceAddressCards();

            ClearSelectedAddress();
        }

        private void DeleteAddress()
        {
            var message = "この住所カードを削除しますか？";

            var buttonResult = dialogService.ShowConfirmDialog(message);

            if (buttonResult == ButtonResult.Yes)
            {
                addressCardService.Delete(AddressCard);

                ReplaceAddressCards();

                ClearSelectedAddress();
            }
        }

        private void ChangePrintTarget(AddressCardViewModel addressCard)
        {
            addressCardService.Register(addressCard);
        }

        private void ReplaceAddressCards()
        {
            var addressCards = addressCardService.LoadAll();

            AddressCards.Clear();

            foreach (var addressCard in addressCards)
            {
                AddressCards.Add(addressCard);
            }
        }

        private (bool IsValid, string ErrorMessage) ValidAddressCard()
        {
            var errorMessage = BuildValidationErrorMessage();

            return (IsValid: string.IsNullOrEmpty(errorMessage), ErrorMessage: errorMessage);
        }

        private string BuildValidationErrorMessage()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(AddressCard.MainName.FamilyName) || string.IsNullOrWhiteSpace(AddressCard.MainName.GivenName))
            {
                sb.AppendLine("氏名を入力してください。");
            }

            if (string.IsNullOrEmpty(AddressCard.PostalCode))
            {
                sb.AppendLine("郵便番号を入力してください。");
            }

            if (string.IsNullOrWhiteSpace(AddressCard.Address1))
            {
                sb.AppendLine("住所を入力してください。");
            }

            return sb.ToString();
        }

        private void EditSenderAddressCards()
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "SenderAddressCardListView");
        }

        private void PrintAddressCards()
        {
            if (!addressCardService.IsRegisterdAnyAddressCard())
            {
                dialogService.ShowInformationDialog("宛先を一人以上登録してください。");

                return;
            }

            regionManager.RequestNavigate(RegionNames.ContentRegion, "PrintLayoutSettingView");
        }
    }
}
