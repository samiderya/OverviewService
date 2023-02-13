using Newtonsoft.Json;

namespace OverviewService.Models.Dtos
{
    public class ExchangeDto
    {
     
        [JsonProperty("year_established")]
        public int year { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("has_trading_incentive")]
        public bool Incentive { get; set; }

        [JsonProperty("trade_volume_24h_btc")]
        public decimal? Trade_volume_24h_btc { get; set; }
    }
}