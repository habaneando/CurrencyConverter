using Refit;

namespace CurrencyConverter.Application;

public interface IGetCurrenciesService
{
    [Get("/v1/currencies")]
    Task<Dictionary<string, string>> GetCurrenciesAsync();
}
