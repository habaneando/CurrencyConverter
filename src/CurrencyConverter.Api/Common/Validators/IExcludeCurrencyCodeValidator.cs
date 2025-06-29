namespace CurrencyConverter.Api;

public interface IExcludeCurrencyCodeValidator 
{
    bool IsNotAllowed(string currency); 
}
