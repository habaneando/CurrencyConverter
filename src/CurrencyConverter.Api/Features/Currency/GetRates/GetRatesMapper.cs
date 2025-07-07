namespace CurrencyConverter.Api;

internal sealed class GetRatesMapper : ResponseMapper<BaseResponse, GetRatesResponse>
{
    public BaseResponse FromEntity(GetRatesResponse getRatesResponse) =>
         new(getRatesResponse);
}
