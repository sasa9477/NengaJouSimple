using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Addresses
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
            var spaceLength = string.IsNullOrEmpty(FamilyName) ? 0 : 1;

            return ToStringAppendingHeadSpaces(spaceLength);
        }

        public string ToStringAppendingHeadSpaces(int spaceLength)
        {
            var space = spaceLength == 0 ? string.Empty : new string(' ', spaceLength);

            return $"{FamilyName}{space}{GivenName}{Honorific}";
        }
    }
}
