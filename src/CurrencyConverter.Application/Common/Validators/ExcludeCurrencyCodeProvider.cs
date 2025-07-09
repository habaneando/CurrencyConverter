namespace CurrencyConverter.Application;

public class ExcludedCurrencyProvider(ICurrencyProvider CurrencyProvider)
    : IExcludedCurrencyProvider
{
    public List<CurrencyInfo> Currencies =>
        new List<CurrencyInfo>
        {
            CurrencyProvider.GetCurrencyInfo("TRY").GetAwaiter().GetResult(),
            CurrencyProvider.GetCurrencyInfo("PLN").GetAwaiter().GetResult(),
            CurrencyProvider.GetCurrencyInfo("THB").GetAwaiter().GetResult(),
            CurrencyProvider.GetCurrencyInfo("MXN").GetAwaiter().GetResult()
        };
}
