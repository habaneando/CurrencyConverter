namespace CurrencyConverter.Application;

public interface IExcludedCurrencyValidator 
{
    bool IsValid(string currencyCode); 
}
