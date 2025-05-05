using Microsoft.Extensions.DependencyInjection;

namespace EasyEncryption;

public static class EasyEncryptionServiceCollectionExtensions
{
    /// <summary>
    /// Add EasyEncryption to the service collection as a implementation of <see cref="IEncryptor"/>
    /// </summary>
    /// <param name="services">The service collection to use.</param>
    /// <param name="encryptionKey">The encryption key.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddEasyEncryption(this IServiceCollection services, string encryptionKey)
        => services.AddSingleton<IEncryptor, Encryptor>(_ => new Encryptor(encryptionKey));
}