using NengaJouSimple.Models.Layouts;
using NengaJouSimple.Models.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NengaJouSimple.Data.Jsons
{
    public class ApplicationSettingJsonService
    {
        public const string ApplicationSettingJsonFileName = @"ApplicationSetting.json";

        private static readonly string ApplicationSettingJsonFilePath = Path.Combine(BaseDirectory.BaseDirectoryPath, ApplicationSettingJsonFileName);

        public ApplicationSetting ReadApplicationSetting()
        {
            if (!File.Exists(ApplicationSettingJsonFilePath))
            {
                return null;
            }

            var jsonData = File.ReadAllText(ApplicationSettingJsonFilePath);

            return JsonSerializer.Deserialize<ApplicationSetting>(jsonData);
        }

        public void WriteApplicationSetting(ApplicationSetting applicationSetting)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonData = JsonSerializer.Serialize(applicationSetting, options);

            File.WriteAllText(ApplicationSettingJsonFilePath, jsonData);
        }
    }
}
