using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NengaJouSimple.ViewModels.Entities;
using NengaJouSimple.Services;

namespace NengaJouSimple.ViewModels
{
    public class SenderAddressCardListWindowViewModel : BindableBase
    {
        private readonly AddressCardService addressCardService;

        private AddressCard addressCard;

        private AddressCard selectedAddressCard;

        public SenderAddressCardListWindowViewModel(AddressCardService addressCardService)
        {
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

        public ObservableCollection<AddressCard> AddressCards { get; private set; }

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
            if (SelectedAddressCard == null) return;

            AddressCard = SelectedAddressCard.Clone();
            AddressCard.IsRegisterdCard = true;

            RaisePropertyChanged(nameof(AddressCard));
        }

        private void SearchByAddressNumber(string addressNumber)
        {
            if (addressNumber.Length != 7)
            {
                return;
            }

            // TODO: HttpRequest through AddressSearch service.
            // If it will be failed, there are no action.

            AddressCard.Address.Address1 = $"東京都江東区北砂";

            RaisePropertyChanged(nameof(AddressCard));
        }

        private void RegisterAddress()
        {
            addressCardService.Register(AddressCard);

            var addressCards = addressCardService.LoadAll();

            ReplaceAddressCards(addressCards);

            ClearSelectedAddress();

            System.Diagnostics.Debug.WriteLine("登録しました。");
        }

        private void DeleteAddress()
        {
            System.Diagnostics.Debug.WriteLine("削除しました。");
        }

        private void ReplaceAddressCards(ICollection<AddressCard> addressCards)
        {
            AddressCards.Clear();

            foreach(var addressCard in addressCards)
            {
                AddressCards.Add(addressCard);
            }
        }
    }
}
