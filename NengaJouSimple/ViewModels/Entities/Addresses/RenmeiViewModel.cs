using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Addresses
{
    public class RenmeiViewModel : PersonNameViewModel
    {
        public RenmeiViewModel() : base()
        {
        }

        public bool IsPrinting { get; set; }

        public new RenmeiViewModel Clone()
        {
            return new RenmeiViewModel
            {
                FamilyName = FamilyName,
                GivenName = GivenName,
                Honorific = Honorific,
                IsPrinting = IsPrinting
            };
        }
    }
}
