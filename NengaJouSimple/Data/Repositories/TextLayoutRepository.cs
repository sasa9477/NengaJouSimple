using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Data.Repositories
{
    public class TextLayoutRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        private readonly TextLayoutCsvService textLayoutCsvService;

        public TextLayoutRepository(
            ApplicationDbContext applicationDbContext,
            TextLayoutCsvService textLayoutCsvService)
        {
            this.applicationDbContext = applicationDbContext;

            this.textLayoutCsvService = textLayoutCsvService;

            InitializeData();
        }

        public List<TextLayout> LoadAll()
        {
            return applicationDbContext.TextLayouts
                .AsNoTracking()
                .ToList();
        }

        public List<TextLayout> LoadByAddressCard(AddressCard addressCard)
        {
            return applicationDbContext.TextLayouts
                .Where(e => e.AddressCard.Id == addressCard.Id)
                .AsNoTracking()
                .ToList();
        }

        public void Register(IEnumerable<TextLayout> textLayouts)
        {
            applicationDbContext.ChangeTracker.Clear();

            foreach (var textLayout in textLayouts)
            {
                applicationDbContext.Update(textLayout);
            }

            applicationDbContext.SaveChanges();

            WriteCsvFile();
        }

        public void Delete(IEnumerable<TextLayout> textLayouts)
        {
            applicationDbContext.ChangeTracker.Clear();

            foreach(var textLayout in textLayouts)
            {
                applicationDbContext.Remove(textLayout);
            }

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

            var textLayouts = textLayoutCsvService.ReadTextLayoutCsv();

            foreach (var textLayout in textLayouts)
            {
                textLayout.AddressCard = applicationDbContext.AddressCards.Find(textLayout.AddressCard.Id);
            }

            applicationDbContext.AddRange(textLayouts);

            applicationDbContext.SaveChanges();
        }

        private void WriteCsvFile()
        {
            var textLayouts = LoadAll();

            textLayoutCsvService.WriteTextLayoutCsv(textLayouts);
        }
    }
}
