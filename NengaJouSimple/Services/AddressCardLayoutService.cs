using AutoMapper;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.ViewModels.Entities.Layouts;
using System.Collections.Generic;
using System.Linq;

namespace NengaJouSimple.Services
{
    public class AddressCardLayoutService
    {
        private readonly AddressCardRepository addressCardRepository;

        private readonly AddressCardLayoutRepository addressCardLayoutRepository;

        private readonly IMapper mapper;

        public AddressCardLayoutService(
            AddressCardRepository addressCardRepository,
            AddressCardLayoutRepository addressCardLayoutRepository,
            IMapper mapper)
        {
            this.addressCardRepository = addressCardRepository;
            this.addressCardLayoutRepository = addressCardLayoutRepository;
            this.mapper = mapper;
        }

        public List<AddressCardLayoutViewModel> LoadAll()
        {
            var addressCards = addressCardRepository.LoadAllPrintTargets();

            var addressCardLayouts = new List<AddressCardLayout>();

            foreach (var addressCard in addressCards)
            {
                var addressCardLayout = addressCardLayoutRepository.LoadByAddressCard(addressCard);

                addressCardLayouts.Add(addressCardLayout);
            }

            return mapper.Map<List<AddressCardLayoutViewModel>>(addressCardLayouts);
        }

        public void Register(AddressCardLayoutViewModel addressCardLayoutViewModel)
        {
            var addressCardLayout = mapper.Map<AddressCardLayout>(addressCardLayoutViewModel);

            addressCardLayoutRepository.Register(addressCardLayout);
        }

        public void Delete(AddressCard addressCard)
        {
            var addressCardLayout = addressCardLayoutRepository.LoadByAddressCard(addressCard);

            addressCardLayoutRepository.Delete(addressCardLayout);
        }

        public void InitializeData()
        {
            addressCardLayoutRepository.InitializeData();
        }
    }
}
