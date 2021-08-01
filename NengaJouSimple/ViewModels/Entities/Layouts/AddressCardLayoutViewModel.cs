using NengaJouSimple.ViewModels.Entities.Addresses;
using System;
using System.Collections.Generic;
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
            var maxFamilyNameLength = addressCard.MainName.FamilyName.Length;

            if (addressCard.Renmei1.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(addressCard.Renmei1.FamilyName.Length, maxFamilyNameLength);
            }

            if (addressCard.Renmei2.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(addressCard.Renmei2.FamilyName.Length, maxFamilyNameLength);
            }

            if (addressCard.Renmei3.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(addressCard.Renmei3.FamilyName.Length, maxFamilyNameLength);
            }

            if (addressCard.Renmei4.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(addressCard.Renmei4.FamilyName.Length, maxFamilyNameLength);
            }

            if (addressCard.Renmei5.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(addressCard.Renmei5.FamilyName.Length, maxFamilyNameLength);
            }

            var sb = new StringBuilder();

            sb.AppendLine(addressCard.MainName.ToString(maxFamilyNameLength - addressCard.MainName.FamilyName.Length + 1));

            if (addressCard.Renmei1.IsPrinting)
            {
                sb.AppendLine(addressCard.Renmei1.ToString(maxFamilyNameLength - addressCard.Renmei1.FamilyName.Length + 1));
            }

            if (addressCard.Renmei2.IsPrinting)
            {
                sb.AppendLine(addressCard.Renmei2.ToString(maxFamilyNameLength - addressCard.Renmei2.FamilyName.Length + 1));
            }

            if (addressCard.Renmei3.IsPrinting)
            {
                sb.AppendLine(addressCard.Renmei3.ToString(maxFamilyNameLength - addressCard.Renmei3.FamilyName.Length + 1));
            }

            if (addressCard.Renmei4.IsPrinting)
            {
                sb.AppendLine(addressCard.Renmei4.ToString(maxFamilyNameLength - addressCard.Renmei4.FamilyName.Length + 1));
            }

            if (addressCard.Renmei5.IsPrinting)
            {
                sb.AppendLine(addressCard.Renmei5.ToString(maxFamilyNameLength - addressCard.Renmei5.FamilyName.Length + 1));
            }

            return sb.ToString();
        }

        private string BuildSender(SenderAddressCardViewModel senderAddressCard)
        {
            var maxFamilyNameLength = senderAddressCard.MainName.FamilyName.Length;

            if (senderAddressCard.Renmei1.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(senderAddressCard.Renmei1.FamilyName.Length, maxFamilyNameLength);
            }

            if (senderAddressCard.Renmei2.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(senderAddressCard.Renmei2.FamilyName.Length, maxFamilyNameLength);
            }

            if (senderAddressCard.Renmei3.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(senderAddressCard.Renmei3.FamilyName.Length, maxFamilyNameLength);
            }

            if (senderAddressCard.Renmei4.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(senderAddressCard.Renmei4.FamilyName.Length, maxFamilyNameLength);
            }

            if (senderAddressCard.Renmei5.IsPrinting)
            {
                maxFamilyNameLength = Math.Max(senderAddressCard.Renmei5.FamilyName.Length, maxFamilyNameLength);
            }

            var sb = new StringBuilder();

            sb.AppendLine(senderAddressCard.MainName.ToString(maxFamilyNameLength - senderAddressCard.MainName.FamilyName.Length + 1));

            if (senderAddressCard.Renmei1.IsPrinting)
            {
                sb.AppendLine(senderAddressCard.Renmei1.ToString(maxFamilyNameLength - senderAddressCard.Renmei1.FamilyName.Length + 1));
            }

            if (senderAddressCard.Renmei2.IsPrinting)
            {
                sb.AppendLine(senderAddressCard.Renmei2.ToString(maxFamilyNameLength - senderAddressCard.Renmei2.FamilyName.Length + 1));
            }

            if (senderAddressCard.Renmei3.IsPrinting)
            {
                sb.AppendLine(senderAddressCard.Renmei3.ToString(maxFamilyNameLength - senderAddressCard.Renmei3.FamilyName.Length + 1));
            }

            if (senderAddressCard.Renmei4.IsPrinting)
            {
                sb.AppendLine(senderAddressCard.Renmei4.ToString(maxFamilyNameLength - senderAddressCard.Renmei4.FamilyName.Length + 1));
            }

            if (senderAddressCard.Renmei5.IsPrinting)
            {
                sb.AppendLine(senderAddressCard.Renmei5.ToString(maxFamilyNameLength - senderAddressCard.Renmei5.FamilyName.Length + 1));
            }

            return sb.ToString();
        }
    }
}
