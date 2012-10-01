using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using EfficientlyLazy.Crypto.Engines;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Tests
{
    /// <summary>
    ///This is a test class for DPAPIEngineTest and is intended
    ///to contain all DPAPIEngineTest Unit Tests
    ///</summary>
    public class DPAPIEngineTests : RandomBase
    {
        [Theory]
        [InlineData(DPAPIKeyType.UserKey)]
        [InlineData(DPAPIKeyType.MachineKey)]
        public void Constructor(DPAPIKeyType keyType)
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
        [InlineData(DPAPIKeyType.UserKey)]
        [InlineData(DPAPIKeyType.MachineKey)]
        public void SetEntropyString(DPAPIKeyType keyType)
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
        [InlineData(DPAPIKeyType.UserKey)]
        [InlineData(DPAPIKeyType.MachineKey)]
        public void SetEntropySecureString(DPAPIKeyType keyType)
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
        //[InlineData(DPAPIKeyType.UserKey, Encodings.None)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        [InlineData(DPAPIKeyType.UserKey, Encodings.ASCII)]
        [InlineData(DPAPIKeyType.UserKey, Encodings.Unicode)]
        [InlineData(DPAPIKeyType.UserKey, Encodings.UTF32)]
        [InlineData(DPAPIKeyType.UserKey, Encodings.UTF7)]
        [InlineData(DPAPIKeyType.UserKey, Encodings.UTF8)]
        //[InlineData(DPAPIKeyType.MachineKey, Encodings.None)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        [InlineData(DPAPIKeyType.MachineKey, Encodings.ASCII)]
        [InlineData(DPAPIKeyType.MachineKey, Encodings.Unicode)]
        [InlineData(DPAPIKeyType.MachineKey, Encodings.UTF32)]
        [InlineData(DPAPIKeyType.MachineKey, Encodings.UTF7)]
        [InlineData(DPAPIKeyType.MachineKey, Encodings.UTF8)]
        public void SetEncoding(DPAPIKeyType keyType, Encodings encodingType)
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
        [InlineData(DPAPIKeyType.UserKey)]
        [InlineData(DPAPIKeyType.MachineKey)]
        public void Failures(DPAPIKeyType keyType)
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