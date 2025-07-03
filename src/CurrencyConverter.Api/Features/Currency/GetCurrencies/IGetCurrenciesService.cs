namespace CurrencyConverter.Api;

public interface IGetCurrenciesService : IRefitService
{
    [Get("/v1/currencies")]
    Task<Dictionary<string, string>> GetCurrenciesAsync();
}
