using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Models;
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
            return applicationDbContext.AddressCards.AsNoTracking().ToList();
        }

        public void Register(AddressCard addressCard)
        {
            applicationDbContext.Update(addressCard);

            applicationDbContext.SaveChanges();

            applicationDbContext.ChangeTracker.Clear();
        }

        public void Delete(AddressCard addressCard)
        {
            applicationDbContext.Remove(addressCard);
            
            applicationDbContext.SaveChanges();

            applicationDbContext.ChangeTracker.Clear();
        }
    }
}
