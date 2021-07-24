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
            AddressNumber2 = addressNumber[4..8];
        }

        public string AddressNumber1 { get; set; }

        public string AddressNumber2 { get; set; }

        public bool IsCompleted
        {
            get { return AddressNumber1.Length == 3 && AddressNumber2.Length == 4; }
        }

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
