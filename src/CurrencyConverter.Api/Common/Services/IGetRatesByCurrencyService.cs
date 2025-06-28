using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface IGetRatesByCurrencyService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesByCurrencyAsync([Query] string @base);
}
