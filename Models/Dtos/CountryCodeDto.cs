using Newtonsoft.Json;

namespace OverviewService.Models.Dtos
{
    public class CountryCodeDto
    {

        [JsonProperty("iso3")]
        public string CountryCode { get; set; }
    }
}