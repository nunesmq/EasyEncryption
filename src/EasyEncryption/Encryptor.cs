using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace EasyEncryption;

public sealed class Encryptor : IEncryptor
{
    private readonly string _key;

    public Encryptor(string key)
    {
        _key = key;
    }

    /// <summary>
    /// Encrypt a text.
    /// </summary>
    /// <param name="text">The text to encrypt.</param>
    /// <returns>The encrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public string? Encrypt(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key);
        var iv = Convert.ToBase64String(aes.IV);

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream();
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        using (var streamWriter = new StreamWriter(cryptoStream))
        {
            streamWriter.Write(text);
        }

        return iv + Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// Decrypt a text.
    /// </summary>
    /// <param name="text">The text to decrypt.</param>
    /// <returns>The decrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public string? Decrypt(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key);
        aes.IV = Convert.FromBase64String(text[..24]);

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(Convert.FromBase64String(text[24..]));
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        return streamReader.ReadToEnd();
    }

    /// <summary>
    /// Encrypt a text.
    /// </summary>
    /// <param name="text">The text to encrypt.</param>
    /// <returns>The encrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public async Task<string?> EncryptAsync(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key);
        var iv = Convert.ToBase64String(aes.IV);

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream();
        await using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        await using (var streamWriter = new StreamWriter(cryptoStream))
        {
            await streamWriter.WriteAsync(text);
        }

        return iv + Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// Decrypt a text.
    /// </summary>
    /// <param name="text">The text to decrypt.</param>
    /// <returns>The decrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public async Task<string?> DecryptAsync(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key);
        aes.IV = Convert.FromBase64String(text[..24]);

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(Convert.FromBase64String(text[24..]));
        await using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        return await streamReader.ReadToEndAsync();
    }

    /// <summary>
    /// Encrypt a text.
    /// </summary>
    /// <param name="text">The text to encrypt.</param>
    /// <param name="key">The encryption key.</param>
    /// <returns>The encrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public static string? Encrypt(string? text, string key)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        var iv = Convert.ToBase64String(aes.IV);

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream();
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        using (var streamWriter = new StreamWriter(cryptoStream)) streamWriter.Write(text);

        return iv + Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// Decrypt a text.
    /// </summary>
    /// <param name="text">The text to decrypt.</param>
    /// <param name="key">The encryption key.</param>
    /// <returns>The decrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public static string? Decrypt(string? text, string key)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Convert.FromBase64String(text[..24]);

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(Convert.FromBase64String(text[24..]));
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        return streamReader.ReadToEnd();
    }

    /// <summary>
    /// Encrypt a text.
    /// </summary>
    /// <param name="text">The text to encrypt.</param>
    /// <param name="key">The encryption key.</param>
    /// <returns>The encrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public static async Task<string?> EncryptAsync(string? text, string key)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        var iv = Convert.ToBase64String(aes.IV);

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream();
        await using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        await using (var streamWriter = new StreamWriter(cryptoStream))
        {
            await streamWriter.WriteAsync(text);
        }

        return iv + Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// Decrypt a text.
    /// </summary>
    /// <param name="text">The text to decrypt.</param>
    /// <param name="key">The encryption key.</param>
    /// <returns>The decrypted text.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public static async Task<string?> DecryptAsync(string? text, string key)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Convert.FromBase64String(text[..24]);

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(Convert.FromBase64String(text[24..]));
        await using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        return await streamReader.ReadToEndAsync();
    }
}