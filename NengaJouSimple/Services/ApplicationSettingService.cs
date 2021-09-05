using AutoMapper;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Models.Settings;
using NengaJouSimple.ViewModels.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Services
{
    public class ApplicationSettingService
    {
        private readonly ApplicationSettingRepository applicationSettingRepository;

        private readonly IMapper mapper;

        public ApplicationSettingService(
            ApplicationSettingRepository applicationSettingRepository,
            IMapper mapper)
        {
            this.applicationSettingRepository = applicationSettingRepository;
            this.mapper = mapper;
        }

        public ApplicationSettingViewModel Load()
        {
            var applicationSetting = applicationSettingRepository.Load();

            return mapper.Map<ApplicationSettingViewModel>(applicationSetting);
        }

        public void Update(ApplicationSettingViewModel applicationSetting)
        {
            var requestApplicationSetting = mapper.Map<ApplicationSetting>(applicationSetting);

            applicationSettingRepository.Update(requestApplicationSetting);
        }

        public void InitializeData()
        {
            applicationSettingRepository.InitializeData();
        }
    }
}
