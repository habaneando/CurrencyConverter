namespace CurrencyConverter.Application;

public interface IConvertCurrencyService : IRefitService
{
    [Get("/v1/latest")]
    Task<CurrencyRates> ConvertCurrencyAsync(
        [Query] string @base,
        [Query] string symbols,
        [Query] float amount);
}
