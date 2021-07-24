using NengaJouSimple.Data.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NengaJouSimple.Data.Web
{
    public class AddressWebService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private static readonly string PostCodeBaseUri = "https://zipcloud.ibsnet.co.jp/api/search";

        public async Task<string> Search(string zipcode)
        {
            if (string.IsNullOrEmpty(zipcode) || zipcode.Length != 8)
            {
                return string.Empty;
            }

            //TODO: catch Exception

//              catch (HttpRequestException e)

            var requestUri = PostCodeBaseUri + $"?zipcode={zipcode}";

            var response = await HttpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine(responseBody);

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var responseObject = JsonSerializer.Deserialize<ZipCloudRoot>(responseBody, jsonSerializerOptions);

                System.Diagnostics.Debug.WriteLine(responseObject);

                if (responseObject.IsSuccess)
                {
                    var address = responseObject.Results.First();

                    return $"{address.Address1}{address.Address2}{address.Address3}";
                }
            }

            return string.Empty;
        }
    }
}
