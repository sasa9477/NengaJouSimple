using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NengaJouSimple.ViewModels.Entities;
using NengaJouSimple.Services;
using NengaJouSimple.Extensions;
using Prism.Services.Dialogs;
using System.Linq;

namespace NengaJouSimple.ViewModels
{
    public class AddressCardListWindowViewModel : BindableBase
    {
        private readonly IDialogService dialogService;

        private readonly AddressCardService addressCardService;

        private AddressCard addressCard;

        private AddressCard selectedAddressCard;

        private int selectedSenderAddressCardId;

        private bool isSearchingByWebService;

        public AddressCardListWindowViewModel(
            IDialogService dialogService,
            AddressCardService addressCardService,
            SenderAddressCardService senderAddressCardService)
        {
            this.dialogService = dialogService;
            this.addressCardService = addressCardService;

            AddressCard = new AddressCard();

            SelectedAddressCard = new AddressCard();

            var allAddressCards = addressCardService.LoadAll();
            AddressCards = new ObservableCollection<AddressCard>(allAddressCards);

            Honorifics = Honorific.Items;

            AddressCard.MainName.Honorific = Honorific.DefalutHonorific;

            SenderAddressCards = senderAddressCardService.LoadAll().ToList();

            SelectedSenderAddressCardId = 1;

            ClearSelectedAddressCommand = new DelegateCommand(ClearSelectedAddress);
            SelectAddressCardCommand = new DelegateCommand(SelectAddressCard);
            SearchByAddressNumberCommand = new DelegateCommand<string>(SearchByAddressNumber);
            RegisterAddressCommand = new DelegateCommand(RegisterAddress);
            DeleteAddressCommand = new DelegateCommand(DeleteAddress);
        }

        public AddressCard AddressCard
        {
            get { return addressCard; }
            set { SetProperty(ref addressCard, value); }
        }

        public AddressCard SelectedAddressCard
        {
            get { return selectedAddressCard; }
            set { SetProperty(ref selectedAddressCard, value); }
        }

        public ObservableCollection<AddressCard> AddressCards { get; }

        public List<string> Honorifics { get; }

        public List<SenderAddressCard> SenderAddressCards { get; }

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

        public DelegateCommand<string> SearchByAddressNumberCommand { get; }

        public DelegateCommand RegisterAddressCommand { get; }

        public DelegateCommand DeleteAddressCommand { get; }

        private void ClearSelectedAddress()
        {
            AddressCard = new AddressCard();

            AddressCard.MainName.Honorific = Honorific.DefalutHonorific;

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

        private async void SearchByAddressNumber(string addressNumber)
        {
            if (addressNumber.Length != 7)
            {
                var message = "郵便番号の形式が正しくありません。";

                dialogService.ShowInformationDialog(message);

                return;
            }

            IsSearchingByWebService = true;

            var response = await addressCardService.SearchAddressByPostalCode(AddressCard.AddressNumber.ToString());

            if (string.IsNullOrEmpty(response))
            {
                var message = "指定した郵便番号に一致する住所が見つかりませんでした。";

                dialogService.ShowInformationDialog(message);
            }
            else
            {
                AddressCard.Address.Address1 = response;

                RaisePropertyChanged(nameof(AddressCard));
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

            if (!AddressCard.AddressNumber.IsCompleted)
            {
                sb.AppendLine("郵便番号を入力してください。");
            }

            if (string.IsNullOrWhiteSpace(AddressCard.Address.Address1))
            {
                sb.AppendLine("住所１を入力してください。");
            }

            if (string.IsNullOrWhiteSpace(AddressCard.Address.Address2))
            {
                sb.AppendLine("住所２を入力してください。");
            }

            return sb.ToString();
        }
    }
}
