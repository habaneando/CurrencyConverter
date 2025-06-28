using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface IGetRatesByCurrencyService
{
    [Get("/v1/latest")]
    Task<CurrencyRate> GetRatesByCurrencyAsync([Query] string @base);
}
