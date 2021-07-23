using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities
{
    public class AddressCard
    {
        public AddressCard()
        {
            MainName = new PersonName();
            MainNameKana = new PersonName();
            AddressNumber = new AddressNumber();
            Address = new Address();
            Renmei1 = new PersonName();
            Renmei2 = new PersonName();
            Renmei3 = new PersonName();
            Renmei4 = new PersonName();
            Renmei5 = new PersonName();
        }

        public int Id { get; set; }

        public PersonName MainName { get; set; }

        public PersonName MainNameKana { get; set; }

        public AddressNumber AddressNumber { get; set; }

        public Address Address { get; set; }

        public PersonName Renmei1 { get; set; }

        public PersonName Renmei2 { get; set; }

        public PersonName Renmei3 { get; set; }

        public PersonName Renmei4 { get; set; }

        public PersonName Renmei5 { get; set; }

        public bool IsRegisterdCard { get; set; }

        public AddressCard Clone()
        {
            return new AddressCard
            {
                Id = Id,
                MainName = MainName.Clone(),
                MainNameKana = MainNameKana.Clone(),
                AddressNumber = AddressNumber.Clone(),
                Address = Address.Clone(),
                Renmei1 = Renmei1.Clone(),
                Renmei2 = Renmei2.Clone(),
                Renmei3 = Renmei3.Clone(),
                Renmei4 = Renmei4.Clone(),
                Renmei5 = Renmei5.Clone(),
                IsRegisterdCard = IsRegisterdCard
            };
        }
    }
}
