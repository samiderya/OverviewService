using OverviewService.Models.Dtos;

namespace OverviewService.Clients
{
    public class OverviewClient : IOverviewClient
    {
        public Task<CountryDto> GetCountry(string countryCode)
        {
            return null;
        }

        public Task<List<CountryCodeDto>> GetCountryCode()
        {
            return null;
        }

        public Task<List<ExchangeDto>?> GetExchange()
        {
            return null;
        }
    }
}