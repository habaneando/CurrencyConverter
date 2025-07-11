namespace CurrencyConverter.Domain;

public interface ICurrencyProvider
{
    Task<CurrencyInfo> GetCurrencyInfo(string currencyCode);
}
