using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models
{
    public class PersonName
    {
        public PersonName()
        {
            FamilyName = string.Empty;
            GivenName = string.Empty;
            Honorific = string.Empty;
        }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string Honorific { get; set; }

        public override string ToString()
        {
            return $"{FamilyName} {GivenName}{Honorific}";
        }

        public PersonName Clone()
        {
            return new PersonName
            {
                FamilyName = FamilyName,
                GivenName = GivenName,
                Honorific = Honorific
            };
        }
    }
}
