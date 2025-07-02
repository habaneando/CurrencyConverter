using OpenTelemetry;
using OpenTelemetry.Logs;

namespace CurrencyConverter.Api;

public class CustomLogProcessor : BaseProcessor<LogRecord>
{
    public override void OnEnd(LogRecord logRecord)
    {
    }
}
