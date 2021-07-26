using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Data.Web;
using NengaJouSimple.Models;

namespace NengaJouSimple.Services
{
    public class SenderAddressCardService
    {
        private readonly SenderAddressCardRepository senderAddressCardRepository;

        private readonly SenderAddressCardCsvService senderAddressCardCsvService;

        private readonly AddressWebService addressWebService;

        private readonly IMapper mapper;

        public SenderAddressCardService(
            SenderAddressCardRepository senderAddressCardRepository,
            SenderAddressCardCsvService senderAddressCardCsvService,
            AddressWebService addressWebService,
            IMapper mapper)
        {
            this.senderAddressCardRepository = senderAddressCardRepository;
            this.senderAddressCardCsvService = senderAddressCardCsvService;
            this.addressWebService = addressWebService;
            this.mapper = mapper;
        }

        public List<ViewModels.Entities.SenderAddressCard> LoadAll()
        {
            var senderAddressCards = senderAddressCardRepository.LoadAll();

            return mapper.Map<List<ViewModels.Entities.SenderAddressCard>>(senderAddressCards);
        }

        public void Register(ViewModels.Entities.SenderAddressCard senderAddressCard)
        {
            var requestSenderAddressCard = mapper.Map<SenderAddressCard>(senderAddressCard);

            senderAddressCardRepository.Register(requestSenderAddressCard);

            WriteCsvFile();
        }

        public void Delete(ViewModels.Entities.SenderAddressCard senderAddressCard)
        {
            var requestSenderAddressCard = mapper.Map<SenderAddressCard>(senderAddressCard);

            senderAddressCardRepository.Delete(requestSenderAddressCard);

            WriteCsvFile();
        }

        public async Task<string> SearchAddressByPostalCode(string postalCode)
        {
            return await addressWebService.Search(postalCode);
        }

        public void ReadCsvFile()
        {
            var senderAddressCards = senderAddressCardCsvService.ReadAddressCardCsv();

            senderAddressCardRepository.AddRanges(senderAddressCards);
        }

        private void WriteCsvFile()
        {
            var allAddressCards = senderAddressCardRepository.LoadAll();

            senderAddressCardCsvService.WriteAddressCardCsv(allAddressCards);
        }
    }
}
