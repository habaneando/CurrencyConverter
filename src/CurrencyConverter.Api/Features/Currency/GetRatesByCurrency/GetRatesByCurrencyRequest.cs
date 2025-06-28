using FastEndpoints;
using Refit;

namespace CurrencyConverter.Api;

internal sealed record GetRatesByCurrencyRequest()
{
    [Query("base")]
    public string @base { get; set; }
};
