using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface ICurrencyRateService
{
    [Get("/v1/currencies")]
    Task<Dictionary<string, string>> GetCurrenciesAsync();

    [Get("/v1/latest")]
    Task<CurrencyRate> GetRatesAsync();

    [Get("/v1/latest")]
    Task<CurrencyRate> GetRatesByCurrencyAsync([Query] string @base);

    [Get("/v1/latest")]
    Task<CurrencyRate> ConvertCurrencyAsync([Query] string @base, [Query] string symbols, [Query] float amount);
}
