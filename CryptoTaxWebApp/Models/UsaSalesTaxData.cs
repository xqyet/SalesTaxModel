using Newtonsoft.Json;

namespace CryptoTaxWebApp.Models
{
    public class UsaSalesTaxData
    {
        [JsonProperty("state_rate")]
        public float StateTax { get; set; }

        [JsonProperty("estimated_county_rate")]
        public float CountyTax { get; set; }

        [JsonProperty("estimated_city_rate")]
        public float CityTax { get; set; }

        [JsonProperty("estimated_combined_rate")]
        public float TotalTax { get; set; }
    }
}
