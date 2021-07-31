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
using Prism.Regions;

namespace NengaJouSimple.ViewModels
{
    public class SenderAddressCardListViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private readonly SenderAddressCardService senderAddressCardService;

        private SenderAddressCardViewModel senderAddressCard;

        private SenderAddressCardViewModel selectedSenderAddressCard;

        private bool isSearchingByWebService = false;

        public SenderAddressCardListViewModel(
            IRegionManager regionManager,
            IDialogService dialogService,
            SenderAddressCardService senderAddressCardService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            this.senderAddressCardService = senderAddressCardService;

            senderAddressCard = new SenderAddressCardViewModel();
            selectedSenderAddressCard = new SenderAddressCardViewModel();

            var allSenderAddressCards = senderAddressCardService.LoadAll();
            SenderAddressCards = new ObservableCollection<SenderAddressCardViewModel>(allSenderAddressCards);

            ClearSelectedSenderAddressCommand = new DelegateCommand(ClearSelectedSenderAddress);
            SelectSenderAddressCardCommand = new DelegateCommand(SelectSenderAddressCard);
            SearchByPostalCodeCommand = new DelegateCommand<string>(SearchByPostalCode);
            RegisterSenderAddressCommand = new DelegateCommand(RegisterSenderAddress);
            DeleteSenderAddressCommand = new DelegateCommand(DeleteSenderAddress);
            EditAddressCardsCommand = new DelegateCommand(EditAddressCards);
        }

        public SenderAddressCardViewModel SenderAddressCard
        {
            get { return senderAddressCard; }
            set { SetProperty(ref senderAddressCard, value); }
        }

        public SenderAddressCardViewModel SelectedSenderAddressCard
        {
            get { return selectedSenderAddressCard; }
            set { SetProperty(ref selectedSenderAddressCard, value); }
        }

        public bool IsSearchingByWebService
        {
            get { return isSearchingByWebService; }
            set { SetProperty(ref isSearchingByWebService, value); }
        }

        public ObservableCollection<SenderAddressCardViewModel> SenderAddressCards { get; }

        public DelegateCommand ClearSelectedSenderAddressCommand { get; }

        public DelegateCommand SelectSenderAddressCardCommand { get; }

        public DelegateCommand<string> SearchByPostalCodeCommand { get; }

        public DelegateCommand RegisterSenderAddressCommand { get; }

        public DelegateCommand DeleteSenderAddressCommand { get; }

        public DelegateCommand EditAddressCardsCommand { get; }

        private void ClearSelectedSenderAddress()
        {
            SenderAddressCard.Clear();

            RaisePropertyChanged(nameof(SenderAddressCard));
        }

        private void SelectSenderAddressCard()
        {
            if (SelectedSenderAddressCard == null)
            {
                return;
            }

            SenderAddressCard = SelectedSenderAddressCard.Clone();
            SenderAddressCard.IsRegisterdCard = true;

            RaisePropertyChanged(nameof(SenderAddressCard));
        }

        private async void SearchByPostalCode(string postalCode)
        {
            if (postalCode.Length != 7)
            {
                var message = "郵便番号の形式が正しくありません。";

                dialogService.ShowInformationDialog(message);

                return;
            }

            IsSearchingByWebService = true;

            var response = await senderAddressCardService.SearchAddressByPostalCode(SenderAddressCard.PostalCode.ToString());

            if (string.IsNullOrEmpty(response))
            {
                dialogService.ShowInformationDialog("指定した郵便番号に一致する住所が見つかりませんでした。");
            }
            else
            {
                SenderAddressCard.Address.Address1 = response;

                RaisePropertyChanged(nameof(SenderAddressCard));
            }

            IsSearchingByWebService = false;
        }

        private void RegisterSenderAddress()
        {
            var validSenderAddressCard = ValidSenderAddressCard();

            if (!validSenderAddressCard.IsValid)
            {
                dialogService.ShowInformationDialog(validSenderAddressCard.ErrorMessage);

                return;
            }

            senderAddressCardService.Register(SenderAddressCard);

            ReplaceSenderAddressCards();

            ClearSelectedSenderAddress();
        }

        private void DeleteSenderAddress()
        {
            var buttonResult = dialogService.ShowConfirmDialog("この住所カードを削除しますか？");

            if (buttonResult == ButtonResult.Yes)
            {
                senderAddressCardService.Delete(SenderAddressCard);

                ReplaceSenderAddressCards();

                ClearSelectedSenderAddress();
            }
        }

        private void ReplaceSenderAddressCards()
        {
            SenderAddressCards.Clear();

            var senderAddressCards = senderAddressCardService.LoadAll();

            foreach (var senderAddressCard in senderAddressCards)
            {
                SenderAddressCards.Add(senderAddressCard);
            }
        }

        private (bool IsValid, string ErrorMessage) ValidSenderAddressCard()
        {
            var errorMessage = BuildValidationErrorMessage();

            return (IsValid: string.IsNullOrEmpty(errorMessage), ErrorMessage: errorMessage);
        }

        private string BuildValidationErrorMessage()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(SenderAddressCard.MainName.FamilyName) || string.IsNullOrWhiteSpace(SenderAddressCard.MainName.GivenName))
            {
                sb.AppendLine("氏名を入力してください。");
            }

            if (!SenderAddressCard.PostalCode.IsCompleted)
            {
                sb.AppendLine("郵便番号を入力してください。");
            }

            if (string.IsNullOrWhiteSpace(SenderAddressCard.Address.Address1))
            {
                sb.AppendLine("住所１を入力してください。");
            }

            if (string.IsNullOrWhiteSpace(SenderAddressCard.Address.Address2))
            {
                sb.AppendLine("住所２を入力してください。");
            }

            return sb.ToString();
        }

        private void EditAddressCards()
        {
            if (!senderAddressCardService.IsRegisterdAnySenderAddressCard())
            {
                dialogService.ShowInformationDialog("差出人を一人以上登録してください。");

                return;
            }

            regionManager.RequestNavigate(RegionNames.ContentRegion, "AddressCardListView");
        }
    }
}
