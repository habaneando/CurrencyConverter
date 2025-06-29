using System.Diagnostics;

namespace CurrencyConverter.Api;

public interface ICurrencyFactory
{
    public Dictionary<string, string> Create();

}
