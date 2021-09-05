using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Settings
{
    public class PostalCodeTextLayoutSetting : TextLayoutSetting
    {
        public double SpaceBetweenMailWardAndTownWard { get; set; }

        public double SpaceBetweenMailWardEachWard { get; set; }

        public double SpaceBetweenTownWardEachWard { get; set; }

        public double SpaceBetweenMailWardAndTownWardDefaultValue { get; set; }

        public double SpaceBetweenMailWardEachWardDefaultValue { get; set; }

        public double SpaceBetweenTownWardEachWardDefaultValue { get; set; }
    }
}
