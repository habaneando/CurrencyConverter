namespace CurrencyConverter.Api;

public record AuthorizationPolicy(string Name, Action<AuthorizationPolicyBuilder> ConfigurePolicy);
