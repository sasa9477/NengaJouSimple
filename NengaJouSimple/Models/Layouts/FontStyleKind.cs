using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NengaJouSimple.Models.Layouts
{
    public enum FontStyleKind
    {
        Normal,
        Italic
    }

    public static class FontStyleKindExtension
    {
        public static FontStyle ToFontStyle(this FontStyleKind fontStyleKind)
        {
            return fontStyleKind switch
            {
                FontStyleKind.Italic => FontStyles.Italic,
                FontStyleKind.Normal => FontStyles.Normal,
                _ => FontStyles.Normal
            };
        }

        public static FontStyleKind ToFontStyleKind (this FontStyle fontStyle)
        {
            if (fontStyle.Equals(FontStyles.Italic))
            {
                return FontStyleKind.Italic;
            }

            return FontStyleKind.Normal;
        }
    }
}
