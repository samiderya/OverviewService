namespace OverviewService.Models.Dtos
{
    public class OverviewDto
    {
        public string Continent { get; set; }
        public CountryDto Country { get; set; }
        public List<ExchangeDto> Exchange { get; set; }
    }

}