using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface ICurrencyRateService
{
    [Get("/v1/latest")]
    Task<CurrencyRate2> GetRatesAsync();

    //[Get("/rates/{currency}")]
    //Task<CurrencyRate2> GetRatesByCurrencyAsync(string currency);
}
