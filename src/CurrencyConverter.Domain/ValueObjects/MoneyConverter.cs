namespace CurrencyConverter.Domain;

public class MoneyConverter : JsonConverter<Money>
{
    public override Money Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new ExpectedStartObjectTokenJsonException();

        decimal amount = 0;

        Currency currency = Currency.SAR;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                return Money.Create(amount, currency);

            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new ExpectedPropertyNameTokenJsonException();

            string propertyName = reader.GetString() ?? throw new InvalidOperationException("Property name cannot be null.");

            reader.Read();

            switch (propertyName)
            {
                case "amount":
                    amount = reader.GetDecimal();
                    break;
                case "currency":
                    currency = Enum.Parse<Currency>(propertyName, true);
                    break;
            }
        }

        throw new ExpectedEndObjectTokenJsonException();
    }

    public override void Write(Utf8JsonWriter writer, Money value, JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(writer);

        ArgumentNullException.ThrowIfNull(value);

        writer.WriteStartObject();

        writer.WriteNumber(nameof(Money.Amount).ToUpperInvariant(), value.Amount);

        writer.WriteString(nameof(Money.Currency).ToUpperInvariant(), value.Currency.ToString());

        writer.WriteEndObject();
    }
}
