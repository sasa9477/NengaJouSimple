using CsvHelper;
using NengaJouSimple.Data.Csv.ClassMaps;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Csv
{
    public class TextLayoutCsvService
    {
        private const string TextLayoutCsvFileName = @"TextLayouts.csv";

        private static readonly string TextLayoutCsvFilePath = Path.Combine(BaseDirectory.BaseDirectoryPath, TextLayoutCsvFileName);

        public List<TextLayout> ReadTextLayoutCsv()
        {
            if (!File.Exists(TextLayoutCsvFilePath))
            {
                return new List<TextLayout>();
            }

            using var reader = new StreamReader(TextLayoutCsvFilePath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<TextLayoutClassMap>();

            return csvReader.GetRecords<TextLayout>().ToList();
        }

        public void WriteTextLayoutCsv(IEnumerable<TextLayout> textLayouts)
        {
            using var writer = new StreamWriter(TextLayoutCsvFilePath);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TextLayoutClassMap>();

            csvWriter.WriteRecords(textLayouts);
        }
    }
}
