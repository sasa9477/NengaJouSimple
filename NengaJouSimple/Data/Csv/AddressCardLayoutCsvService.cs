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
    public class AddressCardLayoutCsvService
    {
        private const string AddressCardLayoutCsvFileName = @"AddressCardLayouts.csv";

        private static readonly string AddressCardLayoutCsvFilePath = Path.Combine(BaseDirectory.BaseDirectoryPath, AddressCardLayoutCsvFileName);

        public List<AddressCardLayout> ReadAddressCardLayoutCsv()
        {
            if (!File.Exists(AddressCardLayoutCsvFilePath))
            {
                return new List<AddressCardLayout>();
            }

            using var reader = new StreamReader(AddressCardLayoutCsvFilePath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<AddressCardLayoutCsvClassMap>();

            return csvReader.GetRecords<AddressCardLayout>().ToList();
        }

        public void WriteTextLayoutCsv(IEnumerable<AddressCardLayout> addressCardLayouts)
        {
            using var writer = new StreamWriter(AddressCardLayoutCsvFilePath);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<AddressCardLayoutCsvClassMap>();

            csvWriter.WriteRecords(addressCardLayouts);
        }
    }
}
