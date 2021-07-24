using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NengaJouSimple.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NengaJouSimple.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AddressCard> AddressCards => Set<AddressCard>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries<EntityBase>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.RegisterdDateTime = DateTime.Now;
                    entry.Entity.UpdatedDateTime = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDateTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personNameConverter = new ValueConverter<PersonName, string>(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<PersonName>(v, null));

            modelBuilder.Entity<AddressCard>(buider =>
            {
                buider.Property(e => e.MainName)
                    .HasConversion(personNameConverter);

                buider.Property(e => e.MainNameKana)
                    .HasConversion(personNameConverter);

                buider.Property(e => e.Renmei1)
                    .HasConversion(personNameConverter);

                buider.Property(e => e.Renmei2)
                    .HasConversion(personNameConverter);

                buider.Property(e => e.Renmei3)
                    .HasConversion(personNameConverter);

                buider.Property(e => e.Renmei4)
                    .HasConversion(personNameConverter);

                buider.Property(e => e.Renmei5)
                    .HasConversion(personNameConverter);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
