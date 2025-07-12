namespace CurrencyConverter.Application;

public class ExcludedCurrencyProvider(ICurrencyRepository CurrencyRepository)
    : IExcludedCurrencyProvider
{
    public List<CurrencyInfo> Currencies =>
        new List<CurrencyInfo>
        {
            CurrencyRepository.GetCurrencyInfoAsync("TRY").GetAwaiter().GetResult(),
            CurrencyRepository.GetCurrencyInfoAsync("PLN").GetAwaiter().GetResult(),
            CurrencyRepository.GetCurrencyInfoAsync("THB").GetAwaiter().GetResult(),
            CurrencyRepository.GetCurrencyInfoAsync("MXN").GetAwaiter().GetResult()
        };
}
