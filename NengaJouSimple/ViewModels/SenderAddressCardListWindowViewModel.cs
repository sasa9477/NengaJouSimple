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

namespace NengaJouSimple.ViewModels
{
    public class SenderAddressCardListWindowViewModel : BindableBase
    {
        private readonly IDialogService dialogService;

        private readonly AddressCardService addressCardService;

        private AddressCard addressCard;

        private AddressCard selectedAddressCard;

        private bool isSearchingByWebService = false;

        public SenderAddressCardListWindowViewModel(
            IDialogService dialogService,
            AddressCardService addressCardService)
        {
            this.dialogService = dialogService;
            this.addressCardService = addressCardService;

            addressCard = new AddressCard();
            selectedAddressCard = new AddressCard();
            AddressCards = new ObservableCollection<AddressCard>();
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

        public bool IsSearchingByWebService
        {
            get { return isSearchingByWebService; }
            set { SetProperty(ref isSearchingByWebService, value); }
        }

        public ObservableCollection<AddressCard> AddressCards { get; }

        public DelegateCommand ClearSelectedAddressCommand { get; }

        public DelegateCommand SelectAddressCardCommand { get; }

        public DelegateCommand<string> SearchByAddressNumberCommand { get; }

        public DelegateCommand RegisterAddressCommand { get; }

        public DelegateCommand DeleteAddressCommand { get; }

        private void ClearSelectedAddress()
        {
            AddressCard = new AddressCard();

            RaisePropertyChanged(nameof(AddressCard));
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
        }

        private async void SearchByAddressNumber(string addressNumber)
        {
            if (addressNumber.Length != 7)
            {
                return;
            }

            IsSearchingByWebService = true;

            var response = await addressCardService.SearchAddressByPostalCode(AddressCard.AddressNumber.ToString());

            if (!string.IsNullOrEmpty(response))
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
