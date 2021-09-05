using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Models.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Repositories
{
    public class AddressCardRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly AddressCardCsvService addressCardCsvService;

        public AddressCardRepository(
            ApplicationDbContext applicationDbContext,
            AddressCardCsvService addressCardCsvService)
        {
            this.applicationDbContext = applicationDbContext;

            this.addressCardCsvService = addressCardCsvService;
        }

        public List<AddressCard> LoadAll()
        {
            return applicationDbContext
                .AddressCards
                .Include(addressCard => addressCard.SenderAddressCard)
                .AsNoTracking()
                .ToList();
        }

        public List<AddressCard> LoadAllPrintTargets()
        {
            return applicationDbContext.AddressCards
                .Include(addressCard => addressCard.SenderAddressCard)
                .Where(addressCard => addressCard.IsPrintTarget)
                .AsNoTracking()
                .ToList();
        }

        public void Register(AddressCard addressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Update(addressCard);

            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public void Delete(AddressCard addressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Remove(addressCard);

            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public bool IsRegisterAnyAddressCard()
        {
            return applicationDbContext.AddressCards.Any();
        }

        public void InitializeData()
        {
            if (!applicationDbContext.SenderAddressCards.Any())
            {
                return;
            }

            applicationDbContext.ChangeTracker.Clear();

            var addressCards = addressCardCsvService.ReadAddressCardCsv();

            foreach (var addressCard in addressCards)
            {
                addressCard.SenderAddressCard = applicationDbContext.SenderAddressCards.Find(addressCard.SenderAddressCard.Id);
            }

            applicationDbContext.AddRange(addressCards);

            applicationDbContext.SaveChangesAsync();
        }

        private void WriteCsvFile()
        {
            var allAddressCards = LoadAll();

            addressCardCsvService.WriteAddressCardCsv(allAddressCards);
        }
    }
}
