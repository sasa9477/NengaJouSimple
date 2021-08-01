using System;
using System.Collections.Generic;
using System.Text;
using NengaJouSimple.Models;

namespace NengaJouSimple.ViewModels.Entities.Addresses
{
    public class SenderAddressCardViewModel : EntityBase
    {
        public SenderAddressCardViewModel()
        {
            MainName = new PersonNameViewModel();
            MainNameKana = new PersonNameViewModel();
            PostalCode = new PostalCodeViewModel();
            Address = string.Empty;
            Renmei1 = new RenmeiViewModel();
            Renmei2 = new RenmeiViewModel();
            Renmei3 = new RenmeiViewModel();
            Renmei4 = new RenmeiViewModel();
            Renmei5 = new RenmeiViewModel();
        }

        public PersonNameViewModel MainName { get; set; }

        public PersonNameViewModel MainNameKana { get; set; }

        public PostalCodeViewModel PostalCode { get; set; }

        public string Address { get; set; }

        public RenmeiViewModel Renmei1 { get; set; }

        public RenmeiViewModel Renmei2 { get; set; }

        public RenmeiViewModel Renmei3 { get; set; }

        public RenmeiViewModel Renmei4 { get; set; }

        public RenmeiViewModel Renmei5 { get; set; }

        public bool IsRegisterdCard { get; set; }

        public SenderAddressCardViewModel Clone()
        {
            return new SenderAddressCardViewModel
            {
                Id = Id,
                MainName = MainName.Clone(),
                MainNameKana = MainNameKana.Clone(),
                PostalCode = PostalCode.Clone(),
                Address = Address,
                Renmei1 = Renmei1.Clone(),
                Renmei2 = Renmei2.Clone(),
                Renmei3 = Renmei3.Clone(),
                Renmei4 = Renmei4.Clone(),
                Renmei5 = Renmei5.Clone(),
                RegisterdDateTime = RegisterdDateTime,
                UpdatedDateTime = UpdatedDateTime,
                IsRegisterdCard = IsRegisterdCard
            };
        }

        public void Clear()
        {
            MainName = new PersonNameViewModel();
            MainNameKana = new PersonNameViewModel();
            PostalCode = new PostalCodeViewModel();
            Address = string.Empty;
            Renmei1 = new RenmeiViewModel();
            Renmei2 = new RenmeiViewModel();
            Renmei3 = new RenmeiViewModel();
            Renmei4 = new RenmeiViewModel();
            Renmei5 = new RenmeiViewModel();
        }
    }
}
