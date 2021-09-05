using NengaJouSimple.ViewModels.Entities.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Settings
{
    public class PostalCodeTextLayoutSettingViewModel : TextLayoutSettingViewModel
    {
        public double SpaceBetweenMailWardAndTownWard { get; set; }

        public double SpaceBetweenMailWardEachWard { get; set; }

        public double SpaceBetweenTownWardEachWard { get; set; }

        public double SpaceBetweenMailWardAndTownWardDefaultValue { get; set; }

        public double SpaceBetweenMailWardEachWardDefaultValue { get; set; }

        public double SpaceBetweenTownWardEachWardDefaultValue { get; set; }
    }
}
