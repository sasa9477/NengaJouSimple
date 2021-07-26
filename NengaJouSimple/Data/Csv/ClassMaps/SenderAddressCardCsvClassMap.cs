using CsvHelper.Configuration;
using NengaJouSimple.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class SenderAddressCardCsvClassMap : ClassMap<SenderAddressCard>
    {
        public SenderAddressCardCsvClassMap()
        {
            Map(addressCard => addressCard.Id).Index(0).Name("SenderAddressCardId");
            Map(addressCard => addressCard.MainName).TypeConverter<CsvJsonConverter<PersonName>>().Index(1).Name(nameof(SenderAddressCard.MainName));
            Map(addressCard => addressCard.MainNameKana).TypeConverter<CsvJsonConverter<PersonName>>().Index(2).Name(nameof(SenderAddressCard.MainNameKana));
            Map(addressCard => addressCard.AddressNumber).Index(3).Name(nameof(SenderAddressCard.AddressNumber));
            Map(addressCard => addressCard.Address1).Index(4).Name(nameof(SenderAddressCard.Address1));
            Map(addressCard => addressCard.Address2).Index(5).Name(nameof(SenderAddressCard.Address2));
            Map(addressCard => addressCard.Address3).Index(6).Name(nameof(SenderAddressCard.Address3));
            Map(addressCard => addressCard.Renmei1).TypeConverter<CsvJsonConverter<PersonName>>().Index(7).Name(nameof(SenderAddressCard.Renmei1));
            Map(addressCard => addressCard.Renmei2).TypeConverter<CsvJsonConverter<PersonName>>().Index(8).Name(nameof(SenderAddressCard.Renmei2));
            Map(addressCard => addressCard.Renmei3).TypeConverter<CsvJsonConverter<PersonName>>().Index(9).Name(nameof(SenderAddressCard.Renmei3));
            Map(addressCard => addressCard.Renmei4).TypeConverter<CsvJsonConverter<PersonName>>().Index(10).Name(nameof(SenderAddressCard.Renmei4));
            Map(addressCard => addressCard.Renmei5).TypeConverter<CsvJsonConverter<PersonName>>().Index(11).Name(nameof(SenderAddressCard.Renmei5));
        }
    }
}
