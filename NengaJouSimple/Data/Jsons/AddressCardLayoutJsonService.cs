using NengaJouSimple.Data.Jsons.Entities;
using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace NengaJouSimple.Data.Jsons
{
    public class AddressCardLayoutJsonService
    {
        public const string AddressCardLayoutJsonFileName = @"AddressCardLayout.json";

        private static readonly string AddressCardLayoutJsonFilePath = Path.Combine(BaseDirectory.BaseDirectoryPath, AddressCardLayoutJsonFileName);


        public AddressCardLayoutJsonDTO ReadAddressCardLayoutJson()
        {
            if (!File.Exists(AddressCardLayoutJsonFilePath))
            {
                return null;
            }

            var jsonData = File.ReadAllText(AddressCardLayoutJsonFilePath);

            return JsonSerializer.Deserialize<AddressCardLayoutJsonDTO>(jsonData);
        }

        public void WriteAddressCardLayoutJson(AddressCardLayoutJsonDTO addressCardLayout)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonData = JsonSerializer.Serialize(addressCardLayout, options);

            File.WriteAllText(AddressCardLayoutJsonFilePath, jsonData);
        }
    }
}
