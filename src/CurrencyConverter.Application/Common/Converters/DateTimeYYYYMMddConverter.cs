using System.Globalization;
using System.Text.Json;

namespace CurrencyConverter.Application;

public class DateTimeYyyyMMddConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "yyyy-MM-dd";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        DateTime.ParseExact(reader.GetString(), DateFormat, CultureInfo.InvariantCulture);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
}
