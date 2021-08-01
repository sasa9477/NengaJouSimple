using Microsoft.EntityFrameworkCore;
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

        public AddressCardRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<AddressCard> LoadAll()
        {
            return applicationDbContext
                .AddressCards
                .Include(addressCard => addressCard.SenderAddressCard)
                .AsNoTracking()
                .ToList();
        }

        public void Register(AddressCard addressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Update(addressCard);

            applicationDbContext.SaveChanges();
        }

        public void Delete(AddressCard addressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Remove(addressCard);
            
            applicationDbContext.SaveChanges();
        }

        public bool IsRegisterAnyAddressCard()
        {
            return applicationDbContext.AddressCards.Any();
        }

        public void AddInitialData(IEnumerable<AddressCard> addressCards)
        {
            applicationDbContext.ChangeTracker.Clear();

            foreach (var addressCard in addressCards)
            {
                addressCard.SenderAddressCard = applicationDbContext.SenderAddressCards.Find(addressCard.SenderAddressCard.Id);
            }

            applicationDbContext.AddRange(addressCards);

            applicationDbContext.SaveChangesAsync();
        }
    }
}
