using System;
using System.Collections.Generic;
using System.Text;
using NengaJouSimple.Models;

namespace NengaJouSimple.ViewModels.Entities.Addresses
{
    public class AddressCardViewModel : EntityBase
    {
        public AddressCardViewModel()
        {
            MainName = new PersonNameViewModel();
            MainNameKana = new PersonNameViewModel();
            PostalCode = new PostalCodeViewModel();
            Address = new AddressViewModel();
            Renmei1 = new PersonNameViewModel();
            Renmei2 = new PersonNameViewModel();
            Renmei3 = new PersonNameViewModel();
            Renmei4 = new PersonNameViewModel();
            Renmei5 = new PersonNameViewModel();
            SenderAddressCard = new SenderAddressCardViewModel();
            IsPrintTarget = true;
        }

        public PersonNameViewModel MainName { get; set; }

        public PersonNameViewModel MainNameKana { get; set; }

        public PostalCodeViewModel PostalCode { get; set; }

        public AddressViewModel Address { get; set; }

        public PersonNameViewModel Renmei1 { get; set; }

        public PersonNameViewModel Renmei2 { get; set; }

        public PersonNameViewModel Renmei3 { get; set; }

        public PersonNameViewModel Renmei4 { get; set; }

        public PersonNameViewModel Renmei5 { get; set; }

        public SenderAddressCardViewModel SenderAddressCard { get; set; }

        public bool IsRegisterdCard { get; set; }

        public bool IsPrintTarget { get; set; }

        public AddressCardViewModel Clone()
        {
            return new AddressCardViewModel
            {
                Id = Id,
                MainName = MainName.Clone(),
                MainNameKana = MainNameKana.Clone(),
                PostalCode = PostalCode.Clone(),
                Address = Address.Clone(),
                Renmei1 = Renmei1.Clone(),
                Renmei2 = Renmei2.Clone(),
                Renmei3 = Renmei3.Clone(),
                Renmei4 = Renmei4.Clone(),
                Renmei5 = Renmei5.Clone(),
                RegisterdDateTime = RegisterdDateTime,
                UpdatedDateTime = UpdatedDateTime,
                IsRegisterdCard = IsRegisterdCard,
                IsPrintTarget = IsPrintTarget
            };
        }

        public void Clear()
        {
            MainName = new PersonNameViewModel();
            MainNameKana = new PersonNameViewModel();
            PostalCode = new PostalCodeViewModel();
            Address = new AddressViewModel();
            Renmei1 = new PersonNameViewModel();
            Renmei2 = new PersonNameViewModel();
            Renmei3 = new PersonNameViewModel();
            Renmei4 = new PersonNameViewModel();
            Renmei5 = new PersonNameViewModel();
            SenderAddressCard = new SenderAddressCardViewModel();
            IsPrintTarget = true;
        }
    }
}
