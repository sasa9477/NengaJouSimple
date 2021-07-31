using CsvHelper.Configuration;
using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class AddressCardCsvClassMap : ClassMap<AddressCard>
    {
        public AddressCardCsvClassMap()
        {
            Map(e => e.Id).Index(0).Name("AddressCardId");
            Map(e => e.MainName).TypeConverter<CsvJsonConverter<PersonName>>().Index(1).Name(nameof(AddressCard.MainName));
            Map(e => e.MainNameKana).TypeConverter<CsvJsonConverter<PersonName>>().Index(2).Name(nameof(AddressCard.MainNameKana));
            Map(e => e.PostalCode).Index(3).Name(nameof(AddressCard.PostalCode));
            Map(e => e.Address1).Index(4).Name(nameof(AddressCard.Address1));
            Map(e => e.Address2).Index(5).Name(nameof(AddressCard.Address2));
            Map(e => e.Address3).Index(6).Name(nameof(AddressCard.Address3));
            Map(e => e.Renmei1).TypeConverter<CsvJsonConverter<PersonName>>().Index(7).Name(nameof(AddressCard.Renmei1));
            Map(e => e.Renmei2).TypeConverter<CsvJsonConverter<PersonName>>().Index(8).Name(nameof(AddressCard.Renmei2));
            Map(e => e.Renmei3).TypeConverter<CsvJsonConverter<PersonName>>().Index(9).Name(nameof(AddressCard.Renmei3));
            Map(e => e.Renmei4).TypeConverter<CsvJsonConverter<PersonName>>().Index(10).Name(nameof(AddressCard.Renmei4));
            Map(e => e.Renmei5).TypeConverter<CsvJsonConverter<PersonName>>().Index(11).Name(nameof(AddressCard.Renmei5));
            Map(e => e.SenderAddressCard.Id).Index(12).Name("SenderAddressCardId");
            Map(e => e.IsPrintTarget).Index(13).Name(nameof(AddressCard.IsPrintTarget));
        }
    }
}
