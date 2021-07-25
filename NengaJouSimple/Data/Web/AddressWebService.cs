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

        public async Task<string> Search(string zipcode)
        {
            if (string.IsNullOrEmpty(zipcode) || zipcode.Length != 8)
            {
                return string.Empty;
            }

            try
            {
                var requestUri = $"https://zipcloud.ibsnet.co.jp/api/search?zipcode={zipcode}";

                var response = await HttpClient.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    System.Diagnostics.Debug.WriteLine(responseBody);

                    // Json serialize ignore cases is true.
                    var responseData = JsonSerializer.Deserialize<ZipCloudRoot>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    var address = responseData.Results?.FirstOrDefault();

                    if (address != null)
                    {
                        return $"{address.Address1}{address.Address2}{address.Address3}";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException || ex is JsonException)
                {
                    return string.Empty;
                }

                throw;
            }

            return string.Empty;
        }
    }
}
