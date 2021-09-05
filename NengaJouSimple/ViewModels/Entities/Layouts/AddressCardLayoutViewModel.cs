using NengaJouSimple.ViewModels.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class AddressCardLayoutViewModel
    {
        public AddressCardLayoutViewModel()
        {
            PostalCode = new TextLayoutViewModel();
            Address = new TextLayoutViewModel();
            Addressee = new TextLayoutViewModel();
            SenderPostalCode = new TextLayoutViewModel();
            SenderAddress = new TextLayoutViewModel();
            Sender = new TextLayoutViewModel();
            AddressCard = new AddressCardViewModel();
        }

        public int Id { get; set; }

        public TextLayoutViewModel PostalCode { get; set; }

        public TextLayoutViewModel Address { get; set; }

        public TextLayoutViewModel Addressee { get; set; }

        public TextLayoutViewModel SenderPostalCode { get; set; }

        public TextLayoutViewModel SenderAddress { get; set; }

        public TextLayoutViewModel Sender { get; set; }

        public AddressCardViewModel AddressCard { get; set; }

        public bool IsAlreadyPrinted { get; set; }

        public AddressCardLayoutViewModel Clone()
        {
            return new AddressCardLayoutViewModel
            {
                Id = Id,
                PostalCode = PostalCode.Clone(),
                Address = Address.Clone(),
                Addressee = Addressee.Clone(),
                SenderPostalCode = SenderPostalCode.Clone(),
                SenderAddress = SenderAddress.Clone(),
                Sender = Sender.Clone(),
                AddressCard = AddressCard.Clone(),
                IsAlreadyPrinted = IsAlreadyPrinted
            };
        }
    }
}
