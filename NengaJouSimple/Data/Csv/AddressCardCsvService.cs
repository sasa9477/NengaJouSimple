using CsvHelper;
using NengaJouSimple.Data.Csv.ClassMaps;
using NengaJouSimple.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Csv
{
    public class AddressCardCsvService
    {
        public const string AddressCsvFilePath = @"AddressCards.csv";

        public List<AddressCard> ReadAddressCardCsv()
        {
            if (!File.Exists(AddressCsvFilePath))
            {
                return new List<AddressCard>();
            }

            using var reader = new StreamReader(AddressCsvFilePath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<AddressCardCsvClassMap>();

            return csvReader.GetRecords<AddressCard>().ToList();
        }

        public void WriteAddressCardCsv(IEnumerable<AddressCard> addressCards)
        {
            using var writer = new StreamWriter(AddressCsvFilePath);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<AddressCardCsvClassMap>();

            csvWriter.WriteRecords(addressCards);
        }
    }
}
