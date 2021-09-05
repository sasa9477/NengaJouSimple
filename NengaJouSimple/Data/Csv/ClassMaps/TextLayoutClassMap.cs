using CsvHelper.Configuration;
using NengaJouSimple.Data.Csv.Converters;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class TextLayoutClassMap : ClassMap<TextLayout>
    {
        public TextLayoutClassMap()
        {
            Map(e => e.Id).Index(0).Name("TextLayoutId");
            Map(e => e.TextLayoutKind).Index(1).Name(nameof(TextLayout.TextLayoutKind)).TypeConverter<TextLayoutKindConverter>();
            Map(e => e.Position).Index(2).Name(nameof(TextLayout.Position));
            Map(e => e.FontSize).Index(3).Name(nameof(TextLayout.FontSize));
            Map(e => e.AddressCard.Id).Index(4).Name("AddressCardId");
            Map(e => e.RegisterdDateTime).Index(5).Name(nameof(TextLayout.RegisterdDateTime));
            Map(e => e.UpdatedDateTime).Index(6).Name(nameof(TextLayout.UpdatedDateTime));

            Map(e => e.Text).Ignore();
        }
    }
}
