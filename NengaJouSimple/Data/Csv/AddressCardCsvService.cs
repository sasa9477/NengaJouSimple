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
    public class AddressCardCsvService
    {
        public const string AddressCsvFileName = @"AddressCards.csv";

        public List<AddressCard> ReadAddressCardCsv()
        {
            if (!File.Exists(AddressCsvFileName))
            {
                return new List<AddressCard>();
            }

            using var reader = new StreamReader(AddressCsvFileName);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            csvReader.Context.RegisterClassMap<AddressCardCsvClassMap>();

            return csvReader.GetRecords<AddressCard>().ToList();
        }

        public void WriteAddressCardCsv(IEnumerable<AddressCard> addressCards)
        {
            using var writer = new StreamWriter(AddressCsvFileName);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<AddressCardCsvClassMap>();

            csvWriter.WriteRecords(addressCards);
        }
    }
}
