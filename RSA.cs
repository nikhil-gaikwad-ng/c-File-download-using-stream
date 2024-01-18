using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.OpenSsl;
 
namespace UAEAttestation.API.Helper
{
    public class RSAHelper
    {
 
        private readonly RSACryptoServiceProvider PrivateKey;
        private readonly RSACryptoServiceProvider PublicKey;
        private readonly string privateKeyName = "private.key.pem";
        private readonly string PublicKeyName = "public.key.pem";
        private readonly string privateKeyPath = "RSA";
 
        public RSAHelper()
        {
            PrivateKey = GetPrivateKeyFromPemFile(privateKeyName);
            PublicKey = GetPublicKeyFromPemFile(PublicKeyName);
        }
 
        public string Decrypt(string encrypted)
        {
            var decryptedBytes = PrivateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }
        public string Encrypt(string text)
        {
            var encryptedBytes = PublicKey.Encrypt(Encoding.UTF8.GetBytes(text), false);
            return Convert.ToBase64String(encryptedBytes);
        }
 
        private RSACryptoServiceProvider GetPrivateKeyFromPemFile(string key)
        {
            using TextReader privateKeyStringReader = new StringReader(File.ReadAllText(GetPath(key, privateKeyPath)));
            AsymmetricCipherKeyPair pemReader = (AsymmetricCipherKeyPair)new PemReader(privateKeyStringReader).ReadObject();
            RSAParameters rsaPrivateCrtKeyParameters = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)pemReader.Private);
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            rsaCryptoServiceProvider.ImportParameters(rsaPrivateCrtKeyParameters);
            return rsaCryptoServiceProvider;
        }
 
        private RSACryptoServiceProvider GetPublicKeyFromPemFile(string key)
        {
            using TextReader publicKeyStringReader = new StringReader(File.ReadAllText(GetPath(key, privateKeyPath)));
            PemReader pemReader = new PemReader(publicKeyStringReader);
            AsymmetricKeyParameter keyPair = (AsymmetricKeyParameter)pemReader.ReadObject();
 
            if (keyPair is RsaKeyParameters rsaKeyParameters)
            {
                RSAParameters rsaParameters = DotNetUtilities.ToRSAParameters(rsaKeyParameters);
                RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
                rsaCryptoServiceProvider.ImportParameters(rsaParameters);
                return rsaCryptoServiceProvider;
            }
            else
            {
                throw new NotSupportedException("The provided PEM file does not contain an RSA public key.");
            }
        }
 
        private string GetPath(string fileName, string filePath)
        {
            var path = Path.Combine(".", filePath);
            return Path.Combine(path, fileName);
        }
    }
}