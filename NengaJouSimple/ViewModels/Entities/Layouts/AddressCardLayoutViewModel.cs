using NengaJouSimple.ViewModels.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class AddressCardLayoutViewModel
    {
        public AddressCardLayoutViewModel()
        {
            PostalCode = new PostalCodeTextLayoutViewModel();
            Address = new TextLayoutViewModel();
            Addressee = new TextLayoutViewModel();
            SenderPostalCode = new PostalCodeTextLayoutViewModel();
            Sender = new TextLayoutViewModel();
            SenderAddress = new TextLayoutViewModel();
        }

        public int Id { get; set; }

        public PostalCodeTextLayoutViewModel PostalCode { get; set; }

        public TextLayoutViewModel Address { get; set; }

        public TextLayoutViewModel Addressee { get; set; }

        public PostalCodeTextLayoutViewModel SenderPostalCode { get; set; }

        public TextLayoutViewModel Sender { get; set; }

        public TextLayoutViewModel SenderAddress { get; set; }

        public void AttachAddressCard(AddressCardViewModel addressCard)
        {
            PostalCode.MailWard = addressCard.PostalCode.MailWard;
            PostalCode.TownWard = addressCard.PostalCode.TownWard;
            Address.Text = addressCard.Address.ToString();
            Addressee.Text = addressCard.MainName.ToString();
            SenderPostalCode.MailWard = addressCard.PostalCode.MailWard;
            SenderPostalCode.TownWard = addressCard.PostalCode.TownWard;
            Sender.Text = addressCard.SenderAddressCard.MainName.ToString();
            SenderAddress.Text = addressCard.SenderAddressCard.Address.ToString();
        }
    }
}
