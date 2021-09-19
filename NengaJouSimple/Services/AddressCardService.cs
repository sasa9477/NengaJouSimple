using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Data.Web;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.ViewModels.Entities.Addresses;

namespace NengaJouSimple.Services
{
    public class AddressCardService
    {
        private readonly AddressCardRepository addressCardRepository;

        private readonly AddressWebService addressWebService;

        private readonly AddressCardLayoutService addressCardLayoutService;

        private readonly IMapper mapper;

        public AddressCardService(
            AddressCardRepository addressCardRepository,
            AddressWebService addressWebService,
            AddressCardLayoutService addressCardLayoutService,
            IMapper mapper)
        {
            this.addressCardRepository = addressCardRepository;
            this.addressWebService = addressWebService;
            this.addressCardLayoutService = addressCardLayoutService;
            this.mapper = mapper;
        }

        public List<AddressCardViewModel> LoadAll()
        {
            var allAddressCards = addressCardRepository.LoadAll();

            return mapper.Map<List<AddressCardViewModel>>(allAddressCards);
        }

        public void Register(AddressCardViewModel addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            addressCardRepository.Register(requestAddressCard);
        }

        public void UpdatePrintDateTime(AddressCardViewModel addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            requestAddressCard.PrintedDateTime = DateTime.Now;

            addressCardRepository.Register(requestAddressCard);
        }

        public void Delete(AddressCardViewModel addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            addressCardLayoutService.Delete(requestAddressCard);

            addressCardRepository.Delete(requestAddressCard);
        }

        public bool IsRegisterdAnyAddressCard()
        {
            return addressCardRepository.IsRegisterAnyAddressCard();
        }

        public void InitializeData()
        {
            addressCardRepository.InitializeData();
        }

        public async Task<string> SearchAddressByPostalCode(string postalCode)
        {
            return await addressWebService.Search(postalCode);
        }
    }
}
