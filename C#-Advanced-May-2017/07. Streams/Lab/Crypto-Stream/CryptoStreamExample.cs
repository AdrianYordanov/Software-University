using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class CryptoStreamExample
{
    private const string EncryptionKey = "ABCDEFGH";

    private const string FilePath = "../../encrypted.txt";

    private static string Decrypt(string key, string path)
    {
        var fileStream = new FileStream(path, FileMode.Open);
        using (fileStream)
        {
            var cryptoProvider =
                new DESCryptoServiceProvider { Key = Encoding.ASCII.GetBytes(key), IV = Encoding.ASCII.GetBytes(key) };
            var cryptoStream = new CryptoStream(fileStream, cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read);
            using (cryptoStream)
            {
                using (var reader = new StreamReader(cryptoStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }

    private static void Main()
    {
        SaveEncrypted("Hello world", EncryptionKey, FilePath);
        var result = Decrypt(EncryptionKey, FilePath);
        Console.WriteLine(result);
    }

    private static void SaveEncrypted(string text, string key, string path)
    {
        var destinationStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        using (destinationStream)
        {
            var cryptoProvider = new DESCryptoServiceProvider();
            cryptoProvider.Key = Encoding.ASCII.GetBytes(key);
            cryptoProvider.IV = Encoding.ASCII.GetBytes(key);
            var cryptoStream = new CryptoStream(
                destinationStream,
                cryptoProvider.CreateEncryptor(),
                CryptoStreamMode.Write);
            using (cryptoStream)
            {
                var data = Encoding.ASCII.GetBytes(text);
                cryptoStream.Write(data, 0, data.Length);
            }
        }
    }
}