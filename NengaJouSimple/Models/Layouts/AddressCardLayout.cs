using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Models.Layouts
{
    public class AddressCardLayout : EntityBase
    {
        private static readonly PersonName FamiliesText = new PersonName(string.Empty, "ご家族", "様");

        public AddressCardLayout()
        {
        }

        public TextLayout PostalCode { get; set; }

        public TextLayout Address { get; set; }

        public TextLayout Addressee { get; set; }

        public TextLayout SenderPostalCode { get; set; }

        public TextLayout SenderAddress { get; set; }

        public TextLayout Sender { get; set; }

        public virtual AddressCard AddressCard { get; set; }

        public void Attach(
            ApplicationSetting applicationSetting,
            IEnumerable<TextLayout> textLayouts,
            AddressCard addressCard)
        {
            PostalCode = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.PostalCode,
                FontSize = applicationSetting.PostalCodeSetting.FontSizeDefaultValue,
                Position = applicationSetting.PostalCodeSetting.PositionDefaultValue
            };

            Address = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.Address,
                FontSize = applicationSetting.AddressSetting.FontSizeDefaultValue,
                Position = applicationSetting.AddressSetting.PositionDefaultValue
            };

            Addressee = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.Addressee,
                FontSize = applicationSetting.AddresseeSetting.FontSizeDefaultValue,
                Position = applicationSetting.AddresseeSetting.PositionDefaultValue
            };

            SenderPostalCode = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.SenderPostalCode,
                FontSize = applicationSetting.SenderPostalCodeSetting.FontSizeDefaultValue,
                Position = applicationSetting.SenderPostalCodeSetting.PositionDefaultValue
            };

            SenderAddress = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.SenderAddress,
                FontSize = applicationSetting.SenderAddressSetting.FontSizeDefaultValue,
                Position = applicationSetting.SenderAddressSetting.PositionDefaultValue
            };

            Sender = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.Sender,
                FontSize = applicationSetting.SenderSetting.FontSizeDefaultValue,
                Position = applicationSetting.SenderSetting.PositionDefaultValue
            };

            if (textLayouts != null)
            {
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
            }

            PostalCode.Text = addressCard.PostalCode;
            Address.Text = $"{addressCard.Address1}　\n{addressCard.Address2}";
            Addressee.Text = BuildAddressee(addressCard);
            SenderPostalCode.Text = addressCard.SenderAddressCard.PostalCode;
            SenderAddress.Text = $"{addressCard.SenderAddressCard.Address1}　\n{addressCard.SenderAddressCard.Address2}";
            Sender.Text = BuildSender(addressCard.SenderAddressCard);

            if (Addressee.Text.Replace("\r\n", "\n").Split("\n").Length > 1)
            {
                Addressee.FontSize = applicationSetting.MultiAddresseeSetting.FontSizeDefaultValue;
                Addressee.Position = applicationSetting.MultiAddresseeSetting.PositionDefaultValue;
            }

            AddressCard = addressCard;
        }

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
            var sb = new StringBuilder();

            if (addressCard.IsFamilyPrinting)
            {
                var maxGivenNameLength = addressCard.MainName.GivenName.Length >= FamiliesText.GivenName.Length ? addressCard.MainName.GivenName.Length : FamiliesText.GivenName.Length;

                var mainNameText = addressCard.MainName.ToStringAppendingHeadSpaces(
                    1,
                    maxGivenNameLength - addressCard.MainName.GivenName.Length);

                sb.AppendLine(mainNameText);

                var familyNameText = FamiliesText.ToStringAppendingHeadSpaces(
                    addressCard.MainName.FamilyName.Length + 1,
                    maxGivenNameLength - FamiliesText.GivenName.Length);

                sb.Append(familyNameText);
            }
            else
            {
                var printingRenmeis = addressCard.EnumerateRenmeis().Where(r => r.IsPrinting);

                var maxFamilyNameLength = addressCard.MaxFamilyNameLength;

                var maxGivenNameLength = addressCard.MaxGivenNameLength;

                var mainNameText = addressCard.MainName.ToStringAppendingHeadSpaces(
                    maxFamilyNameLength - addressCard.MainName.FamilyName.Length + 1,
                    maxGivenNameLength - addressCard.MainName.GivenName.Length);

                sb.Append(mainNameText);

                foreach (var renmei in printingRenmeis)
                {
                    sb.AppendLine();

                    var renmeiText = renmei.ToStringAppendingHeadSpaces(
                        maxFamilyNameLength - renmei.FamilyName.Length + 1,
                        maxGivenNameLength - renmei.GivenName.Length);

                    sb.Append(renmeiText);
                }
            }

            return sb.ToString();
        }

        private string BuildSender(SenderAddressCard senderAddressCard)
        {
            var sb = new StringBuilder();

            var maxFamilyNameLength = senderAddressCard.MaxFamilyNameLength;

            var maxGivenNameLength = senderAddressCard.MaxGivenNameLength;

            var mainNameText = senderAddressCard.MainName.ToStringAppendingHeadSpaces(maxFamilyNameLength - senderAddressCard.MainName.FamilyName.Length + 1);

            sb.Append(mainNameText);

            var printingRenmeis = senderAddressCard.EnumerateRenmeis().Where(r => r.IsPrinting);

            foreach (var renmei in printingRenmeis)
            {
                sb.AppendLine();

                var renmeiText = renmei.ToStringAppendingHeadSpaces(maxFamilyNameLength - renmei.FamilyName.Length + 1);

                sb.Append(renmeiText);
            }

            return sb.ToString();
        }
    }
}
