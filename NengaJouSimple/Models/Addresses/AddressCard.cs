using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Models.Addresses
{
    public class AddressCard : EntityBase
    {
        public AddressCard()
        {
            MainName = new PersonName();
            MainNameKana = new PersonName();
            PostalCode = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            Renmei1 = new Renmei();
            Renmei2 = new Renmei();
            Renmei3 = new Renmei();
            Renmei4 = new Renmei();
            Renmei5 = new Renmei();
            SenderAddressCard = new SenderAddressCard();
            IsFamilyPrinting = false;
        }

        public PersonName MainName { get; set; }

        public PersonName MainNameKana { get; set; }

        public string PostalCode { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public Renmei Renmei1 { get; set; }

        public Renmei Renmei2 { get; set; }

        public Renmei Renmei3 { get; set; }

        public Renmei Renmei4 { get; set; }

        public Renmei Renmei5 { get; set; }

        public SenderAddressCard SenderAddressCard { get; set; }

        public bool IsPrintTarget { get; set; }

        public DateTime? PrintedDateTime { get; set; }

        public bool IsFamilyPrinting { get; set; }

        public int MaxFamilyNameLength
        {
            get
            {
                var renmeis = EnumerateRenmeis();

                if (renmeis.Any())
                {
                    var renmeiFamilyNameLength = renmeis.Select(r => r.FamilyName.Length).Max();

                    return Math.Max(renmeiFamilyNameLength, MainName.FamilyName.Length);
                }

                return MainName.FamilyName.Length;
            }
        }

        public int MaxGivenNameLength
        {
            get
            {
                var renmeis = EnumerateRenmeis();

                if (renmeis.Any())
                {
                    var renmeiGivenNameLength = renmeis.Select(r => r.GivenName.Length).Max();

                    return Math.Max(renmeiGivenNameLength, MainName.GivenName.Length);
                }

                return MainName.GivenName.Length;
            }
        }

        public IEnumerable<Renmei> EnumerateRenmeis()
        {
            yield return Renmei1;
            yield return Renmei2;
            yield return Renmei3;
            yield return Renmei4;
            yield return Renmei5;
        }
    }
}
