using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Repositories
{
    public class SenderAddressCardRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly SenderAddressCardCsvService senderAddressCardCsvService;

        public SenderAddressCardRepository(
            ApplicationDbContext applicationDbContext,
            SenderAddressCardCsvService senderAddressCardCsvService)
        {
            this.applicationDbContext = applicationDbContext;
            this.senderAddressCardCsvService = senderAddressCardCsvService;
        }

        public List<SenderAddressCard> LoadAll()
        {
            return applicationDbContext
                .SenderAddressCards
                .OrderBy(e => e.MainNameKana)
                .AsNoTracking()
                .ToList();
        }

        public void Register(SenderAddressCard senderAddressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Update(senderAddressCard);

            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public void Delete(SenderAddressCard senderAddressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Remove(senderAddressCard);
            
            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public bool IsRegisterdAnySenderAddressCard()
        {
            return applicationDbContext.SenderAddressCards.Any();
        }

        public void InitializeData()
        {
            applicationDbContext.ChangeTracker.Clear();

            var senderAddressCards = senderAddressCardCsvService.ReadAddressCardCsv();

            applicationDbContext.AddRange(senderAddressCards);

            applicationDbContext.SaveChangesOnInitialize();
        }

        private void WriteCsvFile()
        {
            var allAddressCards = LoadAll();

            senderAddressCardCsvService.WriteAddressCardCsv(allAddressCards);
        }
    }
}
