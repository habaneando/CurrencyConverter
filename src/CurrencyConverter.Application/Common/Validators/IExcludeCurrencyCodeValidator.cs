namespace CurrencyConverter.Application;

public interface IExcludeCurrencyCodeValidator 
{
    bool IsNotAllowed(string currency); 
}
