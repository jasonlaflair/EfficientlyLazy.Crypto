using System;
using System.Security;
using System.Security.Cryptography;
using MbUnit.Framework;
using System.Text;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for RijndaelEngineTest and is intended
    ///to contain all RijndaelEngineTest Unit Tests
    ///</summary>
    [TestFixture]
    public class RijndaelEngineTest
    {
        [Test, Repeat(50)]
        public void Test()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, ExpectedException(typeof(CryptographicException))]
        public void Test0()
        {
            byte[] nullBytes = null;

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            engine.Encrypt(nullBytes);

            Assert.Fail("Shouldn't Get Here!");
        }

        [Test, Repeat(50)]
        public void Test1()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key, init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test2()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key, init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test3()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);

            IRijndaelParameters parameters = new RijndaelParameters(key, init, minSalt, maxSalt);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test4()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = DataGeneration.RandomString(50, 100, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key, init, minSalt, maxSalt, saltKey);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        private static long _repeater;

        [Test, Repeat(50)]
        public void Test5()
        {
            _repeater++;

            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = DataGeneration.RandomString(50, 100, true, true, true, true);

            int mod = (int)(_repeater % 3);

            RijndaelKeySize keySize;

            if (mod == 0) keySize = RijndaelKeySize.Key128Bit;
            else if (mod == 1) keySize = RijndaelKeySize.Key192Bit;
            else keySize = RijndaelKeySize.Key256Bit;

            IRijndaelParameters parameters = new RijndaelParameters(key, init, minSalt, maxSalt, saltKey, keySize);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test6()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = DataGeneration.RandomString(50, 100, true, true, true, true);

            byte iterations = (byte)DataGeneration.RandomInteger(1, 10);

            IRijndaelParameters parameters = new RijndaelParameters(key, init, minSalt, maxSalt, saltKey, RijndaelKeySize.Key256Bit, iterations);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test7()
        {
            string clearText = DataGeneration.RandomString(25, 75, true, true, true, true);

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = DataGeneration.RandomString(50, 100, true, true, true, true);

            byte iterations = (byte)DataGeneration.RandomInteger(1, 10);

            IRijndaelParameters parameters = new RijndaelParameters(key, init, minSalt, maxSalt, saltKey, RijndaelKeySize.Key256Bit, iterations);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50), ExpectedException(typeof(CryptographicException))]
        public void Test8()
        {
            string randomData = DataGeneration.RandomString(25, 75, true, true, true, true);

            string fake = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomData));

            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key, init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            engine.Decrypt(fake);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void RijndaelEngine_FileEncryption()
        {
            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key, init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Encrypt(inputFile, outputFile);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void RijndaelEngine_FileDecryption()
        {
            string key = DataGeneration.RandomString(50, 220, true, true, true, true);
            string init = DataGeneration.RandomString(16, 16, true, true, true, true);

            IRijndaelParameters parameters = new RijndaelParameters(key, init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Decrypt(inputFile, outputFile);
        }

        [Test, ExpectedArgumentNullException]
        public void ParameterValidation_NULL()
        {
            ICryptoEngine engine = new RijndaelEngine(null);
        }

        [Test, ExpectedArgumentOutOfRangeException]
        public void ParameterValidation_BadInitVector()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString("four")
                                                 };

            ICryptoEngine engine = new RijndaelEngine(parameters);
        }

        [Test, ExpectedArgumentOutOfRangeException]
        public void ParameterValidation_InvaidPasswordIterations()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(""),
                                                     PasswordIterations = 0
                                                 };

            ICryptoEngine engine = new RijndaelEngine(parameters);
        }

        [Test, ExpectedArgumentOutOfRangeException]
        public void ParameterValidation_InvalidSaltRange()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(""),
                                                     PasswordIterations = 1,
                                                     MinimumDataSaltLength = 20,
                                                     MaximumDataSaltLength = 15
                                                 };

            ICryptoEngine engine = new RijndaelEngine(parameters);
        }

        [Test, ExpectedArgumentOutOfRangeException]
        public void ParameterValidation_InvalidSaltMin()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(""),
                                                     PasswordIterations = 1,
                                                     MinimumDataSaltLength =
                                                         ((byte) (RijndaelParameters.MINIMUM_SET_SALT_LENGTH - 1)),
                                                     MaximumDataSaltLength = 15
                                                 };

            ICryptoEngine engine = new RijndaelEngine(parameters);
        }

        [Test, ExpectedArgumentOutOfRangeException]
        public void ParameterValidation_InvalidSaltMax()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(""),
                                                     PasswordIterations = 1,
                                                     MinimumDataSaltLength = RijndaelParameters.MINIMUM_SET_SALT_LENGTH,
                                                     MaximumDataSaltLength =
                                                         ((byte) (RijndaelParameters.MAXIMUM_SET_SALT_LENGTH + 1))
                                                 };

            ICryptoEngine engine = new RijndaelEngine(parameters);
        }

        private class _RijndaelParameters : IRijndaelParameters
        {
            public SecureString Key { get; set; }
            public SecureString InitVector { get; set; }
            public byte MinimumDataSaltLength { get; set; }
            public byte MaximumDataSaltLength { get; set; }
            public SecureString EncryptionKeySalt { get; set; }
            public RijndaelKeySize KeySize { get; set; }
            public byte PasswordIterations { get; set; }
            public Encoding TextEncoding { get; set; }
        }
    }
}