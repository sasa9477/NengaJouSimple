using NengaJouSimple.Data.Jsons;
using NengaJouSimple.Models.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Repositories
{
    public class ApplicationSettingRepository
    {
        private readonly ApplicationSettingJsonService applicationSettingJsonService;

        private ApplicationSetting applicationSetting;

        public ApplicationSettingRepository(ApplicationSettingJsonService applicationSettingJsonService)
        {
            this.applicationSettingJsonService = applicationSettingJsonService;
        }

        public ApplicationSetting Load()
        {
            return applicationSetting;
        }

        public void Update(ApplicationSetting applicationSetting)
        {
            applicationSettingJsonService.WriteApplicationSetting(applicationSetting);

            this.applicationSetting = applicationSettingJsonService.ReadApplicationSetting();
        }

        public void InitializeData()
        {
            applicationSetting = applicationSettingJsonService.ReadApplicationSetting();

            if (applicationSetting is null)
            {
                applicationSetting = new ApplicationSetting();
            }
        }
    }
}
