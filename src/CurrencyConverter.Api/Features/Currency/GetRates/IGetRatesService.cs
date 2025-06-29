using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface IGetRatesService : IRefitService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesAsync();
}
