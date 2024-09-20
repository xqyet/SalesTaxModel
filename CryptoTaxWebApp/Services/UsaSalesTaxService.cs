using System.Net.Http;
using System.Threading.Tasks;
using CryptoTaxWebApp.Models;
using Newtonsoft.Json;
using System;

namespace CryptoTaxWebApp.Services
{
    public class UsaSalesTaxService
    {
        private readonly string apiKey = "api-key-here";

        public async Task<UsaSalesTaxData?> GetSalesTaxDataAsync(string zipCode)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://u-s-a-sales-taxes-per-zip-code.p.rapidapi.com/{zipCode}"),
                Headers =
                {
                    { "x-rapidapi-key", apiKey },
                    { "x-rapidapi-host", "u-s-a-sales-taxes-per-zip-code.p.rapidapi.com" },
                },
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(body))
                    {
                        Console.WriteLine("No data received from the API.");
                        return null;
                    }

                    var taxData = JsonConvert.DeserializeObject<UsaSalesTaxData>(body);
                    return taxData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching API data: " + ex.Message);
                return null;
            }
        }
    }
}
