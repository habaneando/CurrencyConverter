namespace CurrencyConverter.Api;

public interface IExceptionFormatter
{
    string Format(Exception exception);
}
