using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for RijndaelParametersTest and is intended
    ///to contain all RijndaelParametersTest Unit Tests
    ///</summary>
    [TestFixture]
    public class RijndaelParametersTest
    {
        [Test]
        public void RijndaelParametersTest_PassPhrase()
        {
            string passPhrase = DataGeneration.RandomString(100, 500, true, true, true, true);

            var parameters = RijndaelParameters.Create(passPhrase);

            Assert.AreEqual(passPhrase, DataConversion.ToString(parameters.Key));
            Assert.IsTrue(parameters.Key.IsReadOnly());
        }

        [Test]
        public void RijndaelParametersTest_InitVector()
        {
            string passPhrase = DataGeneration.RandomString(100, 500, true, true, true, true);
            string initVector = DataGeneration.RandomString(16, 16, true, true, true, true);

            var parameters = RijndaelParameters.Create(passPhrase)
                .SetInitVector(initVector);

            Assert.AreEqual(passPhrase, DataConversion.ToString(parameters.Key));
            Assert.IsTrue(parameters.Key.IsReadOnly());

            Assert.AreEqual(initVector, DataConversion.ToString(parameters.InitVector));
            Assert.IsTrue(parameters.InitVector.IsReadOnly());
        }

        [Test]
        public void RijndaelParametersTest_Salt()
        {
            string passPhrase = DataGeneration.RandomString(100, 500, true, true, true, true);
            string initVector = DataGeneration.RandomString(16, 16, true, true, true, true);


            var saltMin = (byte)DataGeneration.RandomInteger(10, 50);
            var saltMax = (byte)DataGeneration.RandomInteger(100, 150);

            var parameters = RijndaelParameters.Create(passPhrase)
                .SetInitVector(initVector)
                .SetRandomSaltLength(saltMin, saltMax);

            Assert.AreEqual(passPhrase, DataConversion.ToString(parameters.Key));
            Assert.IsTrue(parameters.Key.IsReadOnly());

            Assert.AreEqual(initVector, DataConversion.ToString(parameters.InitVector));
            Assert.IsTrue(parameters.InitVector.IsReadOnly());

            Assert.AreEqual(saltMin, parameters.MinimumDataSaltLength);
            Assert.AreEqual(saltMax, parameters.MaximumDataSaltLength);
        }

        [Test]
        public void RijndaelParametersTest_Salt_Key()
        {
            string passPhrase = DataGeneration.RandomString(100, 500, true, true, true, true);
            string initVector = DataGeneration.RandomString(16, 16, true, true, true, true);


            var saltMin = (byte)DataGeneration.RandomInteger(10, 50);
            var saltMax = (byte)DataGeneration.RandomInteger(100, 150);

            string encryptionKeySalt = DataGeneration.RandomString(50, 200, true, true, true, true);

            var parameters = RijndaelParameters.Create(passPhrase)
                .SetInitVector(initVector)
                .SetRandomSaltLength(saltMin, saltMax)
                .SetSaltData(encryptionKeySalt);

            Assert.AreEqual(passPhrase, DataConversion.ToString(parameters.Key));
            Assert.IsTrue(parameters.Key.IsReadOnly());

            Assert.AreEqual(initVector, DataConversion.ToString(parameters.InitVector));
            Assert.IsTrue(parameters.InitVector.IsReadOnly());

            Assert.AreEqual(saltMin, parameters.MinimumDataSaltLength);
            Assert.AreEqual(saltMax, parameters.MaximumDataSaltLength);

            Assert.AreEqual(encryptionKeySalt, DataConversion.ToString(parameters.EncryptionKeySalt));
            Assert.IsTrue(parameters.EncryptionKeySalt.IsReadOnly());
        }

        [Test]
        public void RijndaelParametersTest_KeySize()
        {
            string passPhrase = DataGeneration.RandomString(100, 500, true, true, true, true);
            string initVector = DataGeneration.RandomString(16, 16, true, true, true, true);

            var saltMin = (byte)DataGeneration.RandomInteger(10, 50);
            var saltMax = (byte)DataGeneration.RandomInteger(100, 150);
            //var salt = new Salt(saltMin, saltMax);

            const RijndaelKeySize keySize = RijndaelKeySize.Key192Bit;

            var parameters = RijndaelParameters.Create(passPhrase)
                .SetInitVector(initVector)
                .SetRandomSaltLength(saltMin, saltMax)
                .SetKeySize(keySize);

            Assert.AreEqual(passPhrase, DataConversion.ToString(parameters.Key));
            Assert.IsTrue(parameters.Key.IsReadOnly());

            Assert.AreEqual(initVector, DataConversion.ToString(parameters.InitVector));
            Assert.IsTrue(parameters.InitVector.IsReadOnly());

            Assert.AreEqual(saltMin, parameters.MinimumDataSaltLength);
            Assert.AreEqual(saltMax, parameters.MaximumDataSaltLength);

            Assert.AreEqual(keySize, parameters.KeySize);
        }

        [Test]
        public void RijndaelParametersTest_PasswordIterations()
        {
            string passPhrase = DataGeneration.RandomString(100, 500, true, true, true, true);
            string initVector = DataGeneration.RandomString(16, 16, true, true, true, true);

            var saltMin = (byte)DataGeneration.RandomInteger(10, 50);
            var saltMax = (byte)DataGeneration.RandomInteger(100, 150);
            //var salt = new Salt(saltMin, saltMax);

            const RijndaelKeySize keySize = RijndaelKeySize.Key192Bit;

            const byte passwordIterations = 5;

            var parameters = RijndaelParameters.Create(passPhrase)
                .SetInitVector(initVector)
                .SetRandomSaltLength(saltMin, saltMax)
                .SetKeySize(keySize)
                .SetPasswordIterations(passwordIterations);

            Assert.AreEqual(passPhrase, DataConversion.ToString(parameters.Key));
            Assert.IsTrue(parameters.Key.IsReadOnly());

            Assert.AreEqual(initVector, DataConversion.ToString(parameters.InitVector));
            Assert.IsTrue(parameters.InitVector.IsReadOnly());

            Assert.AreEqual(saltMin, parameters.MinimumDataSaltLength);
            Assert.AreEqual(saltMax, parameters.MaximumDataSaltLength);

            Assert.AreEqual(keySize, parameters.KeySize);

            Assert.AreEqual(passwordIterations, parameters.PasswordIterations);
        }
    }
}