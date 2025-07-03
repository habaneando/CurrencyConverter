namespace CurrencyConverter.Api;

public interface IGetRatesByCurrencyService : IRefitService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesByCurrencyAsync([Query] string @base);
}
