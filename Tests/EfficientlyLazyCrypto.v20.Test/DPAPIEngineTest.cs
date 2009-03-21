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
    public class DPAPIEngineTest : RandomBase
    {
        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_UserKey_NoEntropy()
        {
            string plainText = GenerateClearText();
            
            var engine = new DPAPIEngine(DPAPIKeyType.UserKey);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_UserKey_NoEntropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(GenerateClearText());

            var engine = new DPAPIEngine(DPAPIKeyType.UserKey);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_MachineKey_NoEntropy()
        {
            string plainText = GenerateClearText();

            var engine = new DPAPIEngine(DPAPIKeyType.MachineKey);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_MachineKey_NoEntropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(GenerateClearText());

            var engine = new DPAPIEngine(DPAPIKeyType.MachineKey);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }


        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_UserKey_Entropy()
        {
            string plainText = GenerateClearText();
            string entropy = GeneratePassPhrase();

            var engine = new DPAPIEngine(DPAPIKeyType.UserKey)
                .SetEntropy(entropy);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_UserKey_Entropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(GenerateClearText());
            string entropy = GeneratePassPhrase();

            var engine = new DPAPIEngine(DPAPIKeyType.UserKey)
                .SetEntropy(entropy);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_MachineKey_Entropy()
        {
            string plainText = GenerateClearText();
            string entropy = GeneratePassPhrase();

            var engine = new DPAPIEngine(DPAPIKeyType.MachineKey)
                .SetEntropy(entropy);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_MachineKey_Entropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(GenerateClearText());
            string entropy = GeneratePassPhrase();

            var engine = new DPAPIEngine(DPAPIKeyType.MachineKey)
                .SetEntropy(entropy);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }

        [Test, Repeat(50), ExpectedException(typeof(CryptographicException))]
        public void DPAPIEngine_DecryptFailureTest()
        {
            string entropy = GeneratePassPhrase();

            var engine = new DPAPIEngine(DPAPIKeyType.MachineKey)
                .SetEntropy(entropy);

            string crap = Convert.ToBase64String(Encoding.UTF8.GetBytes("JasonLaFlair"));

            engine.Decrypt(crap);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void DPAPIEngine_FileEncryption()
        {
            ICryptoEngine engine = new DPAPIEngine(DPAPIKeyType.UserKey)
                .SetEntropy("key");

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Encrypt(inputFile, outputFile);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void DPAPIEngine_FileDecryption()
        {
            ICryptoEngine engine = new DPAPIEngine(DPAPIKeyType.UserKey)
                .SetEntropy("key");

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Decrypt(inputFile, outputFile);
        }
    }
}