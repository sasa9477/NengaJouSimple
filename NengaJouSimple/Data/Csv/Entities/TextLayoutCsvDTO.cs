using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NengaJouSimple.Data.Csv.Entities
{
    public class TextLayoutCsvDTO
    {
        public TextLayoutKind TextLayoutKind { get; set; }

        public Position Position { get; set; }

        public string FontFamilyName { get; set; }

        public double FontSize { get; set; }

        public FontStyleKind FontStyle { get; set; }

        public FontWeightKind FontWeight { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }

        public double SpaceBetweenMainWardAndTownWard { get; set; }

        public double SpaceBetweenEachWard { get; set; }
    }
}
