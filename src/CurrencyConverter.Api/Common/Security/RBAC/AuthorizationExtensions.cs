namespace CurrencyConverter.Api;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(CurrencyPolicy.Converter, policy =>
            {
                policy
                    .RequireAuthenticatedUser()
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
            });

            options.AddPolicy(CurrencyPolicy.Reader, policy =>
            {
                policy
                    .RequireAuthenticatedUser()
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
            });
        });

        return services;
    }
}
