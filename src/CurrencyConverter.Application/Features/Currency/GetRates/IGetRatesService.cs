namespace CurrencyConverter.Application;

public interface IGetRatesService 
{
    [Get("/v1/latest")]
    Task<CurrencyRates> GetRatesAsync();
}
