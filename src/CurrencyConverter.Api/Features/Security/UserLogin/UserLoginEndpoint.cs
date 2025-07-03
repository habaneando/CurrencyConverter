namespace CurrencyConverter.Api;

public class UserLoginEndpoint(
    IAuthenticationService AuthenticationService,
    IAuthorizationService AuthorizationService,
    IJwtTokenGeneratorService JwtTokenGeneratorService,
    ThrottleSettings ThrottlingSettings)
    : Endpoint<UserLoginRequest, UserLoginResponse>
{
    public override void Configure()
    {
        Post("/login");

        Group<ApiVersion1Group>();

        AllowAnonymous();

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(UserLoginRequest userLoginRequest, CancellationToken ct)
    {
        var user = await AuthenticationService
            .AuthenticateAsync(
                userLoginRequest.Username,
                userLoginRequest.Password,
                ct)
            .ConfigureAwait(false);

        if (user is null)
        {
            ThrowError("The supplied credentials are invalid!");
        }

        var claims = await AuthorizationService
            .GetUserClaimsAsync(user.Id, ct)
            .ConfigureAwait(false);

        var token = await JwtTokenGeneratorService.Generate(
            DateTime.UtcNow.AddHours(24),
            "mock-issuer",
            "mock-audience",
            "mock-signingKey",
            claims,
            ct)
            .ConfigureAwait(false);

        await SendAsync(
            new UserLoginResponse(
                Token: token,
                UserId: user.Id,
                Username: user.Username,
                Roles: user.Roles,
                Claims: claims
            ))
            .ConfigureAwait(false);
    }
}
