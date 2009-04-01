using System.IO;
using System.Text;
using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for HashingTest and is intended
    ///to contain all HashingTest Unit Tests
    ///</summary>
    [TestFixture]
    public class DataHashingTests : RandomBase
    {
        //[Test, Parallelizable, Repeat(50)]
        [Test, Repeat(50), Parallelizable]
        //[Row(HashingAlgorithm.MD5)]
        [Row(HashingAlgorithm.SHA1)]
        [Row(HashingAlgorithm.SHA256)]
        [Row(HashingAlgorithm.SHA384)]
        [Row(HashingAlgorithm.SHA512)]
        public void GetHash(HashingAlgorithm algorithm)
        {
            string normalText = GenerateText(100, 500);

            string hashed = DataHashing.Compute(algorithm, normalText, Encoding.UTF8);

            Assert.IsTrue(DataHashing.Validate(algorithm, normalText, hashed, Encoding.UTF8));
        }

        [Test, Repeat(50), Parallelizable]
        //[Row(HashingAlgorithm.MD5)]
        [Row(HashingAlgorithm.SHA1)]
        [Row(HashingAlgorithm.SHA256)]
        [Row(HashingAlgorithm.SHA384)]
        [Row(HashingAlgorithm.SHA512)]
        public void GetHashFile(HashingAlgorithm algorithm)
        {
            string tempFile = Path.GetTempFileName();

            using (var sw = new StreamWriter(tempFile, false))
            {
                for (int i = 0; i < 100; i++)
                {
                    sw.Write(GenerateText(10, 500));
                    sw.Write(" ");
                }
            }

            var file = new FileInfo(tempFile);

            string hashed = DataHashing.Compute(algorithm, file);

            Assert.IsTrue(DataHashing.Validate(algorithm, file, hashed));

            file.Delete();
        }

        [Test, Repeat(50), Parallelizable]
        //[Row(HashingAlgorithm.MD5)]
        [Row(HashingAlgorithm.SHA1)]
        [Row(HashingAlgorithm.SHA256)]
        [Row(HashingAlgorithm.SHA384)]
        [Row(HashingAlgorithm.SHA512)]
        public void GetHMACHash(HashingAlgorithm algorithm)
        {
            string normalText = GenerateText(3, 500);
            string keyText = GenerateText(10, 50);

            string hashed = DataHashing.ComputeHMAC(algorithm, normalText, keyText, Encoding.UTF8);

            Assert.IsTrue(DataHashing.ValidateHMAC(algorithm, normalText, keyText, hashed, Encoding.UTF8));
        }

        [Test, Repeat(50), Parallelizable]
        //[Row(HashingAlgorithm.MD5)]
        [Row(HashingAlgorithm.SHA1)]
        [Row(HashingAlgorithm.SHA256)]
        [Row(HashingAlgorithm.SHA384)]
        [Row(HashingAlgorithm.SHA512)]
        public void GetHMACHashFile(HashingAlgorithm algorithm)
        {
            string tempFile = Path.GetTempFileName();

            using (var sw = new StreamWriter(tempFile, false))
            {
                for (int i = 0; i < 100; i++)
                {
                    sw.Write(GenerateText(10, 500));
                    sw.Write(" ");
                }
            }

            var file = new FileInfo(tempFile);

            string keyText = GenerateText(10, 50);

            string hashed = DataHashing.ComputeHMAC(algorithm, file, keyText, Encoding.UTF8);

            Assert.IsTrue(DataHashing.ValidateHMAC(algorithm, file, keyText, hashed, Encoding.UTF8));

            file.Delete();
        }
    }
}