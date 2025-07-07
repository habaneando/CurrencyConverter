namespace CurrencyConverter.Application;

public class BusinessValidationException : Exception
{
    public BusinessValidationException(string message) : base(message) { }
}
