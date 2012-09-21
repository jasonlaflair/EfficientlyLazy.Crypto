using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Tests
{
    /// <summary>
    ///This is a test class for TripleDESEngine and is intended
    ///to contain all TripleDESEngine Unit Tests
    ///</summary>
    public class TripleDESEngineTests : RandomBase
    {
        [Fact]
        public void ConstructorString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            ICryptoEngine engine = new TripleDESEngine(key);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void ConstructorSecureString()
        {
            string clearText = GenerateClearText();

            SecureString key = ToSS(GeneratePassPhrase());

            ICryptoEngine engine = new TripleDESEngine(key);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void SetInitVectorString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void SetInitVectorSecureString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            SecureString init = ToSS(GenerateInitVector());

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void SetRandomSaltLength()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.Integer(4, 100);
            var maxSalt = (byte)DataGenerator.Integer(100, 250);

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void SetSaltString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.Integer(4, 100);
            var maxSalt = (byte)DataGenerator.Integer(100, 250);
            string saltKey = GenerateRandomSalt();

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void SetSaltSecureString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.Integer(4, 100);
            var maxSalt = (byte)DataGenerator.Integer(100, 250);
            SecureString saltKey = ToSS(GenerateRandomSalt());

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Theory]
        [InlineData(TripleDESKeySize.Key128Bit)]
        [InlineData(TripleDESKeySize.Key192Bit)]
        public void SetKeySize(TripleDESKeySize keySize)
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.Integer(4, 100);
            var maxSalt = (byte)DataGenerator.Integer(100, 250);
            string saltKey = GenerateRandomSalt();

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(keySize);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void SetPasswordIterations()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.Integer(4, 100);
            var maxSalt = (byte)DataGenerator.Integer(100, 250);
            string saltKey = GenerateRandomSalt();

            var iterations = (byte)DataGenerator.Integer(1, 10);

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(TripleDESKeySize.Key128Bit)
                .SetIterations(iterations);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Theory]
        //[InlineData(Encodings.None)] // TODO : ExpectedException = typeof(ArgumentNullException))]
        [InlineData(Encodings.ASCII)]
        [InlineData(Encodings.Unicode)]
        [InlineData(Encodings.UTF32)]
        [InlineData(Encodings.UTF7)]
        [InlineData(Encodings.UTF8)]
        public void SetEncoding(Encodings encodingType)
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

            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetEncoding(encoding);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Fact]
        public void InvalidDecryption()
        {
            string randomData = GenerateClearText();

            string fake = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomData));

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            ICryptoEngine engine = new TripleDESEngine(key)
                .SetInitVector(init);

            Assert.Throws<CryptographicException>(delegate
            {
                engine.Decrypt(fake);
            });
        }

        // TODO : FIX

        //[Fact]
        //[InlineData(null)] // TODO : ExpectedException = typeof(ArgumentNullException))]
        //[InlineData("123456789012345")] // TODO : ExpectedException = typeof(ArgumentOutOfRangeException))]
        //[InlineData("12345678901234567")] // TODO : ExpectedException = typeof(ArgumentOutOfRangeException))]
        //public void SetInitVectorStringInvalid(string invalidValue)
        //{
        //    string key = GeneratePassPhrase();

        //    ICryptoEngine engine = new TripleDESEngine(key)
        //        .SetInitVector(invalidValue);

        //    //Assert.Fail("Should never get here");
        //}

        //[Fact]
        //[InlineData(null)] // TODO : ExpectedException = typeof(ArgumentNullException))]
        //[InlineData("123456789012345")] // TODO : ExpectedException = typeof(ArgumentOutOfRangeException))]
        //[InlineData("12345678901234567")] // TODO : ExpectedException = typeof(ArgumentOutOfRangeException))]
        //public void SetInitVectorSecureStringInvalid(string invalidValue)
        //{
        //    string key = GeneratePassPhrase();

        //    SecureString invalidSecureString = string.IsNullOrEmpty(invalidValue) ? null : ToSS(invalidValue);

        //    ICryptoEngine engine = new TripleDESEngine(key)
        //        .SetInitVector(invalidSecureString);

        //    //Assert.Fail("Should never get here");
        //}

        [Theory]
        [InlineData(0, 20)]
        [InlineData(-1, 20)]
        [InlineData(10, 0)]
        [InlineData(10, -1)]
        [InlineData(15, 10)]
        public void SetRandomSaltLengthInvalid(int min, int max)
        {
            string key = GeneratePassPhrase();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ICryptoEngine engine = new TripleDESEngine(key)
                    .SetRandomSaltLength(min, max);
            });
        }

        [Fact]
        public void SetSaltStringInvalid()
        {
            string key = GeneratePassPhrase();
            string salt = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                ICryptoEngine engine = new TripleDESEngine(key)
                    .SetSalt(salt);
            });
        }

        [Fact]
        public void SetSaltSecureStringInvalid()
        {
            string key = GeneratePassPhrase();

            SecureString salt = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                ICryptoEngine engine = new TripleDESEngine(key)
                    .SetSalt(salt);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SetPasswordIterationsInvalid(int times)
        {
            string key = GeneratePassPhrase();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ICryptoEngine engine = new TripleDESEngine(key)
                    .SetIterations(times);
            });
        }
    }
}