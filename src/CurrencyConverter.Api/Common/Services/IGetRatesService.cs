using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface IGetRatesService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesAsync();
}
