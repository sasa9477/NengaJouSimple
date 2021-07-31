using CsvHelper.Configuration;
using NengaJouSimple.Data.Csv.Entities;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class TextLayoutCsvClassMap : ClassMap<TextLayoutCsvDTO>
    {
        public TextLayoutCsvClassMap()
        {
            Map(e => e.TextLayoutKind).Index(0).Name(nameof(TextLayoutCsvDTO.TextLayoutKind));
            Map(e => e.Position).TypeConverter<CsvJsonConverter<Position>>().Index(1).Name(nameof(TextLayoutCsvDTO.Position));
            Map(e => e.FontFamilyName).Index(2).Name(nameof(TextLayoutCsvDTO.FontFamilyName));
            Map(e => e.FontSize).Index(3).Name(nameof(TextLayoutCsvDTO.FontSize));
            Map(e => e.FontStyle).Index(4).Name(nameof(TextLayoutCsvDTO.FontStyle));
            Map(e => e.FontWeight).Index(5).Name(nameof(TextLayoutCsvDTO.FontWeight));
            Map(e => e.VerticalAlignment).Index(6).Name(nameof(TextLayoutCsvDTO.VerticalAlignment));
            Map(e => e.SpaceBetweenMailWardAndTownWard).Index(7).Name(nameof(TextLayoutCsvDTO.SpaceBetweenMailWardAndTownWard));
            Map(e => e.SpaceBetweenMailWardEachWard).Index(8).Name(nameof(TextLayoutCsvDTO.SpaceBetweenMailWardEachWard));
        }
    }
}
