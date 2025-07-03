using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace CurrencyConverter.Api;

public static class RsaKeyGenerator
{
    /// <summary>
    /// Generates a new RSA key pair with specified key size.
    /// Returns a tuple of (privateKey, publicKey) as RsaSecurityKey.
    /// </summary>
    public static (RsaSecurityKey PrivateKey, RsaSecurityKey PublicKey) GenerateKeys(int keySize = 2048)
    {
        using var rsa = RSA.Create(keySize);

        // Export private key parameters
        var privateParameters = rsa.ExportParameters(true);
        var privateRsa = RSA.Create();
        privateRsa.ImportParameters(privateParameters);
        var privateKey = new RsaSecurityKey(privateRsa);

        // Export public key parameters
        var publicParameters = rsa.ExportParameters(false);
        var publicRsa = RSA.Create();
        publicRsa.ImportParameters(publicParameters);
        var publicKey = new RsaSecurityKey(publicRsa);

        return (privateKey, publicKey);
    }
}

