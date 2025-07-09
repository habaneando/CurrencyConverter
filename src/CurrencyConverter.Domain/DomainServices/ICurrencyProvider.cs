namespace CurrencyConverter.Domain;

public interface ICurrencyProvider
{
    CurrencyInfo GetCurrencyInfo(string currencyCode);
}
