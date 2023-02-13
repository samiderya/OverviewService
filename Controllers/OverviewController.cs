using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OverviewService.Models.Dtos;

namespace Overview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OverviewController : ControllerBase
    {
        // private readonly IOverviewClient _overviewClient;
        private readonly ILogger<OverviewController> _logger;
        private readonly IHttpClientFactory _httpFactory;
        private readonly HttpClient clientCountry;
        private readonly HttpClient clientExchange;


        public OverviewController(ILogger<OverviewController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpFactory = httpClientFactory;
            clientCountry = _httpFactory.CreateClient("countryClient");
            clientExchange = _httpFactory.CreateClient("exchangeClient");
        }

        [HttpGet(Name = "GetOverview")]
        public async Task<IActionResult> Get()
        {
            List<OverviewDto> lstOverview = new List<OverviewDto>();


            var httpResponseMessageExchange = await clientExchange.GetAsync("/Exchange");
            if (httpResponseMessageExchange.IsSuccessStatusCode)
            {
                List<ExchangeDto> lstExchange = await httpResponseMessageExchange.Content.ReadFromJsonAsync<List<ExchangeDto>>();

                var httpResponseMessageCountryCode = await clientCountry.GetAsync("/Country");
                if (httpResponseMessageCountryCode.IsSuccessStatusCode)
                {
                    var resultCountryCode =
                          await httpResponseMessageCountryCode.Content.ReadFromJsonAsync<List<CountryCodeDto>>();
                    //I am taking 100 country code for test, it will be slow to take the whole list, may we store in db
                    foreach (var item in resultCountryCode.Take(100))
                    {
                        var httpResponse = await clientCountry.GetAsync($"/Country/{item.CountryCode}");
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            ContinentCountryDto result = await httpResponse.Content.ReadFromJsonAsync<ContinentCountryDto>();
                            List<ExchangeDto> resExchange = lstExchange.Where(x => x.Country != null && result.Country.Contains(x.Country)).ToList();
                            var res = new OverviewDto()
                            {
                                Continent = result.Continent,
                                Country = new CountryDto()
                                {
                                    Country = result.Country,
                                    CountryCode = result.CountryCode
                                },
                                Exchange = resExchange
                            };
                            if (resExchange.Count > 0)
                                lstOverview.Add(res);
                        }

                    }
                }

            }
            return httpResponseMessageExchange is not null ? Ok(lstOverview) : NotFound();


            //     if (responseExchange == null)
            //     {
            //         response.DidError = false;
            //         response.ErrorMessage = "Data not found";
            //     }
            //     else
            //     {

            //         response.DidError = false;
            //         response.Model = res;
            //     }
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogError(ex, "Stopped program because of exception");
            //     response.DidError = true;
            //     response.ErrorMessage = "There was an internal error, please contact to technical support.";
            // }
            // return response.ToHttpResponse();
        }
    }
}