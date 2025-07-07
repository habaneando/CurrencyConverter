namespace CurrencyConverter.Application;

public interface IGetRatesService : IRefitService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesAsync();
}
