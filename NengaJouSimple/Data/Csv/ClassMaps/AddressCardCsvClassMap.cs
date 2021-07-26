using CsvHelper.Configuration;
using NengaJouSimple.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class AddressCardCsvClassMap : ClassMap<AddressCard>
    {
        public AddressCardCsvClassMap()
        {
            Map(addressCard => addressCard.Id).Index(0).Name("AddressCardId");
            Map(addressCard => addressCard.MainName).TypeConverter<CsvJsonConverter<PersonName>>().Index(1).Name(nameof(AddressCard.MainName));
            Map(addressCard => addressCard.MainNameKana).TypeConverter<CsvJsonConverter<PersonName>>().Index(2).Name(nameof(AddressCard.MainNameKana));
            Map(addressCard => addressCard.AddressNumber).Index(3).Name(nameof(AddressCard.AddressNumber));
            Map(addressCard => addressCard.Address1).Index(4).Name(nameof(AddressCard.Address1));
            Map(addressCard => addressCard.Address2).Index(5).Name(nameof(AddressCard.Address2));
            Map(addressCard => addressCard.Address3).Index(6).Name(nameof(AddressCard.Address3));
            Map(addressCard => addressCard.Renmei1).TypeConverter<CsvJsonConverter<PersonName>>().Index(7).Name(nameof(AddressCard.Renmei1));
            Map(addressCard => addressCard.Renmei2).TypeConverter<CsvJsonConverter<PersonName>>().Index(8).Name(nameof(AddressCard.Renmei2));
            Map(addressCard => addressCard.Renmei3).TypeConverter<CsvJsonConverter<PersonName>>().Index(9).Name(nameof(AddressCard.Renmei3));
            Map(addressCard => addressCard.Renmei4).TypeConverter<CsvJsonConverter<PersonName>>().Index(10).Name(nameof(AddressCard.Renmei4));
            Map(addressCard => addressCard.Renmei5).TypeConverter<CsvJsonConverter<PersonName>>().Index(11).Name(nameof(AddressCard.Renmei5));
            Map(addressCard => addressCard.SenderAddressCard.Id).Index(12).Name("SenderAddressCardId");
            Map(addressCard => addressCard.IsPrintTarget).Index(13).Name(nameof(AddressCard.IsPrintTarget));
        }
    }
}
