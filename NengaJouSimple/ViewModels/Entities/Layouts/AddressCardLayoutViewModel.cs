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
            FontFamily = new FontFamily();

            PostalCode = new PostalCodeTextLayoutViewModel();
            Address = new TextLayoutViewModel();
            Addressee = new TextLayoutViewModel();
            SenderPostalCode = new PostalCodeTextLayoutViewModel();
            Sender = new TextLayoutViewModel();
            SenderAddress = new TextLayoutViewModel();
        }

        public int Id { get; set; }

        public FontFamily FontFamily { get; set; }

        public PostalCodeTextLayoutViewModel PostalCode { get; set; }

        public TextLayoutViewModel Address { get; set; }

        public TextLayoutViewModel Addressee { get; set; }

        public PostalCodeTextLayoutViewModel SenderPostalCode { get; set; }

        public TextLayoutViewModel Sender { get; set; }

        public TextLayoutViewModel SenderAddress { get; set; }

        public double PrintMarginLeft { get; set; }

        public double PrintMarginTop { get; set; }

        public bool IsAlreadyPrinted { get; set; }

        public void AttachAddressCard(AddressCardViewModel addressCard)
        {
            PostalCode.MailWard = addressCard.PostalCode.MailWard;
            PostalCode.TownWard = addressCard.PostalCode.TownWard;
            Address.Text = addressCard.Address;
            Addressee.Text = BuildAddressee(addressCard);

            SenderPostalCode.MailWard = addressCard.PostalCode.MailWard;
            SenderPostalCode.TownWard = addressCard.PostalCode.TownWard;
            SenderAddress.Text = addressCard.SenderAddressCard.Address;
            Sender.Text = BuildSender(addressCard.SenderAddressCard);
            
            IsAlreadyPrinted = addressCard.IsAlreadyPrinted;
        }

        private string BuildAddressee(AddressCardViewModel addressCard)
        {
            var printRenmeis = addressCard.EnumerateRenmeis().Where(r => r.IsPrinting);

            var maxFamilyNameLengthInRenmeis = printRenmeis
                    .Select(r => r.FamilyName.Length)
                    .Aggregate((maxValue, length) => maxValue = Math.Max(maxValue, length));

            var maxFamilyNameLength = Math.Max(maxFamilyNameLengthInRenmeis, addressCard.MainName.FamilyName.Length);


            var sb = new StringBuilder();

            sb.AppendLine(addressCard.MainName.ToString(maxFamilyNameLength - addressCard.MainName.FamilyName.Length + 1));

            foreach (var renmei in printRenmeis)
            {
                sb.AppendLine(renmei.ToString(maxFamilyNameLength - renmei.FamilyName.Length + 1));
            }

            return sb.ToString();
        }

        private string BuildSender(SenderAddressCardViewModel senderAddressCard)
        {
            var printRenmeis = senderAddressCard.EnumerateRenmeis().Where(r => r.IsPrinting);

            var maxFamilyNameLengthInRenmeis = printRenmeis
                    .Select(r => r.FamilyName.Length)
                    .Aggregate((maxValue, length) => maxValue = Math.Max(maxValue, length));

            var maxFamilyNameLength = Math.Max(maxFamilyNameLengthInRenmeis, senderAddressCard.MainName.FamilyName.Length);


            var sb = new StringBuilder();

            sb.AppendLine(senderAddressCard.MainName.ToString(maxFamilyNameLength - senderAddressCard.MainName.FamilyName.Length + 1));

            foreach (var renmei in printRenmeis)
            {
                sb.AppendLine(renmei.ToString(maxFamilyNameLength - renmei.FamilyName.Length + 1));
            }

            return sb.ToString();
        }
    }
}
