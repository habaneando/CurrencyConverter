namespace CurrencyConverter.Domain;

public class ExpectedStartObjectTokenJsonException : JsonException
{
    public ExpectedStartObjectTokenJsonException()
    {
    }

    public ExpectedStartObjectTokenJsonException(string message) : base(message)
    {
    }

    public ExpectedStartObjectTokenJsonException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
