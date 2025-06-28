using CurrencyConverter.Domain;
using Refit;

namespace CurrencyConverter.Api;

public interface IConvertCurrencyService
{
    [Get("/v1/latest")]
    Task<CurrencyRate> ConvertCurrencyAsync([Query] string @base, [Query] string symbols, [Query] float amount);
}
