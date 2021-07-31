using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Addresses
{
    public class PostalCodeViewModel
    {
        public PostalCodeViewModel()
        {
            MailWard = string.Empty;
            TownWard = string.Empty;
        }

        public PostalCodeViewModel(string addressNumber) : this()
        {
            if (string.IsNullOrEmpty(addressNumber) || addressNumber.Length != 8) return;

            MailWard = addressNumber[0..3];
            TownWard = addressNumber[4..8];
        }

        public string MailWard { get; set; }

        public string TownWard { get; set; }

        public bool IsCompleted
        {
            get { return MailWard.Length == 3 && TownWard.Length == 4; }
        }

        public override string ToString()
        {
            return $"{MailWard}-{TownWard}";
        }

        public PostalCodeViewModel Clone()
        {
            return new PostalCodeViewModel
            {
                MailWard = MailWard,
                TownWard = TownWard
            };
        }
    }
}
