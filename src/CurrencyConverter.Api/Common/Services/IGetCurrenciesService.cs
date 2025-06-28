using Refit;

namespace CurrencyConverter.Api;

public interface IGetCurrenciesService
{
    [Get("/v1/currencies")]
    Task<Dictionary<string, string>> GetCurrenciesAsync();
}
