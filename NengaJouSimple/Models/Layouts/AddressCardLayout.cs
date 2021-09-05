using AutoMapper;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Models.Layouts
{
    public class AddressCardLayout
    {
        public AddressCardLayout()
        {
        }

        public AddressCardLayout(
            ApplicationSetting applicationSetting,
            IEnumerable<TextLayout> textLayouts,
            AddressCard addressCard)
        {
            PostalCode = new TextLayout
            {
                FontSize = applicationSetting.PostalCodeSetting.FontSizeDefaultValue,
                Position = applicationSetting.PostalCodeSetting.PositionDefaultValue
            };

            Address = new TextLayout
            {
                FontSize = applicationSetting.AddressSetting.FontSizeDefaultValue,
                Position = applicationSetting.AddressSetting.PositionDefaultValue
            };

            Addressee = new TextLayout
            {
                FontSize = applicationSetting.AddresseeSetting.FontSizeDefaultValue,
                Position = applicationSetting.AddresseeSetting.PositionDefaultValue
            };

            SenderPostalCode = new TextLayout
            {
                FontSize = applicationSetting.SenderPostalCodeSetting.FontSizeDefaultValue,
                Position = applicationSetting.SenderPostalCodeSetting.PositionDefaultValue
            };

            SenderAddress = new TextLayout
            {
                FontSize = applicationSetting.SenderAddressSetting.FontSizeDefaultValue,
                Position = applicationSetting.SenderAddressSetting.PositionDefaultValue
            };

            Sender = new TextLayout
            {
                FontSize = applicationSetting.SenderSetting.FontSizeDefaultValue,
                Position = applicationSetting.SenderSetting.PositionDefaultValue
            };

            foreach (var textLayout in textLayouts)
            {
                switch (textLayout.TextLayoutKind)
                {
                    case TextLayoutKind.PostalCode:
                        PostalCode = textLayout;
                        break;

                    case TextLayoutKind.Address:
                        Address = textLayout;
                        break;

                    case TextLayoutKind.Addressee:
                        Addressee = textLayout;
                        break;

                    case TextLayoutKind.SenderPostalCode:
                        SenderPostalCode = textLayout;
                        break;

                    case TextLayoutKind.SenderAddress:
                        SenderAddress = textLayout;
                        break;

                    case TextLayoutKind.Sender:
                        Sender = textLayout;
                        break;
                }
            }

            PostalCode.Text = addressCard.PostalCode;
            Address.Text = $"{addressCard.Address1}\n　{addressCard.Address2}";
            Addressee.Text = BuildAddressee(addressCard);
            SenderPostalCode.Text = addressCard.SenderAddressCard.PostalCode;
            SenderAddress.Text = $"{addressCard.SenderAddressCard.Address1}\n　{addressCard.SenderAddressCard.Address2}";
            Sender.Text = BuildSender(addressCard.SenderAddressCard);

            AddressCard = addressCard;
        }

        public TextLayout PostalCode { get; set; }

        public TextLayout Address { get; set; }

        public TextLayout Addressee { get; set; }

        public TextLayout SenderPostalCode { get; set; }

        public TextLayout SenderAddress { get; set; }

        public TextLayout Sender { get; set; }

        public AddressCard AddressCard { get; set; }

        public IEnumerable<TextLayout> GetTextLayoutProperties()
        {
            yield return PostalCode;
            yield return Address;
            yield return Addressee;
            yield return SenderPostalCode;
            yield return SenderAddress;
            yield return Sender;
        }

        private string BuildAddressee(AddressCard addressCard)
        {
            var printingRenmeis = addressCard.EnumerateRenmeis().Where(r => r.IsPrinting);

            var renmeiFamilyNameLength = CalculateFamilyNameLength(printingRenmeis);

            var maxFamilyNameLength = Math.Max(renmeiFamilyNameLength, addressCard.MainName.FamilyName.Length);

            var sb = new StringBuilder();

            sb.AppendLine(addressCard.MainName.ToStringAppendingHeadSpaces(maxFamilyNameLength - addressCard.MainName.FamilyName.Length + 1));

            foreach (var renmei in printingRenmeis)
            {
                sb.AppendLine(renmei.ToStringAppendingHeadSpaces(maxFamilyNameLength - renmei.FamilyName.Length + 1));
            }

            return sb.ToString();
        }

        private string BuildSender(SenderAddressCard senderAddressCard)
        {
            var printingRenmeis = senderAddressCard.EnumerateRenmeis().Where(r => r.IsPrinting);

            var renmeiFamilyNameLength = CalculateFamilyNameLength(printingRenmeis);

            var maxFamilyNameLength = Math.Max(renmeiFamilyNameLength, senderAddressCard.MainName.FamilyName.Length);

            var sb = new StringBuilder();

            sb.AppendLine(senderAddressCard.MainName.ToStringAppendingHeadSpaces(maxFamilyNameLength - senderAddressCard.MainName.FamilyName.Length + 1));

            foreach (var renmei in printingRenmeis)
            {
                sb.AppendLine(renmei.ToStringAppendingHeadSpaces(maxFamilyNameLength - renmei.FamilyName.Length + 1));
            }

            return sb.ToString();
        }

        private int CalculateFamilyNameLength(IEnumerable<Renmei> renmeis)
        {
            if (renmeis.Any())
            {
                return renmeis.Select(r => r.FamilyName.Length).Max();
            }

            return 0;
        }
    }
}
