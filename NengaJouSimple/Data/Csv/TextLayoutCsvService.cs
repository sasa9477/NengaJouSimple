using CsvHelper;
using NengaJouSimple.Data.Csv.ClassMaps;
using NengaJouSimple.Data.Csv.Entities;
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
        public const string TextLayoutCsvFilePath = @"TextLayouts.csv";

        public List<TextLayoutCsvDTO> ReadTextLayoutCsv()
        {
            if (!File.Exists(TextLayoutCsvFilePath))
            {
                return new List<TextLayoutCsvDTO>();
            }

            using var reader = new StreamReader(TextLayoutCsvFilePath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<TextLayoutCsvClassMap>();

            return csvReader.GetRecords<TextLayoutCsvDTO>().ToList();
        }

        public void WriteTextLayoutCsv(IEnumerable<TextLayoutCsvDTO> addressCards)
        {
            using var writer = new StreamWriter(TextLayoutCsvFilePath);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TextLayoutCsvClassMap>();

            csvWriter.WriteRecords(addressCards);
        }
    }
}
