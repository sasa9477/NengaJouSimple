using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Repositories
{
    public class AddressCardLayoutRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AddressCardLayoutRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public AddressCardLayout Load()
        {
            return applicationDbContext
                .AddressCardLayouts
                .AsNoTracking()
                .FirstOrDefault();
        }

        public void Register(AddressCardLayout addressCardLayout)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Update(addressCardLayout);

            applicationDbContext.SaveChanges();
        }
    }
}
