namespace CurrencyConverter.Api;

public interface ILogFormatter
{
    string Format(HttpContext httpContext);
}
