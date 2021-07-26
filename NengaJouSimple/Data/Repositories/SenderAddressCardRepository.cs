using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Repositories
{
    public class SenderAddressCardRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SenderAddressCardRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public List<SenderAddressCard> LoadAll()
        {
            return applicationDbContext
                .SenderAddressCards
                .AsNoTracking()
                .ToList();
        }

        public void Register(SenderAddressCard senderAddressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Update(senderAddressCard);

            applicationDbContext.SaveChanges();
        }

        public void Delete(SenderAddressCard senderAddressCard)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Remove(senderAddressCard);
            
            applicationDbContext.SaveChanges();
        }

        public void AddRanges(IEnumerable<SenderAddressCard> senderAddressCards)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.AddRange(senderAddressCards);

            applicationDbContext.SaveChanges();
        }
    }
}
