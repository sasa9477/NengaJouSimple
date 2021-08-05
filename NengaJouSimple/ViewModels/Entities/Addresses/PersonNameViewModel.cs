using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Addresses
{
    public class PersonNameViewModel
    {
        public PersonNameViewModel()
        {
            FamilyName = string.Empty;
            GivenName = string.Empty;
            Honorific = string.Empty;
        }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string Honorific { get; set; }

        public string FullName => ToString();

        public override string ToString()
        {
            var space = string.IsNullOrEmpty(FamilyName) ? "" : " ";

            return $"{FamilyName}{space}{GivenName}{Honorific}";
        }

        public string ToString(int spaceLength)
        {
            var space = new string(' ', spaceLength);

            return $"{FamilyName}{space}{GivenName}{Honorific}";
        }

        public PersonNameViewModel Clone()
        {
            return new PersonNameViewModel
            {
                FamilyName = FamilyName,
                GivenName = GivenName,
                Honorific = Honorific
            };
        }
    }
}
