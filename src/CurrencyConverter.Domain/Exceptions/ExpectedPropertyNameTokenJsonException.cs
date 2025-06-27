namespace CurrencyConverter.Domain;

public class ExpectedPropertyNameTokenJsonException : JsonException
{
    public ExpectedPropertyNameTokenJsonException()
    {
    }

    public ExpectedPropertyNameTokenJsonException(string message) : base(message)
    {
    }

    public ExpectedPropertyNameTokenJsonException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
