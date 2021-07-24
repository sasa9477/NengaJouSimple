using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Models;

namespace NengaJouSimple.Services
{
    public class AddressCardService
    {
        private readonly AddressCardRepository addressCardRepository;

        private readonly IMapper mapper;

        public AddressCardService(AddressCardRepository addressCardRepository, IMapper mapper)
        {
            this.addressCardRepository = addressCardRepository;
            this.mapper = mapper;
        }

        public List<ViewModels.Entities.AddressCard> LoadAll()
        {
            var addressCards = addressCardRepository.LoadAll();

            return mapper.Map<List<ViewModels.Entities.AddressCard>>(addressCards);
        }

        public void Register(ViewModels.Entities.AddressCard addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            addressCardRepository.Register(requestAddressCard);
        }

        public void Delete(ViewModels.Entities.AddressCard addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            addressCardRepository.Delete(requestAddressCard);
        }
    }
}
