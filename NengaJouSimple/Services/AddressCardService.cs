using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Data.Web;
using NengaJouSimple.Models;

namespace NengaJouSimple.Services
{
    public class AddressCardService
    {
        private readonly AddressCardRepository addressCardRepository;

        private readonly AddressWebService addressWebService;

        private readonly IMapper mapper;

        public AddressCardService(
            AddressCardRepository addressCardRepository,
            AddressWebService addressWebService,
            IMapper mapper)
        {
            this.addressCardRepository = addressCardRepository;
            this.addressWebService = addressWebService;
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

        public async Task<string> SearchAddressByPostalCode(string postalCode)
        {
            return await addressWebService.Search(postalCode);
        }
    }
}
