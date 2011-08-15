// // Copyright 2008-2009 LaFlair.NET
// // 
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// // 
// //     http://www.apache.org/licenses/LICENSE-2.0
// // 
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// 
namespace EfficientlyLazy.Crypto.Test
{
    using System;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;
    using MbUnit.Framework;

    /// <summary>
    ///This is a test class for RijndaelEngineTest and is intended
    ///to contain all RijndaelEngineTest Unit Tests
    ///</summary>
    [TestFixture]
    public class RijndaelEngineTests : RandomBase
    {
        [Test]
        [Repeat(50)]
        public void ConstructorString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            ICryptoEngine engine = new RijndaelEngine(key);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        public void ConstructorSecureString()
        {
            string clearText = GenerateClearText();

            SecureString key = ToSS(GeneratePassPhrase());

            ICryptoEngine engine = new RijndaelEngine(key);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        public void SetInitVectorString()
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

        [Test]
        [Repeat(50)]
        public void SetInitVectorSecureString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            SecureString init = ToSS(GenerateInitVector());

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        public void SetRandomSaltLength()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            var maxSalt = (byte)DataGenerator.RandomInteger(100, 250);

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        public void SetSaltString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            var maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
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

        [Test]
        [Repeat(50)]
        public void SetSaltSecureString()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            var maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            SecureString saltKey = ToSS(GenerateRandomSalt());

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        [Row(KeySize.Key128Bit)]
        [Row(KeySize.Key192Bit)]
        [Row(KeySize.Key256Bit)]
        public void SetKeySize(KeySize keySize)
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            var maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

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

        [Test]
        [Repeat(50)]
        public void SetPasswordIterations()
        {
            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            var minSalt = (byte)DataGenerator.RandomInteger(4, 100);
            var maxSalt = (byte)DataGenerator.RandomInteger(100, 250);
            string saltKey = GenerateRandomSalt();

            var iterations = (byte)DataGenerator.RandomInteger(1, 10);

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init)
                .SetRandomSaltLength(minSalt, maxSalt)
                .SetSalt(saltKey)
                .SetKeySize(KeySize.Key256Bit)
                .SetIterations(iterations);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        [Row(Encodings.None, ExpectedException = typeof (ArgumentNullException))]
        [Row(Encodings.ASCII)]
        [Row(Encodings.Unicode)]
        [Row(Encodings.UTF32)]
        [Row(Encodings.UTF7)]
        [Row(Encodings.UTF8)]
        public void SetEncoding(Encodings encodingType)
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

            string clearText = GenerateClearText();

            string key = GeneratePassPhrase();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetEncoding(encoding);

            string encrypted = engine.Encrypt(clearText);
            string decrypted = engine.Decrypt(encrypted);

            Assert.AreNotEqual(clearText, encrypted);
            Assert.AreEqual(clearText, decrypted);
        }

        [Test]
        [Repeat(50)]
        [ExpectedException(typeof (CryptographicException))]
        public void InvalidDecryption()
        {
            string randomData = GenerateClearText();

            string fake = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomData));

            string key = GeneratePassPhrase();
            string init = GenerateInitVector();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(init);

            engine.Decrypt(fake);

            Assert.Fail("Should never get here");
        }

        [Test]
        [Repeat(50)]
        [Row(null, ExpectedException = typeof (ArgumentNullException))]
        [Row("123456789012345", ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row("12345678901234567", ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void SetInitVectorStringInvalid(string invalidValue)
        {
            string key = GeneratePassPhrase();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(invalidValue);

            Assert.Fail("Should never get here");
        }

        [Test]
        [Repeat(50)]
        [Row(null, ExpectedException = typeof (ArgumentNullException))]
        [Row("123456789012345", ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row("12345678901234567", ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void SetInitVectorSecureStringInvalid(string invalidValue)
        {
            string key = GeneratePassPhrase();

            SecureString invalidSecureString = string.IsNullOrEmpty(invalidValue) ? null : ToSS(invalidValue);

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetInitVector(invalidSecureString);

            Assert.Fail("Should never get here");
        }

        [Test]
        [ExpectedArgumentOutOfRangeException]
        [Row(0, 20)]
        [Row(-1, 20)]
        [Row(10, 0)]
        [Row(10, -1)]
        [Row(15, 10)]
        public void SetRandomSaltLengthInvalid(int min, int max)
        {
            string key = GeneratePassPhrase();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetRandomSaltLength(min, max);

            Assert.Fail("Should never get here");
        }

        [Test]
        [Repeat(50)]
        [ExpectedArgumentNullException]
        public void SetSaltStringInvalid()
        {
            string key = GeneratePassPhrase();
            string salt = null;

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetSalt(salt);

            Assert.Fail("Should never get here");
        }

        [Test]
        [Repeat(50)]
        [ExpectedArgumentNullException]
        public void SetSaltSecureStringInvalid()
        {
            string key = GeneratePassPhrase();

            SecureString salt = null;

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetSalt(salt);

            Assert.Fail("Should never get here");
        }

        [Test]
        [Repeat(50)]
        [ExpectedArgumentOutOfRangeException]
        [Row(0)]
        [Row(-1)]
        public void SetPasswordIterationsInvalid(int times)
        {
            string key = GeneratePassPhrase();

            ICryptoEngine engine = new RijndaelEngine(key)
                .SetIterations(times);

            Assert.Fail("Should never get here");
        }
    }
}