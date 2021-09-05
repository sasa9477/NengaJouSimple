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
    public class SenderAddressCardService
    {
        private readonly SenderAddressCardRepository senderAddressCardRepository;

        private readonly AddressWebService addressWebService;

        private readonly IMapper mapper;

        public SenderAddressCardService(
            SenderAddressCardRepository senderAddressCardRepository,
            AddressWebService addressWebService,
            IMapper mapper)
        {
            this.senderAddressCardRepository = senderAddressCardRepository;
            this.addressWebService = addressWebService;
            this.mapper = mapper;
        }

        public List<SenderAddressCardViewModel> LoadAll()
        {
            var senderAddressCards = senderAddressCardRepository.LoadAll();

            return mapper.Map<List<SenderAddressCardViewModel>>(senderAddressCards);
        }

        public void Register(SenderAddressCardViewModel senderAddressCard)
        {
            var requestSenderAddressCard = mapper.Map<SenderAddressCard>(senderAddressCard);

            senderAddressCardRepository.Register(requestSenderAddressCard);
        }

        public void Delete(SenderAddressCardViewModel senderAddressCard)
        {
            var requestSenderAddressCard = mapper.Map<SenderAddressCard>(senderAddressCard);

            senderAddressCardRepository.Delete(requestSenderAddressCard);
        }

        public bool IsRegisterdAnySenderAddressCard()
        {
            return senderAddressCardRepository.IsRegisterdAnySenderAddressCard();
        }

        public void InitializeData()
        {
            senderAddressCardRepository.InitializeData();
        }

        public async Task<string> SearchAddressByPostalCode(string postalCode)
        {
            return await addressWebService.Search(postalCode);
        }
    }
}
