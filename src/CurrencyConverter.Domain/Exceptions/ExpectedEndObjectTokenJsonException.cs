namespace CurrencyConverter.Domain;

public class ExpectedEndObjectTokenJsonException: JsonException
{
    public ExpectedEndObjectTokenJsonException()
    {
    }

    public ExpectedEndObjectTokenJsonException(string message) : base(message)
    {
    }

    public ExpectedEndObjectTokenJsonException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
