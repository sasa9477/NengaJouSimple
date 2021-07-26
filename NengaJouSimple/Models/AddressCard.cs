using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models
{
    public class AddressCard : EntityBase
    {
        public AddressCard()
        {
            MainName = new PersonName();
            MainNameKana = new PersonName();
            AddressNumber = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            Address3 = string.Empty;
            Renmei1 = new PersonName();
            Renmei2 = new PersonName();
            Renmei3 = new PersonName();
            Renmei4 = new PersonName();
            Renmei5 = new PersonName();
            SenderAddressCard = new SenderAddressCard();
        }

        public PersonName MainName { get; set; }

        public PersonName MainNameKana { get; set; }

        public string AddressNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public PersonName Renmei1 { get; set; }

        public PersonName Renmei2 { get; set; }

        public PersonName Renmei3 { get; set; }

        public PersonName Renmei4 { get; set; }

        public PersonName Renmei5 { get; set; }

        public SenderAddressCard SenderAddressCard { get; set; }

        public bool IsPrintTarget { get; set; }
    }
}
