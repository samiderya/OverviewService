
using OverviewService.Models.Dtos;

namespace OverviewService.Clients
{
    public interface IOverviewClient
    {
        Task<List<ExchangeDto>?> GetExchange();
        Task<CountryDto> GetCountry(string countryCode);
        Task<List<CountryCodeDto>> GetCountryCode();

    }
}