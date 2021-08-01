using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            //var seedData = new List<SenderAddressCard>()
            //{
            //    new SenderAddressCard
            //    {
            //        MainName = new PersonName
            //        {
            //            FamilyName = "田中",
            //            GivenName = "久重"
            //        },
            //        PostalCode = "038-3305",
            //        Address1 = "青森県つがる市牛潟町",
            //        Address2 = "75-56"
            //    },
            //    new SenderAddressCard
            //    {
            //        MainName = new PersonName
            //        {
            //            FamilyName = "岡本",
            //            GivenName = "太郎"
            //        },
            //        PostalCode = "038-3305",
            //        Address1 = "青森県つがる市牛潟町",
            //        Address2 = "75-56"
            //    }
            //};

            //var seedData2 = new List<AddressCard>()
            //{
            //    new AddressCard
            //    {
            //        MainName = new PersonName
            //        {
            //            FamilyName = "国枝",
            //            GivenName = "光彦",
            //            Honorific = "様"
            //        },
            //        PostalCode = "038-3305",
            //        Address1 = "青森県つがる市牛潟町",
            //        Address2 = "56-56",
            //        SenderAddressCard = new SenderAddressCard
            //        {
            //            MainName = new PersonName
            //            {
            //                FamilyName = "園田",
            //                GivenName = "彌栄"
            //            },
            //            PostalCode = "038-3305",
            //            Address1 = "青森県つがる市牛潟町",
            //            Address2 = "75-56"
            //        }
            //    }
            //};

            //dbContext.UpdateRange(seedData);

            //dbContext.UpdateRange(seedData2);

            //dbContext.SaveChanges();
        }
    }
}
