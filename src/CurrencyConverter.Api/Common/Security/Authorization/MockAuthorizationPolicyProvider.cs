namespace CurrencyConverter.Api;

public class MockAuthorizationPolicyProvider : IAuthorizationPolicyProvider
{
    public List<AuthorizationPolicy> GetPolicies() => [
        new AuthorizationPolicy(
            CurrencyPolicy.Converter,
            policy =>
            {
                policy.RequireAuthenticatedUser()
                    .RequireRole(Role.Admin.ToString(), Role.Manager.ToString())
                    .RequireClaim(
                        "Permission",
                        new List<string>
                        {
                            Permission.ViewCurrencies.ToString(),
                            Permission.ViewRates.ToString(),
                            Permission.ConvertCurrency.ToString()
                        })
                    .RequireClaim(
                        "Scope",
                        new List<string>
                        {
                            Scope.Read.ToString(),
                            Scope.Write.ToString(),
                            Scope.Delete.ToString()
                        });
            }),
        new AuthorizationPolicy(
            CurrencyPolicy.Reader,
            policy =>
            {
                policy.RequireAuthenticatedUser()
                    .RequireRole(Role.Admin.ToString(), Role.Manager.ToString(), Role.User.ToString())
                    .RequireClaim(
                        "Permission",
                        new List<string>
                        {
                            Permission.ViewCurrencies.ToString(),
                            Permission.ViewRates.ToString()
                        })
                    .RequireClaim(
                        "Scope",
                        new List<string>
                        {
                            Scope.Read.ToString()
                        });
            })
        ];
}
