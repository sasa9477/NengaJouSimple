using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class FontViewModel
    {
        public FontViewModel()
        {
            FontFamily = SystemFonts.MessageFontFamily;
            FontSize = 12;
            FontStyle = FontStyles.Normal;
            FontWeight = FontWeights.Normal;
            VerticalAlignment = VerticalAlignment.Top;
        }

        public FontFamily FontFamily { get; set; }

        public double FontSize { get; set; }

        public FontStyle FontStyle { get; set; }

        public FontWeight FontWeight { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }
    }
}
