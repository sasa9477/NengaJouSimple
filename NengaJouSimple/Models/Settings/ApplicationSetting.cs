using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Settings
{
    public class ApplicationSetting
    {
        public ApplicationSetting()
        {
            FontFamilyName = "Yu Mincho";

            AvailableFontFamilies = new List<AvailableFontFamilyName>
            {
                new AvailableFontFamilyName
                {
                    Id = 0,
                    EnglishName = "Yu Mincho",
                    JapaneseName = "游明朝"
                },
                new AvailableFontFamilyName
                {
                    Id = 1,
                    EnglishName = "Yu Gothic UI",
                    JapaneseName = "游ゴシック"
                },
                new AvailableFontFamilyName
                {
                    Id = 2,
                    EnglishName = "UD Digi Kyokasho NK-R",
                    JapaneseName = "UD デジタル 教科書体 NK-R"
                },
                new AvailableFontFamilyName
                {
                    Id = 3,
                    EnglishName = "BIZ UDGothic",
                    JapaneseName = "BIZ UDゴシック"
                }
            };

            Honorifics = new List<string> { "", "様", "さん", "くん", "ちゃん" };

            DefaultHonorific = "様";

            PostalCodeSetting = new PostalCodeTextLayoutSetting
            {
                FontSizeDefaultValue = 20,
                PositionDefaultValue = new Position(165, 46),
                SpaceBetweenMailWardAndTownWardDefaultValue = 3,
                SpaceBetweenMailWardEachWardDefaultValue = 7.8,
                SpaceBetweenTownWardEachWardDefaultValue = 7.4
            };
            PostalCodeSetting.SpaceBetweenMailWardAndTownWard = PostalCodeSetting.SpaceBetweenMailWardAndTownWardDefaultValue;
            PostalCodeSetting.SpaceBetweenMailWardEachWard = PostalCodeSetting.SpaceBetweenMailWardEachWardDefaultValue;
            PostalCodeSetting.SpaceBetweenTownWardEachWard = PostalCodeSetting.SpaceBetweenTownWardEachWardDefaultValue;

            AddressSetting = new TextLayoutSetting
            {
                FontSizeDefaultValue = 20,
                PositionDefaultValue = new Position(300, 110)
            };

            AddresseeSetting = new TextLayoutSetting
            {
                FontSizeDefaultValue = 43,
                PositionDefaultValue = new Position(167, 110)
            };

            SenderPostalCodeSetting = new PostalCodeTextLayoutSetting
            {
                FontSizeDefaultValue = 14,
                PositionDefaultValue = new Position(23, 464),
                SpaceBetweenMailWardAndTownWardDefaultValue = 4.5,
                SpaceBetweenMailWardEachWardDefaultValue = 3.7,
                SpaceBetweenTownWardEachWardDefaultValue = 3.7
            };
            SenderPostalCodeSetting.SpaceBetweenMailWardAndTownWard = SenderPostalCodeSetting.SpaceBetweenMailWardAndTownWardDefaultValue;
            SenderPostalCodeSetting.SpaceBetweenMailWardEachWard = SenderPostalCodeSetting.SpaceBetweenMailWardEachWardDefaultValue;
            SenderPostalCodeSetting.SpaceBetweenTownWardEachWard = SenderPostalCodeSetting.SpaceBetweenTownWardEachWardDefaultValue;

            SenderAddressSetting = new TextLayoutSetting
            {
                FontSizeDefaultValue = 14,
                PositionDefaultValue = new Position(115, 220)
            };

            SenderSetting = new TextLayoutSetting
            {
                FontSizeDefaultValue = 24,
                PositionDefaultValue = new Position(55, 260)
            };
        }

        public double PrintingOffsetX { get; set; }

        public double PrintingOffsetY { get; set; }

        public string FontFamilyName { get; set; }

        public List<AvailableFontFamilyName> AvailableFontFamilies { get; }

        public List<string> Honorifics { get; }

        public string DefaultHonorific { get; set; }

        public PostalCodeTextLayoutSetting PostalCodeSetting { get; set; }

        public TextLayoutSetting AddressSetting { get; set; }

        public TextLayoutSetting AddresseeSetting { get; set; }

        public PostalCodeTextLayoutSetting SenderPostalCodeSetting { get; set; }

        public TextLayoutSetting SenderAddressSetting { get; set; }

        public TextLayoutSetting SenderSetting { get; set; }
    }
}
