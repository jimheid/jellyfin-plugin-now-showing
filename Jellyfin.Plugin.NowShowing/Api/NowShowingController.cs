using System;
using System.Security.Cryptography;
using System.Text;
using MediaBrowser.Common.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jellyfin.Plugin.NowShowing.Api;

/// <summary>
/// Provides the admin-only helper API used to encrypt generated static catalogs.
/// </summary>
[ApiController]
[Authorize(Policy = Policies.RequiresElevation)]
[Route("NowShowing")]
public sealed class NowShowingController : ControllerBase
{
    private const int Pbkdf2Iterations = 600_000;
    private const int SaltLength = 16;
    private const int IvLength = 12;
    private const int KeyLength = 32;
    private const int TagLength = 16;

    /// <summary>
    /// Encrypts catalog JSON using AES-256-GCM and a PBKDF2-HMAC-SHA256 password-derived key.
    /// The password is used for this request only and is never persisted.
    /// </summary>
    /// <param name="request">The password and catalog JSON to encrypt.</param>
    /// <returns>The encrypted payload and the parameters needed for browser-side decryption.</returns>
    [HttpPost("EncryptWebsite")]
    public ActionResult<WebsiteEncryptionResponse> EncryptWebsite([FromBody] WebsiteEncryptionRequest request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("A password is required.");
        }

        if (request.Password.Length < 8)
        {
            return BadRequest("Use a password of at least 8 characters.");
        }

        if (string.IsNullOrWhiteSpace(request.Payload))
        {
            return BadRequest("The catalog payload is empty.");
        }

        var salt = RandomNumberGenerator.GetBytes(SaltLength);
        var iv = RandomNumberGenerator.GetBytes(IvLength);
        var plaintext = Encoding.UTF8.GetBytes(request.Payload);
        var ciphertext = new byte[plaintext.Length];
        var tag = new byte[TagLength];
        byte[]? key = null;

        try
        {
            using var derive = new Rfc2898DeriveBytes(
                request.Password,
                salt,
                Pbkdf2Iterations,
                HashAlgorithmName.SHA256);

            key = derive.GetBytes(KeyLength);

            using (var aes = new AesGcm(key, TagLength))
            {
                aes.Encrypt(iv, plaintext, ciphertext, tag);
            }

            // Web Crypto expects the authentication tag appended to the ciphertext.
            var combined = new byte[ciphertext.Length + tag.Length];
            Buffer.BlockCopy(ciphertext, 0, combined, 0, ciphertext.Length);
            Buffer.BlockCopy(tag, 0, combined, ciphertext.Length, tag.Length);

            return Ok(new WebsiteEncryptionResponse
            {
                Version = 1,
                Algorithm = "AES-GCM",
                Kdf = "PBKDF2-HMAC-SHA256",
                Iterations = Pbkdf2Iterations,
                Salt = Convert.ToBase64String(salt),
                Iv = Convert.ToBase64String(iv),
                Data = Convert.ToBase64String(combined)
            });
        }
        finally
        {
            CryptographicOperations.ZeroMemory(plaintext);
            CryptographicOperations.ZeroMemory(ciphertext);
            CryptographicOperations.ZeroMemory(tag);
            if (key is not null)
            {
                CryptographicOperations.ZeroMemory(key);
            }
        }
    }
}

/// <summary>
/// Contains the password and catalog JSON supplied to the encryption endpoint.
/// </summary>
public sealed class WebsiteEncryptionRequest
{
    /// <summary>Gets or sets the publication password. It is never stored.</summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>Gets or sets the catalog JSON to encrypt.</summary>
    public string Payload { get; set; } = string.Empty;
}

/// <summary>
/// Contains the encrypted catalog payload and the parameters needed to decrypt it.
/// </summary>
public sealed class WebsiteEncryptionResponse
{
    /// <summary>Gets or sets the encrypted payload format version.</summary>
    public int Version { get; set; }

    /// <summary>Gets or sets the encryption algorithm name.</summary>
    public string Algorithm { get; set; } = string.Empty;

    /// <summary>Gets or sets the key-derivation function name.</summary>
    public string Kdf { get; set; } = string.Empty;

    /// <summary>Gets or sets the PBKDF2 iteration count.</summary>
    public int Iterations { get; set; }

    /// <summary>Gets or sets the Base64-encoded PBKDF2 salt.</summary>
    public string Salt { get; set; } = string.Empty;

    /// <summary>Gets or sets the Base64-encoded AES-GCM initialization vector.</summary>
    public string Iv { get; set; } = string.Empty;

    /// <summary>Gets or sets the Base64-encoded ciphertext with the authentication tag appended.</summary>
    public string Data { get; set; } = string.Empty;
}
