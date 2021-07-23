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
    public class AddressCardListWindowViewModel : BindableBase
    {
        private readonly AddressCardService addressCardService;

        private AddressCard addressCard = new AddressCard();

        public AddressCardListWindowViewModel(AddressCardService addressCardService)
        {
            addressCardService = this.addressCardService;

            addressCard = new AddressCard();
            addressCard.MainName.Honorific = Honorific.FirstItem;

            addressCard.MainName.FamilyName = "日下";
            addressCard.MainName.GivenName = "智久";
        }

        public AddressCard AddressCard
        {
            get { return addressCard; }
            set { SetProperty(ref addressCard, value); }
        }

        public List<string> Honorifics { get; } = Honorific.Items;

        public ObservableCollection<AddressCard> AddressCards { get; } = new ObservableCollection<AddressCard>();

        public DelegateCommand<string> SearchByAddressNumberCommand => new DelegateCommand<string>(SearchByAddressNumber);

        public DelegateCommand RegisterAddressCommand => new DelegateCommand(RegisterAddress);

        private void SearchByAddressNumber(string addressNumber)
        {
            System.Diagnostics.Debug.WriteLine($"Search by address number!{addressNumber}");

            if (addressNumber.Length != 7)
            {
                return;
            }

            // TODO: HttpRequest through AddressSearch service.
            // If it will be failed, there are no action.

            AddressCard.Address.Address1 = $"[{addressNumber}]東京都江東区北砂";

            RaisePropertyChanged(nameof(AddressCard));
        }

        private void RegisterAddress()
        {
            AddressCards.Add(AddressCard);

            AddressCard = new AddressCard();

            RaisePropertyChanged(nameof(AddressCard));

            System.Diagnostics.Debug.WriteLine("登録しました。");
        }
    }
}
