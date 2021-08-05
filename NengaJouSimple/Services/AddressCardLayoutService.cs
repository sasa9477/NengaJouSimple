using AutoMapper;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Jsons;
using NengaJouSimple.Data.Jsons.Entities;
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

        private readonly AddressCardLayoutJsonService addressCardLayoutJsonService;

        private readonly IMapper mapper;

        public AddressCardLayoutService(
            AddressCardLayoutRepository addressCardLayoutRepository,
            AddressCardLayoutJsonService addressCardLayoutJsonService,
            IMapper mapper)
        {
            this.addressCardLayoutRepository = addressCardLayoutRepository;
            this.addressCardLayoutJsonService = addressCardLayoutJsonService;
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

            WriteJsonFile();
        }

        public void ReadJsonFile()
        {
            var addressCardLayout = new AddressCardLayout();

            var addressCardLayoutJsonDTO = addressCardLayoutJsonService.ReadAddressCardLayoutJson();

            if (addressCardLayoutJsonDTO != null)
            {
                addressCardLayout = mapper.Map<AddressCardLayout>(addressCardLayoutJsonDTO);
            }

            addressCardLayoutRepository.Register(addressCardLayout);
        }

        private void WriteJsonFile()
        {
            var addressCardLayout = addressCardLayoutRepository.Load();

            var addressCardLayoutJsonDTO = mapper.Map<AddressCardLayoutJsonDTO>(addressCardLayout);

            addressCardLayoutJsonService.WriteAddressCardLayoutJson(addressCardLayoutJsonDTO);
        }
    }
}
