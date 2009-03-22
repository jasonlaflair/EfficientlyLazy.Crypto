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

            ICryptoEngine engine = new RijndaelEngine(key);

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

            ICryptoEngine engine = new RijndaelEngine(key);

            engine.Encrypt(nullBytes);

            Assert.Fail("Shouldn't Get Here!");
        }

        [Test, Repeat(50)]
        public void Test1()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

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

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

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

            byte minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGenerator.RandomInteger(100, 250);

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt);

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

            byte minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey);

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

            byte minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            int mod = (int)(_repeater % 3);

            RijndaelKeySize keySize;

            if (mod == 0) keySize = RijndaelKeySize.Key128Bit;
            else if (mod == 1) keySize = RijndaelKeySize.Key192Bit;
            else keySize = RijndaelKeySize.Key256Bit;

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(keySize);

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

            byte minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            byte iterations = (byte)DataGenerator.RandomInteger(1, 10);

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(RijndaelKeySize.Key256Bit)
                .SetPasswordIterations(iterations);

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

            byte minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            byte maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            byte iterations = (byte)DataGenerator.RandomInteger(1, 10);

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(RijndaelKeySize.Key256Bit)
                .SetPasswordIterations(iterations);

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

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

            engine.Decrypt(fake);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void RijndaelEngine_FileEncryption()
        {
            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Encrypt(inputFile, outputFile);
        }

        [Test, ExpectedException(typeof(NotImplementedException))]
        public void RijndaelEngine_FileDecryption()
        {
            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            engine.Decrypt(inputFile, outputFile);
        }

        //[Test]
        //public void ParameterValidation_NULL()
        //{
        //    try
        //    {
        //        RijndaelEngine.ValidateParameters(null);
        //    }
        //    catch (InvalidRijndaelParameterException ex)
        //    {
        //        Assert.AreEqual("IRijndaelRarameters cannot be null", ex.Message);
        //        Assert.AreEqual(string.Empty, ex.InvalidProperty);

        //        return;
        //    }

        //    Assert.Fail("Shouldn't Get Here!!");
        //}

        [Test]
        public void ParameterValidation_BadInitVector_small()
        {
            try
            {
                new RijndaelEngine(string.Empty).SetInitVector("four");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("InitVector must be a length of 0 or 16\r\nParameter name: initVector", ex.Message);
                Assert.AreEqual("initVector", ex.ParamName);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_BadInitVector_null()
        {
            try
            {
                string iv = null;

                new RijndaelEngine(string.Empty).SetInitVector(iv);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("InitVector cannot be null\r\nParameter name: initVector", ex.Message);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvaidPasswordIterations()
        {
            try
            {
                new RijndaelEngine(string.Empty).SetPasswordIterations(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("iterations must be greater than 0\r\nParameter name: iterations\r\nActual value was 0.", ex.Message);
                Assert.AreEqual("iterations", ex.ParamName);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvalidSaltRange()
        {
            try
            {
                new RijndaelEngine(string.Empty).SetRandomSaltLength(20, 15);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("maximumLength (15) must be greater than or equal to minimumLength (20)\r\nParameter name: maximumLength", ex.Message);
                Assert.AreEqual("maximumLength", ex.ParamName);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvalidSaltMin()
        {
            try
            {
                new RijndaelEngine(string.Empty).SetRandomSaltLength(-1, 10);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("minimumLength must be greater than or equal to 0\r\nParameter name: minimumLength\r\nActual value was -1.", ex.Message);
                Assert.AreEqual("minimumLength", ex.ParamName);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_InvalidSaltMax()
        {
            try
            {
                new RijndaelEngine(string.Empty).SetRandomSaltLength(5, -1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("maximumLength must be greater than or equal to 0\r\nParameter name: maximumLength\r\nActual value was -1.", ex.Message);
                Assert.AreEqual("maximumLength", ex.ParamName);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }

        [Test]
        public void ParameterValidation_MissingEncoding()
        {
            try
            {
                new RijndaelEngine(string.Empty).SetEncoding(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("encoding cannot be null\r\nParameter name: encoding", ex.Message);
                Assert.AreEqual("encoding", ex.ParamName);

                return;
            }

            Assert.Fail("Shouldn't Get Here!!");
        }
    }
}