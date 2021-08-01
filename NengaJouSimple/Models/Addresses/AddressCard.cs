using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Addresses
{
    public class AddressCard : EntityBase
    {
        public AddressCard()
        {
            MainName = new PersonName();
            MainNameKana = new PersonName();
            PostalCode = string.Empty;
            Address = string.Empty;
            Renmei1 = new PersonName();
            Renmei2 = new PersonName();
            Renmei3 = new PersonName();
            Renmei4 = new PersonName();
            Renmei5 = new PersonName();
            SenderAddressCard = new SenderAddressCard();
        }

        public PersonName MainName { get; set; }

        public PersonName MainNameKana { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public PersonName Renmei1 { get; set; }

        public PersonName Renmei2 { get; set; }

        public PersonName Renmei3 { get; set; }

        public PersonName Renmei4 { get; set; }

        public PersonName Renmei5 { get; set; }

        public SenderAddressCard SenderAddressCard { get; set; }

        public bool IsPrintTarget { get; set; }

        public bool IsAlreadyPrinted { get; set; }

        public DateTime? PrintedDateTime { get; set; }
    }
}
