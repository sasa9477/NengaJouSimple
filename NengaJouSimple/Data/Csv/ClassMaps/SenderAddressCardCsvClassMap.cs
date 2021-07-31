using CsvHelper.Configuration;
using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class SenderAddressCardCsvClassMap : ClassMap<SenderAddressCard>
    {
        public SenderAddressCardCsvClassMap()
        {
            Map(e => e.Id).Index(0).Name("SenderAddressCardId");
            Map(e => e.MainName).TypeConverter<CsvJsonConverter<PersonName>>().Index(1).Name(nameof(SenderAddressCard.MainName));
            Map(e => e.MainNameKana).TypeConverter<CsvJsonConverter<PersonName>>().Index(2).Name(nameof(SenderAddressCard.MainNameKana));
            Map(e => e.PostalCode).Index(3).Name(nameof(SenderAddressCard.PostalCode));
            Map(e => e.Address1).Index(4).Name(nameof(SenderAddressCard.Address1));
            Map(e => e.Address2).Index(5).Name(nameof(SenderAddressCard.Address2));
            Map(e => e.Address3).Index(6).Name(nameof(SenderAddressCard.Address3));
            Map(e => e.Renmei1).TypeConverter<CsvJsonConverter<PersonName>>().Index(7).Name(nameof(SenderAddressCard.Renmei1));
            Map(e => e.Renmei2).TypeConverter<CsvJsonConverter<PersonName>>().Index(8).Name(nameof(SenderAddressCard.Renmei2));
            Map(e => e.Renmei3).TypeConverter<CsvJsonConverter<PersonName>>().Index(9).Name(nameof(SenderAddressCard.Renmei3));
            Map(e => e.Renmei4).TypeConverter<CsvJsonConverter<PersonName>>().Index(10).Name(nameof(SenderAddressCard.Renmei4));
            Map(e => e.Renmei5).TypeConverter<CsvJsonConverter<PersonName>>().Index(11).Name(nameof(SenderAddressCard.Renmei5));
        }
    }
}
