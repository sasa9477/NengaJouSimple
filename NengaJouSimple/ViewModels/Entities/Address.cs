using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities
{
    public class Address
    {
        public Address()
        {
            Address1 = string.Empty;
            Address2 = string.Empty;
            Address3 = string.Empty;
        }

        public Address(string address1, string address2, string address3)
        {
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
        }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public override string ToString()
        {
            return $"{Address1}{Address2}{Address3}";
        }

        public Address Clone()
        {
            return new Address
            {
                Address1 = Address1,
                Address2 = Address2,
                Address3 = Address3
            };
        }
    }
}
