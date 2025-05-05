# EasyEncryption
A .NET library to easily encrypt/decrypt texts.

## Usage

EasyEncryption comes with synchronous and asynchronous versions of the method Encrypt and Decrypt.


```csharp
var myText = "Hello World";
var mySecretKey = "MySecretKey";

var encryptedText = Encryptor.Encrypt(myText, mySecretKey);
var decryptedText = Encryptor.Decrypt(encryptedText, mySecretKey);

var encryptedTextAsync = await Encryptor.EncryptAsync(myText, mySecretKey);
var decryptedTextAsync = await Encryptor.DecryptAsync(encryptedText, mySecretKey);
```

EasyEncryption also supports dependency injection in web applications.

```csharp
builder.Services.AddEasyEncryption("MySecretKey");
```

```csharp
public class MyService
{
    private readonly IEncryptor _encryptor;
    
    public MyService(IEncryptor encryptor)
    {
        _encryptor = encryptor;
    }
    
    public void DoSomething()
    {
        var myText = "Hello World";
        var encryptedText = _encryptor.Encrypt(myText);
        var decryptedText = _encryptor.Decrypt(encryptedText);
    }
    
    public async Task DoSomethingAsync()
    {
        var myText = "Hello World";
        var encryptedText = await _encryptor.EncryptAsync(myText);
        var decryptedText = await _encryptor.DecryptAsync(encryptedText);
    }
}