namespace CurrencyConverter.Api;

public sealed record BaseResponse (object Data, List<string> Errors)
{
    public BaseResponse(object Data)
        : this(Data, []) { }
}
