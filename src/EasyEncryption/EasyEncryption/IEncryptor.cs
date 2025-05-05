namespace EasyEncryption;

/// <summary>
/// Specifies a contract for a encryption service.
/// </summary>
public interface IEncryptor
{
    string? Encrypt(string? text);
    string? Decrypt(string? text);
    Task<string?> EncryptAsync(string? text);
    Task<string?> DecryptAsync(string? text);
}