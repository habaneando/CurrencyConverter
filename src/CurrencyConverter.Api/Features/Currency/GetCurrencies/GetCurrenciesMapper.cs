namespace CurrencyConverter.Api;

internal sealed class GetCurrenciesMapper : ResponseMapper<BaseResponse, GetCurrenciesResponse>
{
    public BaseResponse FromEntity(GetCurrenciesResponse getCurrenciesResponse) =>
        new(getCurrenciesResponse);
}
