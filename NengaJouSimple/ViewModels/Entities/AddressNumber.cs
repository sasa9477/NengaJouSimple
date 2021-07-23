using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities
{
    public class AddressNumber
    {
        public AddressNumber()
        {
            AddressNumber1 = string.Empty;
            AddressNumber2 = string.Empty;
        }

        public AddressNumber(string addressNumber) : this()
        {
            if (string.IsNullOrEmpty(addressNumber) || addressNumber.Length != 8) return;

            AddressNumber1 = addressNumber[0..3];
            AddressNumber2 = addressNumber[5..8];
        }

        public string AddressNumber1 { get; set; }

        public string AddressNumber2 { get; set; }

        public override string ToString()
        {
            return $"{AddressNumber1}-{AddressNumber2}";
        }

        public AddressNumber Clone()
        {
            return new AddressNumber
            {
                AddressNumber1 = AddressNumber1,
                AddressNumber2 = AddressNumber2
            };
        }
    }
}
