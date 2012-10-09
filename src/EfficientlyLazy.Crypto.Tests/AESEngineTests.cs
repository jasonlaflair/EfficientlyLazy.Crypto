﻿using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using EfficientlyLazy.Crypto.Engines;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Tests
{
    /// <summary>
    ///This is a test class for AESEngineTest and is intended
    ///to contain all AESEngineTest Unit Tests
    ///</summary>
    public class AESEngineTests : RandomBase
    {
        [Fact]
        public void ConstructorString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            ICryptoEngine engine = new AESEngine(key);

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

            ICryptoEngine engine = new AESEngine(key);

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

            ICryptoEngine engine = new AESEngine(key)
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

            ICryptoEngine engine = new AESEngine(key)
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

            var minSalt = (byte)DataGenerator.NextInteger(4, 100);
            var maxSalt = (byte)DataGenerator.NextInteger(100, 250);

            ICryptoEngine engine = new AESEngine(key)
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

            var minSalt = (byte)DataGenerator.NextInteger(4, 100);
            var maxSalt = (byte)DataGenerator.NextInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            ICryptoEngine engine = new AESEngine(key)
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

            var minSalt = (byte)DataGenerator.NextInteger(4, 100);
            var maxSalt = (byte)DataGenerator.NextInteger(100, 250);
            SecureString saltKey = ToSS(GenerateRandomSalt());

            ICryptoEngine engine = new AESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Theory]
        [InlineData(AESKeySize.Key128Bit)]
        //[InlineData(AESKeySize.Key192Bit)]
        //[InlineData(AESKeySize.Key256Bit)]
        public void SetKeySize(AESKeySize keySize)
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.NextInteger(4, 100);
            var maxSalt = (byte)DataGenerator.NextInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            ICryptoEngine engine = new AESEngine(key)
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

            var minSalt = (byte)DataGenerator.NextInteger(4, 100);
            var maxSalt = (byte)DataGenerator.NextInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            var iterations = (byte)DataGenerator.NextInteger(1, 10);

            ICryptoEngine engine = new AESEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(AESKeySize.Key256Bit)
                .SetIterations(iterations);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.NotEqual(clearText, encrypted);
            Assert.Equal(clearText, decrypted);
        }

        [Theory]
        //[InlineData(Encodings.None)] // TODO : ExpectedException = typeof(ArgumentNullException))]
        [InlineData(Encodings.ASCII)]
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
                case Encodings.UTF7:
                    encoding = Encoding.UTF7;
                    break;
                case Encodings.UTF8:
                    encoding = Encoding.UTF8;
                    break;
            }

            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            ICryptoEngine engine = new AESEngine(key)
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

            ICryptoEngine engine = new AESEngine(key)
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

        //    ICryptoEngine engine = new AESEngine(key)
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

        //    ICryptoEngine engine = new AESEngine(key)
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
                ICryptoEngine engine = new AESEngine(key)
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
                ICryptoEngine engine = new AESEngine(key)
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
                ICryptoEngine engine = new AESEngine(key)
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
                ICryptoEngine engine = new AESEngine(key)
                    .SetIterations(times);
            });
        }
    }
}