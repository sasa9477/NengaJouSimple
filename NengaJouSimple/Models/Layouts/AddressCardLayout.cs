using AutoMapper;
using NengaJouSimple.Data.Csv.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Layouts
{
    public class AddressCardLayout : EntityBase
    {
        public AddressCardLayout()
        {
            PostalCode = new PostalCodeTextLayout
            {
                TextLayoutKind = TextLayoutKind.PostalCode,
                Font = new Font
                {
                    FontSize = 18,
                },
                Position = new Position(166, 45),
                SpaceBetweenMainWardAndTownWard = 2.2,
                SpaceBetweenEachWard = 4
            };

            Address = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.Address,
                Font = new Font
                {
                    FontSize = 20,
                },
                Position = new Position(300, 110),
            };

            Addressee = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.Addressee,
                Font = new Font
                {
                    FontSize = 43,
                },
                Position = new Position(167, 110),
            };

            SenderPostalCode = new PostalCodeTextLayout
            {
                TextLayoutKind = TextLayoutKind.SenderPostalCode,
                Font = new Font
                {
                    FontSize = 12,
                },
                Position = new Position(23, 464),
                SpaceBetweenMainWardAndTownWard = 4,
                SpaceBetweenEachWard = 1.5
            };

            SenderAddress = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.SenderAddress,
                Font = new Font
                {
                    FontSize = 14,
                },
                Position = new Position(115, 220),
            };

            Sender = new TextLayout
            {
                TextLayoutKind = TextLayoutKind.Sender,
                Font = new Font
                {
                    FontSize = 24,
                },
                Position = new Position(55, 260),
            };
        }

        public AddressCardLayout(IEnumerable<TextLayoutCsvDTO> textLayouts, IMapper mapper) : base()
        {
            foreach (var textLayout in textLayouts)
            {
                switch (textLayout.TextLayoutKind)
                {
                    case TextLayoutKind.PostalCode:
                        PostalCode = mapper.Map<PostalCodeTextLayout>(textLayout);
                        break;

                    case TextLayoutKind.Address:
                        Address = mapper.Map<TextLayout>(textLayout);
                        break;

                    case TextLayoutKind.Addressee:
                        Addressee = mapper.Map<TextLayout>(textLayout);
                        break;

                    case TextLayoutKind.SenderPostalCode:
                        SenderPostalCode = mapper.Map<PostalCodeTextLayout>(textLayout);
                        break;

                    case TextLayoutKind.SenderAddress:
                        SenderAddress = mapper.Map<TextLayout>(textLayout);
                        break;

                    case TextLayoutKind.Sender:
                        Sender = mapper.Map<TextLayout>(textLayout);
                        break;

                    default:
                        break;
                }
            }
        }

        public PostalCodeTextLayout PostalCode { get; set; }

        public TextLayout Address { get; set; }

        public TextLayout Addressee { get; set; }

        public PostalCodeTextLayout SenderPostalCode { get; set; }

        public TextLayout Sender { get; set; }

        public TextLayout SenderAddress { get; set; }


        public IEnumerable<TextLayoutCsvDTO> ConvertToCsvDTO(IMapper mapper)
        {
            yield return mapper.Map<TextLayoutCsvDTO>(PostalCode);
            yield return mapper.Map<TextLayoutCsvDTO>(Address);
            yield return mapper.Map<TextLayoutCsvDTO>(Addressee);
            yield return mapper.Map<TextLayoutCsvDTO>(SenderPostalCode);
            yield return mapper.Map<TextLayoutCsvDTO>(Sender);
            yield return mapper.Map<TextLayoutCsvDTO>(SenderAddress);
        }
    }
}
