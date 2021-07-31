using AutoMapper;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Csv.Entities;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.ViewModels.Entities.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Services
{
    public class AddressCardLayoutService
    {
        private readonly AddressCardLayoutRepository addressCardLayoutRepository;

        private readonly TextLayoutCsvService textLayoutCsvService;

        private readonly IMapper mapper;

        public AddressCardLayoutService(
            AddressCardLayoutRepository addressCardLayoutRepository,
            TextLayoutCsvService textLayoutCsvService,
            IMapper mapper)
        {
            this.addressCardLayoutRepository = addressCardLayoutRepository;
            this.textLayoutCsvService = textLayoutCsvService;
            this.mapper = mapper;
        }

        public AddressCardLayoutViewModel Load()
        {
            var addressCardLayout = addressCardLayoutRepository.Load();

            return mapper.Map<AddressCardLayoutViewModel>(addressCardLayout);
        }

        public void Register(AddressCardLayoutViewModel addressCardLayoutViewModel)
        {
            var addressCardLayout = mapper.Map<AddressCardLayout>(addressCardLayoutViewModel);

            addressCardLayoutRepository.Register(addressCardLayout);

            WriteCsvFile();
        }

        public void ReadCsvFile()
        {
            var textLayouts = textLayoutCsvService.ReadTextLayoutCsv();

            var addressCardLayout = new AddressCardLayout(textLayouts, mapper);

            addressCardLayoutRepository.Register(addressCardLayout);
        }

        private void WriteCsvFile()
        {
            var addressCardLayout = addressCardLayoutRepository.Load();

            var textLayouts = new List<TextLayoutCsvDTO>(addressCardLayout.ConvertToCsvDTO(mapper));

            textLayoutCsvService.WriteTextLayoutCsv(textLayouts);
        }
    }
}
