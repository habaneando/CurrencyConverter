namespace CurrencyConverter.Api;

public interface IGetRatesByPeriodService : IRefitService
{
    [Get("/v1/{from}..{to}")]
    Task<PeriodCurrencyRates> GetRatesByPeriodAsync(string from, string to, [Query] string @base);
}
