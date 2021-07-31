using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Layouts
{
    public class PostalCodeTextLayout : TextLayout
    {
        public PostalCodeTextLayout() : base()
        {
        }

        public double SpaceBetweenMailWardAndTownWard { get; set; }

        public double SpaceBetweenMailWardEachWard { get; set; }

        public double SpaceBetweenTownWardEachWard { get; set; }
    }
}
