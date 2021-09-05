using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.Converters
{
    public class TextLayoutKindConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return TextLayoutKindExtension.ConvertFromString(text);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is TextLayoutKind textLayoutKind)
            {
                return textLayoutKind.ConvertToString();
            }

            throw new InvalidCastException($"Could not convert {nameof(value)} to {nameof(TextLayoutKind)}. {nameof(value)}: {value}");
        }
    }
}
