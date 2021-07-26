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
    public class AddressCardService
    {
        private readonly AddressCardRepository addressCardRepository;

        private readonly AddressCardCsvService addressCardCsvService;

        private readonly AddressWebService addressWebService;

        private readonly IMapper mapper;

        public AddressCardService(
            AddressCardRepository addressCardRepository,
            AddressCardCsvService addressCardCsvService,
            AddressWebService addressWebService,
            IMapper mapper)
        {
            this.addressCardRepository = addressCardRepository;
            this.addressCardCsvService = addressCardCsvService;
            this.addressWebService = addressWebService;
            this.mapper = mapper;
        }

        public List<ViewModels.Entities.AddressCard> LoadAll()
        {
            var allAddressCards = addressCardRepository.LoadAll();

            return mapper.Map<List<ViewModels.Entities.AddressCard>>(allAddressCards);
        }

        public void Register(ViewModels.Entities.AddressCard addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            addressCardRepository.Register(requestAddressCard);

            WriteCsvFile();
        }

        public void Delete(ViewModels.Entities.AddressCard addressCard)
        {
            var requestAddressCard = mapper.Map<AddressCard>(addressCard);

            addressCardRepository.Delete(requestAddressCard);

            WriteCsvFile();
        }

        public async Task<string> SearchAddressByPostalCode(string postalCode)
        {
            return await addressWebService.Search(postalCode);
        }

        public void ReadCsvFile()
        {
            var addressCards = addressCardCsvService.ReadAddressCardCsv();

            addressCardRepository.AddRanges(addressCards);
        }

        private void WriteCsvFile()
        {
            var allAddressCards = addressCardRepository.LoadAll();

            addressCardCsvService.WriteAddressCardCsv(allAddressCards);
        }
    }
}
