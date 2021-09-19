using CsvHelper.Configuration;
using NengaJouSimple.Data.Csv.Converters;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class TextLayoutCsvClassMap : ClassMap<TextLayout>
    {
        public TextLayoutCsvClassMap()
        {
            Map(e => e.TextLayoutKind).Index(0).Name(nameof(TextLayout.TextLayoutKind)).TypeConverter<TextLayoutKindConverter>();
            Map(e => e.Position).Index(1).Name(nameof(TextLayout.Position)).TypeConverter<CsvJsonConverter<Position>>();
            Map(e => e.FontSize).Index(2).Name(nameof(TextLayout.FontSize));
            Map(e => e.AddressCardLayout.Id).Index(3).Name("AddressCardLayoutId");

            Map(e => e.Text).Ignore();
        }
    }
}
