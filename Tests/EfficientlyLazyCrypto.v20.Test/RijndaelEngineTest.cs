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
    public class RijndaelEngineTest : RandomBase
    {
        [Test, Repeat(50)]
        public void Test()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            IRijndaelParameters parameters = RijndaelParameters.Create(key);

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

            string key = GeneratePassPhrase();

            IRijndaelParameters parameters = RijndaelParameters.Create(key);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            engine.Encrypt(nullBytes);

            Assert.Fail("Shouldn't Get Here!");
        }

        [Test, Repeat(50)]
        public void Test1()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test2()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test3()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test4()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSaltData(saltKey);

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

            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            int mod = (int)(_repeater % 3);

            RijndaelKeySize keySize;

            if (mod == 0) keySize = RijndaelKeySize.Key128Bit;
            else if (mod == 1) keySize = RijndaelKeySize.Key192Bit;
            else keySize = RijndaelKeySize.Key256Bit;

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSaltData(saltKey)
                .SetKeySize(keySize);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test6()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            byte iterations = (byte)DataGeneration.RandomInteger(1, 10);

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSaltData(saltKey)
                .SetKeySize(RijndaelKeySize.Key256Bit)
                .SetPasswordIterations(iterations);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50)]
        public void Test7()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            byte minSalt = (byte)DataGeneration.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGeneration.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            byte iterations = (byte)DataGeneration.RandomInteger(1, 10);

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSaltData(saltKey)
                .SetKeySize(RijndaelKeySize.Key256Bit)
                .SetPasswordIterations(iterations);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test, Repeat(50), ExpectedException(typeof(CryptographicException))]
        public void Test8()
        {
            string randomData = GenerateClearText();

            string fake = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomData));

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            engine.Decrypt(fake);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void RijndaelEngine_FileEncryption()
        {
            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Encrypt(inputFile, outputFile);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void RijndaelEngine_FileDecryption()
        {
            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            IRijndaelParameters parameters = RijndaelParameters.Create(key)
                .SetInitVector(init);

            ICryptoEngine engine = new RijndaelEngine(parameters);

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Decrypt(inputFile, outputFile);
        }

        [Test]
        public void ParameterValidation_NULL()
        {
            try
            {
                RijndaelEngine.ValidateParameters(null);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("IRijndaelRarameters cannot be null", ex.Message);
                Assert.AreEqual(string.Empty, ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_BadInitVector()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString("four")
                                                 };

            try
            {
                RijndaelEngine.ValidateParameters(parameters);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("InitVector must be a length of 0 or 16", ex.Message);
                Assert.AreEqual("InitVector", ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvaidPasswordIterations()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(string.Empty),
                                                     PasswordIterations = 0
                                                 };

            try
            {
            RijndaelEngine.ValidateParameters(parameters);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("PasswordIterations must be greater than 0", ex.Message);
                Assert.AreEqual("PasswordIterations", ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvalidSaltRange()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(string.Empty),
                                                     PasswordIterations = 1,
                                                     MinimumDataSaltLength = 20,
                                                     MaximumDataSaltLength = 15
                                                 };

            try
            {
            RijndaelEngine.ValidateParameters(parameters);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("MaximumDataSaltLength cannot be less than MinimumDataSaltLength", ex.Message);
                Assert.AreEqual(string.Empty, ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvalidSaltMin()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(string.Empty),
                                                     PasswordIterations = 1,
                                                     MinimumDataSaltLength =
                                                         (RijndaelParameters.MINIMUM_SET_SALT_LENGTH - 1),
                                                     MaximumDataSaltLength = 15
                                                 };

            try
            {
            RijndaelEngine.ValidateParameters(parameters);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("MinimumDataSaltLength cannot be smaller than 4", ex.Message);
                Assert.AreEqual("MinimumDataSaltLength", ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvalidSaltMax()
        {
            _RijndaelParameters parameters = new _RijndaelParameters
                                                 {
                                                     InitVector = DataConversion.ToSecureString(string.Empty),
                                                     PasswordIterations = 1,
                                                     MinimumDataSaltLength = RijndaelParameters.MINIMUM_SET_SALT_LENGTH,
                                                     MaximumDataSaltLength =
                                                         (RijndaelParameters.MAXIMUM_SET_SALT_LENGTH + 1)
                                                 };

            try
            {
                RijndaelEngine.ValidateParameters(parameters);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("MaximumDataSaltLength cannot be larger than 254", ex.Message);
                Assert.AreEqual("MaximumDataSaltLength", ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_MissingEncoding()
        {
            IRijndaelParameters parameters = RijndaelParameters.Create("sljfslkfas")
                .SetInitVector("1234567890123456")
                .SetRandomSaltLength(15, 30)
                .SetSaltData("sdlfjsldfsk")
                .SetKeySize(RijndaelKeySize.Key256Bit)
                .SetPasswordIterations(1)
                .SetEncoding(null);

            try
            {
                RijndaelEngine.ValidateParameters(parameters);
            }
            catch (InvalidRijndaelParameterException ex)
            {
                Assert.AreEqual("An Encoding must be defined", ex.Message);
                Assert.AreEqual("Encoding", ex.InvalidProperty);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
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
            public Encoding Encoding { get; set; }

            public IRijndaelParameters SetKey(SecureString key)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetKey(string key)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetInitVector(SecureString initVector)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetInitVector(string initVector)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetRandomSaltLength(byte min, byte max)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetSaltData(SecureString saltData)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetSaltData(string saltData)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetKeySize(RijndaelKeySize keySize)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetPasswordIterations(byte iterations)
            {
                throw new System.NotImplementedException();
            }

            public IRijndaelParameters SetEncoding(Encoding encoding)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}