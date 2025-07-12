namespace CurrencyConverter.Domain;

public interface ICurrencyRepository
{
    Task<CurrencyInfo> GetCurrencyInfoAsync(string currencyCode);
}
