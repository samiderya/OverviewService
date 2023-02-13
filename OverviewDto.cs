namespace Overview
{
    public class OverviewDto
    {

        public CountryDto Country { get; set; }

        public List<ExchangeDto> Exchange { get; set; }
    }
    public class CountryDto
    {

        public string? countryCode { get; set; }
        public string? continent { get; set; }
        public string? country { get; set; }

    }
    public class ExchangeDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? Year { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        // public string Has_trading_incentive { get; set; }
        public int? Trust_score { get; set; }
        public int? Trust_score_rank { get; set; }
        public decimal? Trade_volume_24h_btc { get; set; }
        public decimal? Trade_volume_24h_btc_normalized { get; set; }


    }
}