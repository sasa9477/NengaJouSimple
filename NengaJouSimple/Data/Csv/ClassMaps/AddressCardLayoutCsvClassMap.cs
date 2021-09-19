using CsvHelper.Configuration;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Csv.ClassMaps
{
    public class AddressCardLayoutCsvClassMap : ClassMap<AddressCardLayout>
    {
        public AddressCardLayoutCsvClassMap()
        {
            Map(e => e.Id).Index(0).Name("AddressCardLayoutId");
            Map(e => e.AddressCard.Id).Index(1).Name("AddressCardId");
            Map(e => e.RegisterdDateTime).Index(2).Name(nameof(AddressCardLayout.RegisterdDateTime));
            Map(e => e.UpdatedDateTime).Index(3).Name(nameof(AddressCardLayout.UpdatedDateTime));
        }
    }
}
