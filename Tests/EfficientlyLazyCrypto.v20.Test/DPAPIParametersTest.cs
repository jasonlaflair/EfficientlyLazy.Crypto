using MbUnit.Framework;
using System.Security;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for DPAPIParametersTest and is intended
    ///to contain all DPAPIParametersTest Unit Tests
    ///</summary>
    [TestFixture]
    public class DPAPIParametersTest
    {
        /// <summary>
        ///A test for KeyType
        ///</summary>
        [Test]
        [Row(DPAPIKeyType.MachineKey)]
        [Row(DPAPIKeyType.UserKey)]
        public void DPAPIParameters_KeyTypeTest(DPAPIKeyType keyType)
        {
            var actual = DPAPIParameters.Create(keyType);

            Assert.AreEqual(keyType, actual.KeyType);
            Assert.AreEqual(string.Empty, DataConversion.ToString(actual.Entropy));
            Assert.IsTrue(actual.Entropy.IsReadOnly());
        }

        /// <summary>
        ///A test for Entropy
        ///</summary>
        [Test]
        [Row(DPAPIKeyType.MachineKey)]
        [Row(DPAPIKeyType.UserKey)]
        public void DPAPIParameters_EntropyTest(DPAPIKeyType keyType)
        {
            string entropy = DataGeneration.RandomString(100, 500, true, true, true, true);

            var actual = DPAPIParameters.Create(keyType)
                .SetEntropy(entropy);

            Assert.AreEqual(keyType, actual.KeyType);
            Assert.AreEqual(entropy, DataConversion.ToString(actual.Entropy));
            Assert.IsTrue(actual.Entropy.IsReadOnly());
        }

        /// <summary>
        ///A test for ISecureStringConversionService
        ///</summary>
        [Test]
        [Row(DPAPIKeyType.MachineKey)]
        [Row(DPAPIKeyType.UserKey)]
        public void DPAPIParameters_ISecureStringConversionServiceTest(DPAPIKeyType keyType)
        {
            string entropy = DataGeneration.RandomString(100, 500, true, true, true, true);

            var actual = DPAPIParameters.Create(keyType)
                .SetEntropy(entropy);

            Assert.AreEqual(keyType, actual.KeyType);
            Assert.AreEqual(entropy, DataConversion.ToString(actual.Entropy));
            Assert.IsTrue(actual.Entropy.IsReadOnly());
        }

        /// <summary>
        ///A test for ISecureStringConversionService
        ///</summary>
        [Test]
        [Row(DPAPIKeyType.MachineKey)]
        [Row(DPAPIKeyType.UserKey)]
        public void DPAPIParameters_SecureString(DPAPIKeyType keyType)
        {
            string entropy = DataGeneration.RandomString(100, 500, true, true, true, true);

            var ss = new SecureString();

            foreach (var ch in entropy)
            {
                ss.AppendChar(ch);
            }

            var actual = DPAPIParameters.Create(keyType)
                .SetEntropy(ss);

            Assert.AreEqual(keyType, actual.KeyType);
            Assert.AreEqual(DataConversion.ToString(ss), DataConversion.ToString(ss));
            Assert.AreEqual(DataConversion.ToString(ss), DataConversion.ToString(actual.Entropy));
            Assert.IsTrue(actual.Entropy.IsReadOnly());
        }

        [Test]
        [Row(DPAPIKeyType.MachineKey, true)]
        [Row(DPAPIKeyType.UserKey, true)]
        [Row(DPAPIKeyType.MachineKey, false)]
        [Row(DPAPIKeyType.UserKey, false)]
        public void DPAPIParameters_SecureString1(DPAPIKeyType keyType, bool makeReadOnly)
        {
            string entropy = DataGeneration.RandomString(100, 500, true, true, true, true);

            var ss = new SecureString();

            foreach (var ch in entropy)
            {
                ss.AppendChar(ch);
            }

            if (makeReadOnly) ss.MakeReadOnly();

            var actual = DPAPIParameters.Create(keyType)
                .SetEntropy(ss);

            Assert.AreEqual(keyType, actual.KeyType);
            Assert.AreEqual(DataConversion.ToString(ss), DataConversion.ToString(ss));
            Assert.AreEqual(DataConversion.ToString(ss), DataConversion.ToString(actual.Entropy));
            Assert.IsTrue(actual.Entropy.IsReadOnly());
        }       
    }
}