using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NengaJouSimple.Models.Layouts
{
    public enum FontWeightKind
    {
        Normal,
        Bold
    }

    public static class FontWeightKindExtensions
    {
        public static FontWeight ToFontWeight(this FontWeightKind fontWeightKind)
        {
            return fontWeightKind switch
            {
                FontWeightKind.Bold => FontWeights.Bold,
                FontWeightKind.Normal => FontWeights.Normal,
                _ => FontWeights.Normal
            };
        }

        public static FontWeightKind ToFontWeightKind(this FontWeight fontWeight)
        {
            if (fontWeight.Equals(FontWeights.Bold))
            {
                return FontWeightKind.Bold;
            }

            return FontWeightKind.Normal;
        }
    }
}
