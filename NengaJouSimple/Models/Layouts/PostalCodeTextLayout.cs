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

        public double SpaceBetweenMainWardAndTownWard { get; set; }

        public double SpaceBetweenEachWard { get; set; }
    }
}
