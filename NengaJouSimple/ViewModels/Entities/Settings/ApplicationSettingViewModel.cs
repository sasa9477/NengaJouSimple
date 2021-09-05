using NengaJouSimple.ViewModels.Entities.Layouts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace NengaJouSimple.ViewModels.Entities.Settings
{
    public class ApplicationSettingViewModel
    {
        public ApplicationSettingViewModel()
        {
            Honorifics = new List<string>();

            AvailableFontFamilies = new List<AvailableFontFamilyNameViewModel>();
        }

        public double PrintingOffsetX { get; set; }

        public double PrintingOffsetY { get; set; }

        public string FontFamilyName { get; set; }

        public List<string> Honorifics { get; }

        public string DefaultHonorific { get; set; }

        public List<AvailableFontFamilyNameViewModel> AvailableFontFamilies { get; }

        public PostalCodeTextLayoutSettingViewModel PostalCodeSetting { get; set; }

        public TextLayoutSettingViewModel AddressSetting { get; set; }

        public TextLayoutSettingViewModel AddresseeSetting { get; set; }

        public PostalCodeTextLayoutSettingViewModel SenderPostalCodeSetting { get; set; }

        public TextLayoutSettingViewModel SenderAddressSetting { get; set; }

        public TextLayoutSettingViewModel SenderSetting { get; set; }
    }
}
