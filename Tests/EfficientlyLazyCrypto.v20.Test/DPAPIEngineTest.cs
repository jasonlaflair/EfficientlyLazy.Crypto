using System;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using MbUnit.Framework;
using EfficientlyLazyCrypto.DPAPINative;
using Rhino.Mocks;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for DPAPIEngineTest and is intended
    ///to contain all DPAPIEngineTest Unit Tests
    ///</summary>
    [TestFixture]
    public class DPAPIEngineTest
    {
        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_UserKey_NoEntropy()
        {
            string plainText = DataGeneration.RandomString(200, 500, true, true, true, true);
            
            var parameters = new DPAPIParameters(DPAPIKeyType.UserKey);

            var engine = new DPAPIEngine(parameters);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_UserKey_NoEntropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes( DataGeneration.RandomString(200, 500, true, true, true, true));

            var parameters = new DPAPIParameters(DPAPIKeyType.UserKey);

            var engine = new DPAPIEngine(parameters);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_MachineKey_NoEntropy()
        {
            string plainText = DataGeneration.RandomString(200, 500, true, true, true, true);

            var parameters = new DPAPIParameters(DPAPIKeyType.MachineKey);

            var engine = new DPAPIEngine(parameters);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_MachineKey_NoEntropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(DataGeneration.RandomString(200, 500, true, true, true, true));

            var parameters = new DPAPIParameters(DPAPIKeyType.MachineKey);

            var engine = new DPAPIEngine(parameters);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }


        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_UserKey_Entropy()
        {
            string plainText = DataGeneration.RandomString(200, 500, true, true, true, true);
            string entropy = DataGeneration.RandomString(100, 300, true, true, true, true);

            var parameters = new DPAPIParameters(DPAPIKeyType.UserKey, entropy);

            var engine = new DPAPIEngine(parameters);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_UserKey_Entropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(DataGeneration.RandomString(200, 500, true, true, true, true));
            string entropy = DataGeneration.RandomString(100, 300, true, true, true, true);

            var parameters = new DPAPIParameters(DPAPIKeyType.UserKey, entropy);

            var engine = new DPAPIEngine(parameters);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_String_MachineKey_Entropy()
        {
            string plainText = DataGeneration.RandomString(200, 500, true, true, true, true);
            string entropy = DataGeneration.RandomString(100, 300, true, true, true, true);

            var parameters = new DPAPIParameters(DPAPIKeyType.MachineKey, entropy);

            var engine = new DPAPIEngine(parameters);

            string encrypted = engine.Encrypt(plainText);

            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(plainText, encrypted);
            Assert.AreNotEqual(encrypted, decrypted);
            Assert.AreEqual(plainText, decrypted);
        }

        [Test, Repeat(50)]
        public void DPAPIEngine_EncryptTest_Byte_MachineKey_Entropy()
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(DataGeneration.RandomString(200, 500, true, true, true, true));
            string entropy = DataGeneration.RandomString(100, 300, true, true, true, true);

            var parameters = new DPAPIParameters(DPAPIKeyType.MachineKey, entropy);

            var engine = new DPAPIEngine(parameters);

            byte[] encrypted = engine.Encrypt(plainBytes);

            byte[] decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(encrypted));
            Assert.AreNotEqual(Encoding.UTF8.GetString(encrypted), Encoding.UTF8.GetString(decrypted));
            Assert.AreEqual(Encoding.UTF8.GetString(plainBytes), Encoding.UTF8.GetString(decrypted));
        }

        [Test, Repeat(50), ExpectedException(typeof(CryptographicException))]
        public void DPAPIEngine_DecryptFailureTest()
        {
            string entropy = DataGeneration.RandomString(100, 300, true, true, true, true);

            var parameters = new DPAPIParameters(DPAPIKeyType.MachineKey, entropy);

            var engine = new DPAPIEngine(parameters);

            string crap = Convert.ToBase64String(Encoding.UTF8.GetBytes("JasonLaFlair"));

            engine.Decrypt(crap);
        }

        private class InvalidDPAPIParameters_NonReadOnlyEntropy : IDPAPIParameters
        {
            private readonly SecureString _entropy = DataConversion.ToSecureString("JasonLaFlair");
            public SecureString Entropy
            {
                get { return _entropy; }
            }

            private const DPAPIKeyType _keyType = DPAPIKeyType.MachineKey;
            public DPAPIKeyType KeyType
            {
                get { return _keyType; }
            }
        }

        [Test, Repeat(50), ExpectedException(typeof(ArgumentException))]
        public void DPAPIEngine_NonReadOnlyEntropy()
        {
            new DPAPIEngine(new InvalidDPAPIParameters_NonReadOnlyEntropy());
        }

        [Test, Repeat(50), ExpectedArgumentNullException]
        public void DPAPIEngine_NullParameters()
        {
            new DPAPIEngine(null);
        }

        [Test, Repeat(50), ExpectedArgumentException]
        public void DPAPIEngine_NullEntropy()
        {
            SecureString ss = null;

            IDPAPIParameters parameters = new DPAPIParameters(DPAPIKeyType.UserKey, ss);

            new DPAPIEngine(parameters);
        }

        [Test, Repeat(50), ExpectedException(typeof(CryptographicException))]
        public void DPAPIEngine_EncryptionFailure()
        {
            var repository = new MockRepository();

            var INativeMethodsMock = repository.DynamicMock<INativeMethods>();

            var blob = DATA_BLOB.Null();
            var prompt = CRYPTPROTECT_PROMPTSTRUCT.Default();

            SetupResult.For(INativeMethodsMock.ProtectData(ref blob, string.Empty, ref blob, IntPtr.Zero, ref prompt, 0, ref blob))
                .IgnoreArguments().Throw(new ApplicationException("boom"));

            repository.ReplayAll();

            ICryptoEngine engine = new DPAPIEngine(new DPAPIParameters(DPAPIKeyType.UserKey, "key"), INativeMethodsMock);

            engine.Encrypt("crap");

        }

        [Test, Repeat(50), ExpectedException(typeof(CryptographicException))]
        public void DPAPIEngine_Encryption_ReturnFalse()
        {
            var repository = new MockRepository();

            var INativeMethodsMock = repository.DynamicMock<INativeMethods>();

            var blob = DATA_BLOB.Null();
            var prompt = CRYPTPROTECT_PROMPTSTRUCT.Default();

            SetupResult.For(INativeMethodsMock.ProtectData(ref blob, string.Empty, ref blob, IntPtr.Zero, ref prompt, 0, ref blob))
                .IgnoreArguments().Return(false);

            repository.ReplayAll();

            ICryptoEngine engine = new DPAPIEngine(new DPAPIParameters(DPAPIKeyType.UserKey, "key"), INativeMethodsMock);

            engine.Encrypt("crap");
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void DPAPIEngine_FileEncryption()
        {
            ICryptoEngine engine = new DPAPIEngine(new DPAPIParameters(DPAPIKeyType.UserKey, "key"));

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Encrypt(inputFile, outputFile);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void DPAPIEngine_FileDecryption()
        {
            ICryptoEngine engine = new DPAPIEngine(new DPAPIParameters(DPAPIKeyType.UserKey, "key"));

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Decrypt(inputFile, outputFile);
        }
    }
}