using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Test
{
    /// <summary>
    ///This is a test class for DPAPIEngineTest and is intended
    ///to contain all DPAPIEngineTest Unit Tests
    ///</summary>
    public class DPAPIEngineTests : RandomBase
    {
        [Theory]
        [InlineData(KeyType.UserKey)]
        [InlineData(KeyType.MachineKey)]
        public void Constructor(KeyType keyType)
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(keyType);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(plainText, encrypted);
            Assert.NotEqual(encrypted, decrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Theory]
        [InlineData(KeyType.UserKey)]
        [InlineData(KeyType.MachineKey)]
        public void SetEntropyString(KeyType keyType)
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(keyType)
                .SetEntropy("myEntropy");

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(plainText, encrypted);
            Assert.NotEqual(encrypted, decrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Theory]
        [InlineData(KeyType.UserKey)]
        [InlineData(KeyType.MachineKey)]
        public void SetEntropySecureString(KeyType keyType)
        {
            string plainText = GenerateClearText();

            var entropy = new SecureString();
            foreach (char ch in "myEntropy")
            {
                entropy.AppendChar(ch);
            }

            var engine = new DPAPIEngine(keyType)
                .SetEntropy(entropy);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(plainText, encrypted);
            Assert.NotEqual(encrypted, decrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Theory]
        //[InlineData(KeyType.UserKey, Encodings.None)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        [InlineData(KeyType.UserKey, Encodings.ASCII)]
        [InlineData(KeyType.UserKey, Encodings.Unicode)]
        [InlineData(KeyType.UserKey, Encodings.UTF32)]
        [InlineData(KeyType.UserKey, Encodings.UTF7)]
        [InlineData(KeyType.UserKey, Encodings.UTF8)]
        //[InlineData(KeyType.MachineKey, Encodings.None)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        [InlineData(KeyType.MachineKey, Encodings.ASCII)]
        [InlineData(KeyType.MachineKey, Encodings.Unicode)]
        [InlineData(KeyType.MachineKey, Encodings.UTF32)]
        [InlineData(KeyType.MachineKey, Encodings.UTF7)]
        [InlineData(KeyType.MachineKey, Encodings.UTF8)]
        public void SetEncoding(KeyType keyType, Encodings encodingType)
        {
            Encoding encoding = null;

            switch (encodingType)
            {
                    //case Encodings.None:
                case Encodings.ASCII :
                    encoding = Encoding.ASCII;
                    break;
                case Encodings.Unicode :
                    encoding = Encoding.Unicode;
                    break;
                case Encodings.UTF32 :
                    encoding = Encoding.UTF32;
                    break;
                case Encodings.UTF7 :
                    encoding = Encoding.UTF7;
                    break;
                case Encodings.UTF8 :
                    encoding = Encoding.UTF8;
                    break;
            }

            var engine = new DPAPIEngine(keyType)
                .SetEncoding(encoding);

            byte[] plainText = encoding.GetBytes(GenerateClearText());

            byte[] encrypted = engine.Encrypt(plainText);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(plainText, encrypted);
            Assert.NotEqual(encrypted, decrypted);
            Assert.Equal(plainText, decrypted);
        }

        [Theory]
        [InlineData(KeyType.UserKey)]
        [InlineData(KeyType.MachineKey)]
        public void Failures(KeyType keyType)
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(keyType);

            string badEncrypt = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

            Assert.Throws<CryptographicException>(() =>
            {
                engine.Decrypt(badEncrypt);
            });
        }
    }
}