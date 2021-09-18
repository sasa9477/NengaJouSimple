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

        public PersonName(string familyName, string givenName, string honorific)
        {
            FamilyName = familyName;
            GivenName = givenName;
            Honorific = honorific;
        }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string Honorific { get; set; }

        public override string ToString()
        {
            var givenNameSpaceLength = string.IsNullOrEmpty(FamilyName) ? 0 : 1;

            var honorificNameSpaceLength = string.IsNullOrEmpty(Honorific) ? 0 : 1;

            return ToStringAppendingHeadSpaces(givenNameSpaceLength, honorificNameSpaceLength);
        }

        public string ToStringAppendingHeadSpaces(int givenNameSpaceLength, int honorificSpaceLength)
        {
            var givenNameSpace = givenNameSpaceLength == 0 ? string.Empty : new string(' ', givenNameSpaceLength);

            var honorificNameSpace = honorificSpaceLength == 0 ? string.Empty : new string(' ', honorificSpaceLength);

            return $"{FamilyName}{givenNameSpace}{GivenName}{honorificNameSpace}{Honorific}";
        }
    }
}
