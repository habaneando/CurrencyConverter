namespace CurrencyConverter.Api;

internal sealed class ConvertCurrencyMapper : ResponseMapper<BaseResponse, ConvertCurrencyResponse>
{
    public BaseResponse FromEntity(ConvertCurrencyResponse convertCurrencyResponse) =>
        new(convertCurrencyResponse);
}
