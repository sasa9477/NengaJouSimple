using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Jsons.Entities
{
    public class AddressCardLayoutJsonDTO
    {
        public string FontFamilyName { get; set; }

        public PostalCodeTextLayout PostalCode { get; set; }

        public TextLayout Address { get; set; }

        public TextLayout Addressee { get; set; }

        public PostalCodeTextLayout SenderPostalCode { get; set; }

        public TextLayout Sender { get; set; }

        public TextLayout SenderAddress { get; set; }

        public double PrintMarginLeft { get; set; }

        public double PrintMarginTop { get; set; }
    }
}
