namespace CurrencyConverter.Application;

public interface IGetRatesByCurrencyService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesByCurrencyAsync([Query] string @base);
}
