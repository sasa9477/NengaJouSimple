using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NengaJouSimple.Models.Layouts
{
    public class Font
    {
        public Font()
        {
            FontSize = 14;
            FontStyle = FontStyleKind.Normal;
            FontWeight = FontWeightKind.Normal;
            VerticalAlignment = VerticalAlignment.Top;
        }

        public double FontSize { get; set; }

        public FontStyleKind FontStyle { get; set; }

        public FontWeightKind FontWeight { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }
    }
}
