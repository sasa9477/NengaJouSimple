using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NengaJouSimple.Models;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.Models.Settings;
using System;
using System.Text.Json;

namespace NengaJouSimple.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AddressCard> AddressCards => Set<AddressCard>();

        public DbSet<SenderAddressCard> SenderAddressCards => Set<SenderAddressCard>();

        public DbSet<AddressCardLayout> AddressCardLayouts => Set<AddressCardLayout>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
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

                var entity = entry.Entity;

                System.Diagnostics.Debug.WriteLine(entity.GetType());

                System.Diagnostics.Debug.WriteLine($"EntityState:{entry.State}");


                if (entity is AddressCard addressCard)
                {
                    var addressCardId = addressCard.Id;

                    System.Diagnostics.Debug.WriteLine($"addressCardId : {addressCardId}");
                }

                if (entity is SenderAddressCard senderAddressCard)
                {
                    var senderAddressCardId = senderAddressCard.Id;

                    System.Diagnostics.Debug.WriteLine($"senderAddressCardId : {senderAddressCardId}");
                }

                if (entity is AddressCardLayout layout)
                {
                    var addressCardId = layout.AddressCard.Id;

                    var senderAddressCardId = layout.AddressCard.SenderAddressCard.Id;

                    System.Diagnostics.Debug.WriteLine($"addressCardId : {addressCardId}");
                    System.Diagnostics.Debug.WriteLine($"senderAddressCardId : {senderAddressCardId}");
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(log => System.Diagnostics.Debug.WriteLine(log), Microsoft.Extensions.Logging.LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personNameConverter = new ValueConverter<PersonName, string>(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<PersonName>(v, null));

            var renmeiConverter = new ValueConverter<Renmei, string>(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<Renmei>(v, null));

            modelBuilder.Entity<AddressCard>(builder =>
            {
                builder.Property(e => e.MainName)
                    .HasConversion(personNameConverter);

                builder.Property(e => e.MainNameKana)
                    .HasConversion(personNameConverter);

                builder.Property(e => e.Renmei1)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei2)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei3)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei4)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei5)
                    .HasConversion(renmeiConverter);
            });

            modelBuilder.Entity<SenderAddressCard>(builder =>
            {
                builder.Property(e => e.MainName)
                    .HasConversion(personNameConverter);

                builder.Property(e => e.MainNameKana)
                    .HasConversion(personNameConverter);

                builder.Property(e => e.Renmei1)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei2)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei3)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei4)
                    .HasConversion(renmeiConverter);

                builder.Property(e => e.Renmei5)
                    .HasConversion(renmeiConverter);
            });

            var positionConverter = new ValueConverter<Position, string>(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<Position>(v, null));

            modelBuilder.Entity<AddressCardLayout>(builder =>
            {
                builder.OwnsOne(
                    e => e.PostalCode,
                    o =>
                    {
                        o.Property(e2 => e2.Position)
                            .HasConversion(positionConverter);
                    });

                builder.OwnsOne(
                    e => e.Address,
                    o =>
                    {
                        o.Property(e2 => e2.Position)
                            .HasConversion(positionConverter);
                    });

                builder.OwnsOne(
                    e => e.Addressee,
                    o =>
                    {
                        o.Property(e2 => e2.Position)
                            .HasConversion(positionConverter);
                    });

                builder.OwnsOne(
                    e => e.SenderPostalCode,
                    o =>
                    {
                        o.Property(e2 => e2.Position)
                            .HasConversion(positionConverter);
                    });

                builder.OwnsOne(
                    e => e.SenderAddress,
                    o =>
                    {
                        o.Property(e2 => e2.Position)
                            .HasConversion(positionConverter);
                    });

                builder.OwnsOne(
                    e => e.Sender,
                    o =>
                    {
                        o.Property(e2 => e2.Position)
                            .HasConversion(positionConverter);
                    });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
