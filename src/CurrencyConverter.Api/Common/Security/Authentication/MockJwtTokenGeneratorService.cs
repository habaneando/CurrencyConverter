namespace CurrencyConverter.Api;

public class MockJwtTokenGeneratorService : IJwtTokenGeneratorService
{
    public Task<string> Generate(
        DateTime expireAt,
        string issuer,
        string audience,
        string signingKey,
        List<Claim> claims,
        CancellationToken ct)
    {
        //var signingKey2 = Encoding.UTF8.GetBytes("super-secret-signing-key-12343454354345363456543643563456");

        //var token = JwtBearer.CreateToken(o =>
        //{
        //    o.SigningKey = "super-secret-signing-key-12343454354345363456543643563456";
        //    o.SigningStyle = TokenSigningStyle.Symmetric;
        //    o.SigningAlgorithm = SecurityAlgorithms.HmacSha256;
        //});

        //return Task.FromResult( token);

        return Task.FromResult(
            "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2ODg3MjQ4MDAsImV4cCI6MTY4ODcyODQwMCwiaXNzIjoibXktaXNzdWVyIiwiYXVkIjoibXktYXVkaWVuY2UiLCJuYW1lIjoidGVzdHVzZXIiLCJwZXJtaXNzaW9ucyI6WyJDYW5SZWFkIl0sInJvbGVzIjpbIkFkbWluIl19.Yq-qlUQ7qzylShyIgEE10xsyLaCFP2uR6zHgWl7pSlxV8tvVQOi5TQ7b3C5OxqGCSzwK0b9MlGL7FnJ38Dz4mQnwu7pVngV6ZJrRkTv06L0qAzR9a1lOjDwlbF9Ks8Ow_Jd6QZrCW7aqNzZZoiWLqejyAwkSU6w2BTKuTzmKlwMDqFzs");
    }
}
