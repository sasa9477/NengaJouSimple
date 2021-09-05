using AutoMapper;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.Models.Settings;
using NengaJouSimple.ViewModels.Entities.Layouts;
using System.Collections.Generic;
using System.Linq;

namespace NengaJouSimple.Services
{
    public class AddressCardLayoutService
    {
        private readonly ApplicationSettingRepository applicationSettingRepository;

        private readonly TextLayoutRepository textLayoutRepository;

        private readonly AddressCardRepository addressCardRepository;

        private readonly IMapper mapper;

        public AddressCardLayoutService(
            ApplicationSettingRepository applicationSettingRepository,
            TextLayoutRepository textLayoutRepository,
            AddressCardRepository addressCardRepository,
            IMapper mapper)
        {
            this.applicationSettingRepository = applicationSettingRepository;
            this.textLayoutRepository = textLayoutRepository;
            this.addressCardRepository = addressCardRepository;
            this.mapper = mapper;
        }

        public List<AddressCardLayoutViewModel> LoadAll()
        {
            var addressCards = addressCardRepository.LoadAllPrintTargets();

            var addressCardLayouts = new List<AddressCardLayout>();

            foreach (var addressCard in addressCards)
            {
                var applicationSetting = applicationSettingRepository.Load();

                var textLayouts = textLayoutRepository.LoadByAddressCard(addressCard);

                var addressCardLayout = new AddressCardLayout(applicationSetting, textLayouts, addressCard);

                addressCardLayouts.Add(addressCardLayout);
            }

            return mapper.Map<List<AddressCardLayoutViewModel>>(addressCardLayouts);
        }

        public void Register(AddressCardLayoutViewModel addressCardLayoutViewModel)
        {
            var addressCardLayout = mapper.Map<AddressCardLayout>(addressCardLayoutViewModel);

            var textLayouts = addressCardLayout.GetTextLayoutProperties();

            textLayoutRepository.Register(textLayouts);
        }

        public void Delete(AddressCard addressCard)
        {
            var textLayouts = textLayoutRepository.LoadByAddressCard(addressCard);

            textLayoutRepository.Delete(textLayouts);
        }

        public void InitializeData()
        {
            textLayoutRepository.InitializeData();
        }
    }
}
