using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using System.Collections.Generic;
using System.Linq;

namespace NengaJouSimple.Data.Repositories
{
    public class AddressCardLayoutRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly ApplicationSettingRepository applicationSettingRepository;

        private readonly AddressCardRepository addressCardRepository;

        private readonly TextLayoutCsvService textLayoutCsvService;

        private readonly AddressCardLayoutCsvService addressCardLayoutCsvService;

        public AddressCardLayoutRepository(
            ApplicationDbContext applicationDbContext,
            ApplicationSettingRepository applicationSettingRepository,
            AddressCardRepository addressCardRepository,
            TextLayoutCsvService textLayoutCsvService,
            AddressCardLayoutCsvService addressCardLayoutCsvService)
        {
            this.applicationDbContext = applicationDbContext;
            this.applicationSettingRepository = applicationSettingRepository;
            this.addressCardRepository = addressCardRepository;
            this.textLayoutCsvService = textLayoutCsvService;
            this.addressCardLayoutCsvService = addressCardLayoutCsvService;
        }

        public AddressCardLayout LoadByAddressCard(AddressCard addressCard)
        {
            if (!applicationDbContext.AddressCardLayouts.Any(e => e.AddressCard.Id == addressCard.Id))
            {
                var applicationSetting = applicationSettingRepository.Load();

                var addressCardLayout = new AddressCardLayout();

                addressCardLayout.Attach(applicationSetting, null, addressCard);

                Register(addressCardLayout);
            }

            return applicationDbContext.AddressCardLayouts
                .Include(e => e.AddressCard)
                .ThenInclude(e => e.SenderAddressCard)
                .AsNoTracking()
                .FirstOrDefault(e => e.AddressCard.Id == addressCard.Id);
        }

        public void Register(AddressCardLayout addressCardLayout)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Update(addressCardLayout);

            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public void Delete(AddressCardLayout addressCardLayout)
        {
            applicationDbContext.ChangeTracker.Clear();

            applicationDbContext.Remove(addressCardLayout);

            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public void InitializeData()
        {
            if (!applicationDbContext.AddressCards.Any())
            {
                return;
            }

            applicationDbContext.ChangeTracker.Clear();

            var applicationSetting = applicationSettingRepository.Load();

            var csvTextLayouts = textLayoutCsvService.ReadTextLayoutCsv();

            var csvAddressCardLayouts = addressCardLayoutCsvService.ReadAddressCardLayoutCsv();

            foreach (var addressCardLayout in csvAddressCardLayouts)
            {
                var textLayouts = csvTextLayouts.Where(e => e.AddressCardLayout.Id == addressCardLayout.Id);

                var addressCard = addressCardRepository.LoadByAddressCardId(addressCardLayout.AddressCard.Id);

                addressCardLayout.Attach(applicationSetting, textLayouts, addressCard);

                applicationDbContext.Add(addressCardLayout);

                applicationDbContext.Entry(addressCardLayout.AddressCard).State = EntityState.Detached;
                applicationDbContext.Entry(addressCardLayout.AddressCard.SenderAddressCard).State = EntityState.Detached;
            }

            applicationDbContext.SaveChangesOnInitialize();
        }

        private void WriteCsvFile()
        {
            var addressCardLayouts = applicationDbContext.AddressCardLayouts
                .Include(e => e.AddressCard)
                .AsNoTracking()
                .ToList();

            addressCardLayoutCsvService.WriteTextLayoutCsv(addressCardLayouts);

            var textLayouts = addressCardLayouts.SelectMany(addressCardLayout => addressCardLayout.GetTextLayoutProperties());            

            textLayoutCsvService.WriteTextLayoutCsv(textLayouts);
        }
    }
}
