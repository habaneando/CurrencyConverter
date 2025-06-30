namespace CurrencyConverter.Api;

public class AuthorizationPolicyProvider : IAuthorizationPolicyProvider
{
    public List<AuthorizationPolicy> GetPolicies() => [
        new AuthorizationPolicy(
            CurrencyPolicy.Converter,
            policy =>
            {
                policy.RequireAuthenticatedUser()
                    .RequireRole(Role.Admin, Role.Manager)
                    .RequireClaim(
                        "Permission",
                        new List<string>
                        {
                            Permission.ViewCurrencies,
                            Permission.ViewRates,
                            Permission.ConvertCurrency
                        })
                    .RequireClaim(
                        "Scope",
                        new List<string>
                        {
                            Scope.Read,
                            Scope.Write,
                            Scope.Delete
                        });
            }),
        new AuthorizationPolicy(
            CurrencyPolicy.Reader,
            policy =>
            {
                policy.RequireAuthenticatedUser()
                    .RequireRole(Role.Admin, Role.Manager, Role.User)
                    .RequireClaim(
                        "Permission",
                        new List<string>
                        {
                            Permission.ViewCurrencies,
                            Permission.ViewRates
                        })
                    .RequireClaim(
                        "Scope",
                        new List<string>
                        {
                            Scope.Read
                        });
            })
        ];
}
