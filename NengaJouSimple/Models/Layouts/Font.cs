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
            FontFamilyName = string.Empty;
            FontSize = 12;
            FontStyle = FontStyleKind.Normal;
            FontWeight = FontWeightKind.Normal;
            VerticalAlignment = VerticalAlignment.Top;
        }

        public Font(string fontFamilyName, double fontSize, FontStyleKind fontStyle, FontWeightKind fontWeight, VerticalAlignment verticalAlignment)
        {
            FontFamilyName = fontFamilyName;
            FontSize = fontSize;
            FontStyle = fontStyle;
            FontWeight = fontWeight;
            VerticalAlignment = verticalAlignment;
        }

        public string FontFamilyName { get; set; }

        public double FontSize { get; set; }

        public FontStyleKind FontStyle { get; set; }

        public FontWeightKind FontWeight { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }
    }
}
