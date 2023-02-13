using Newtonsoft.Json;

namespace OverviewService.Models.Dtos
{
    public class ContinentCountryDto
    {

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("iso3")]
        public string CountryCode { get; set; }

    }
    public class CountryDto
    {

        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("iso3")]
        public string CountryCode { get; set; }

    }
}