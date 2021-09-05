using CsvHelper.Configuration;
using NengaJouSimple.Data.Csv.Converters;
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
            Map(e => e.MainName).Index(1).Name(nameof(SenderAddressCard.MainName)).TypeConverter<CsvJsonConverter<PersonName>>();
            Map(e => e.MainNameKana).Index(2).Name(nameof(SenderAddressCard.MainNameKana)).TypeConverter<CsvJsonConverter<PersonName>>();
            Map(e => e.PostalCode).Index(3).Name(nameof(SenderAddressCard.PostalCode));
            Map(e => e.Address1).Index(4).Name(nameof(SenderAddressCard.Address1));
            Map(e => e.Address2).Index(5).Name(nameof(SenderAddressCard.Address2));
            Map(e => e.Renmei1).Index(6).Name(nameof(SenderAddressCard.Renmei1)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei2).Index(7).Name(nameof(SenderAddressCard.Renmei2)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei3).Index(8).Name(nameof(SenderAddressCard.Renmei3)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei4).Index(9).Name(nameof(SenderAddressCard.Renmei4)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei5).Index(10).Name(nameof(SenderAddressCard.Renmei5)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.RegisterdDateTime).Index(11).Name(nameof(AddressCard.RegisterdDateTime));
            Map(e => e.UpdatedDateTime).Index(12).Name(nameof(AddressCard.UpdatedDateTime));
        }
    }
}
