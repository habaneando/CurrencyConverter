namespace CurrencyConverter.Application;

public interface IGetRatesByPeriodService
{
    [Get("/v1/{from}..{to}")]
    Task<PeriodCurrencyRates> GetRatesByPeriodAsync(string from, string to, [Query] string @base);
}
