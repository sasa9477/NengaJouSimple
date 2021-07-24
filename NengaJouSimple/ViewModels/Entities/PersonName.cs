using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities
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
            var space = string.IsNullOrEmpty(FamilyName) ? "" : " ";

            return $"{FamilyName}{space}{GivenName}{Honorific}";
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
