using CsvHelper;
using NengaJouSimple.Data.Csv.ClassMaps;
using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Csv
{
    public class SenderAddressCardCsvService
    {
        private const string SenderAddressCsvFileName = @"SenderAddressCards.csv";

        private static readonly string SenderAddressCsvFilePath = Path.Combine(BaseDirectory.BaseDirectoryPath, SenderAddressCsvFileName);

        public List<SenderAddressCard> ReadAddressCardCsv()
        {
            if (!File.Exists(SenderAddressCsvFilePath))
            {
                return new List<SenderAddressCard>();
            }

            using var reader = new StreamReader(SenderAddressCsvFilePath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<SenderAddressCardCsvClassMap>();

            return csvReader.GetRecords<SenderAddressCard>().ToList();
        }

        public void WriteAddressCardCsv(IEnumerable<SenderAddressCard> senderAddressCards)
        {
            using var writer = new StreamWriter(SenderAddressCsvFilePath);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<SenderAddressCardCsvClassMap>();

            csvWriter.WriteRecords(senderAddressCards);
        }
    }
}
