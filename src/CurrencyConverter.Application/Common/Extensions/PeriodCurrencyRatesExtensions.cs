namespace CurrencyConverter.Application;

internal static class PeriodCurrencyRatesExtensions
{
    public static PeriodCurrencyRates WithItemsForPage(this PeriodCurrencyRates periodCurrencyRates, int page)
    {
        var kvp = periodCurrencyRates.Rates.ToList();

        var kvpPaged = new PagedList<KeyValuePair<string, Dictionary<string, float>>>(kvp).GetItemsForPage(page);

        periodCurrencyRates = periodCurrencyRates with
        {
            Rates = new Dictionary<string, Dictionary<string, float>>(kvpPaged)
        };

        return periodCurrencyRates;
    }
}
