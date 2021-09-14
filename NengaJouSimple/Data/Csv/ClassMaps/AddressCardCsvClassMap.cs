using CsvHelper.Configuration;
using NengaJouSimple.Data.Csv.Converters;
using NengaJouSimple.Models.Addresses;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class AddressCardCsvClassMap : ClassMap<AddressCard>
    {
        public AddressCardCsvClassMap()
        {
            Map(e => e.Id).Index(0).Name("AddressCardId");
            Map(e => e.MainName).Index(1).Name(nameof(AddressCard.MainName)).TypeConverter<CsvJsonConverter<PersonName>>();
            Map(e => e.MainNameKana).Index(2).Name(nameof(AddressCard.MainNameKana)).TypeConverter<CsvJsonConverter<PersonName>>();
            Map(e => e.PostalCode).Index(3).Name(nameof(AddressCard.PostalCode));
            Map(e => e.Address1).Index(4).Name(nameof(AddressCard.Address1));
            Map(e => e.Address2).Index(5).Name(nameof(AddressCard.Address2));
            Map(e => e.Renmei1).Index(6).Name(nameof(AddressCard.Renmei1)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei2).Index(7).Name(nameof(AddressCard.Renmei2)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei3).Index(8).Name(nameof(AddressCard.Renmei3)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei4).Index(9).Name(nameof(AddressCard.Renmei4)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.Renmei5).Index(10).Name(nameof(AddressCard.Renmei5)).TypeConverter<CsvJsonConverter<Renmei>>();
            Map(e => e.SenderAddressCard.Id).Index(11).Name("SenderAddressCardId");
            Map(e => e.IsPrintTarget).Index(12).Name(nameof(AddressCard.IsPrintTarget));
            Map(e => e.IsFamilyPrinting).Index(13).Name(nameof(AddressCard.IsFamilyPrinting));
            Map(e => e.PrintedDateTime).Index(14).Name(nameof(AddressCard.PrintedDateTime));
            Map(e => e.RegisterdDateTime).Index(15).Name(nameof(AddressCard.RegisterdDateTime));
            Map(e => e.UpdatedDateTime).Index(16).Name(nameof(AddressCard.UpdatedDateTime));
        }
    }
}
