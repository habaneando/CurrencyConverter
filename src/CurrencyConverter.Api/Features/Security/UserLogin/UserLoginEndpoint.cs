using FastEndpoints;

namespace CurrencyConverter.Api;

public class UserLoginEndpoint(
    IAuthenticationService AuthenticationService,
    IJwtTokenGeneratorService JwtTokenGeneratorService,
    ThrottleSettings ThrottlingSettings)
    : Endpoint<UserLoginRequest>
{
    public override void Configure()
    {
        Post("/login");
        AllowAnonymous();
        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);
    }

    public override async Task HandleAsync(UserLoginRequest userLoginRequest, CancellationToken ct)
    {
        var user = await AuthenticationService
            .AuthenticateAsync(userLoginRequest.Username, userLoginRequest.Password, ct)
            .ConfigureAwait(false);

        if (user is null)
        {
            ThrowError("The supplied credentials are invalid!");
        }

        var claims = await AuthenticationService
            .GetUserClaimsAsync(user.Id, ct)
            .ConfigureAwait(false);

        var token = await JwtTokenGeneratorService.Generate(
            DateTime.UtcNow.AddHours(24),
            "your-issuer",
            "your-audience",
            "your-256-bit-secret-key",
            claims,
            ct)
            .ConfigureAwait(false);

        await SendAsync(
            new
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username,
                Roles = user.Roles
            })
            .ConfigureAwait(false);
    }
}
