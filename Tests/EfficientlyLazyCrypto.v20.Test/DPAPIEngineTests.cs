using System;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using MbUnit.Framework;
using Rhino.Mocks;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for DPAPIEngineTest and is intended
    ///to contain all DPAPIEngineTest Unit Tests
    ///</summary>
    [TestFixture]
    public class DPAPIEngineTests : RandomBase
    {
        [Test, Parallelizable]
        [Row(DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.MachineKey)]
        public void Constructor(DPAPIKeyType keyType)
        {
            string plainText = GenerateClearText();
            
            var engine = new DPAPIEngine(keyType);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Parallelizable]
        [Row(DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.MachineKey)]
        public void SetEntropyString(DPAPIKeyType keyType)
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(keyType)
                .SetEntropy("myEntropy");

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Parallelizable]
        [Row(DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.MachineKey)]
        public void SetEntropySecureString(DPAPIKeyType keyType)
        {
            string plainText = GenerateClearText();

            SecureString entropy = new SecureString();
            foreach (char ch in "myEntropy")
            {
                entropy.AppendChar(ch);
            }

            var engine = new DPAPIEngine(keyType)
                .SetEntropy(entropy);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        public enum Encodings
        {
            None,
            ASCII,
            Unicode,
            UTF32,
            UTF7,
            UTF8
        }

        [Test, Parallelizable]
        [Row(DPAPIKeyType.UserKey, Encodings.None, ExpectedException = typeof(ArgumentNullException))]
        [Row(DPAPIKeyType.UserKey, Encodings.ASCII)]
        [Row(DPAPIKeyType.UserKey, Encodings.Unicode)]
        [Row(DPAPIKeyType.UserKey, Encodings.UTF32)]
        [Row(DPAPIKeyType.UserKey, Encodings.UTF7)]
        [Row(DPAPIKeyType.UserKey, Encodings.UTF8)]
        [Row(DPAPIKeyType.MachineKey, Encodings.None, ExpectedException = typeof(ArgumentNullException))]
        [Row(DPAPIKeyType.MachineKey, Encodings.ASCII)]
        [Row(DPAPIKeyType.MachineKey, Encodings.Unicode)]
        [Row(DPAPIKeyType.MachineKey, Encodings.UTF32)]
        [Row(DPAPIKeyType.MachineKey, Encodings.UTF7)]
        [Row(DPAPIKeyType.MachineKey, Encodings.UTF8)]
        public void SetEncoding(DPAPIKeyType keyType, Encodings encodingType)
        {
            Encoding encoding = null;

            switch (encodingType)
            {
                //case Encodings.None:
                case Encodings.ASCII:
                    encoding = Encoding.ASCII;
                    break;
                case Encodings.Unicode:
                    encoding = Encoding.Unicode;
                    break;
                case Encodings.UTF32:
                    encoding = Encoding.UTF32;
                    break;
                case Encodings.UTF7:
                    encoding = Encoding.UTF7;
                    break;
                case Encodings.UTF8:
                    encoding = Encoding.UTF8;
                    break;
            }
            
            var engine = new DPAPIEngine(keyType)
                .SetEncoding(encoding);

            byte[] plainText = encoding.GetBytes(GenerateClearText());

            byte[] encrypted = engine.Encrypt(plainText);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Parallelizable]
        [Row(DPAPIKeyType.UserKey, DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.UserKey, DPAPIKeyType.MachineKey)]
        [Row(DPAPIKeyType.MachineKey, DPAPIKeyType.MachineKey)]
        [Row(DPAPIKeyType.MachineKey, DPAPIKeyType.UserKey)]
        public void SetKeyType(DPAPIKeyType firstKey, DPAPIKeyType secondKey)
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(firstKey);

            string firstEncrypted = engine.Encrypt(plainText);
            string firstDecrypted = engine.Decrypt(firstEncrypted);

            engine.SetKeyType(secondKey);
            string secondEncrypted = engine.Encrypt(plainText);
            string secondDecrypted = engine.Decrypt(secondEncrypted);

            Assert.AreNotEqual(plainText, firstEncrypted);
            Assert.AreNotEqual(firstEncrypted, firstDecrypted);
            Assert.AreEqual(plainText, firstDecrypted);

            Assert.AreNotEqual(plainText, secondEncrypted);
            Assert.AreNotEqual(secondEncrypted, secondDecrypted);
            Assert.AreEqual(plainText, secondDecrypted);

            if (firstKey != secondKey)
            {
                Assert.AreNotEqual(firstEncrypted, secondEncrypted);
            }
        }

        [Test, Parallelizable, ExpectedException(typeof(NotImplementedException))]
        [Row(DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.MachineKey)]
        public void EncryptFile(DPAPIKeyType keyType)
        {
            var engine = new DPAPIEngine(keyType);

            engine.Encrypt(string.Empty, string.Empty);
        }

        [Test, Parallelizable, ExpectedException(typeof(NotImplementedException))]
        [Row(DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.MachineKey)]
        public void DecryptFile(DPAPIKeyType keyType)
        {
            var engine = new DPAPIEngine(keyType);

            engine.Decrypt(string.Empty, string.Empty);
        }

        [Test, Parallelizable, ExpectedException(typeof(CryptographicException))]
        [Row(DPAPIKeyType.UserKey)]
        [Row(DPAPIKeyType.MachineKey)]
        public void Failures(DPAPIKeyType keyType)
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(keyType);

            string badEncrypt = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

            string decrypted = engine.Decrypt(badEncrypt);
        }
    }
}