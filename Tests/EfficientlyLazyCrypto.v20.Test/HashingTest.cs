using System.IO;
using System;
using System.Text;
using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    ///This is a test class for HashingTest and is intended
    ///to contain all HashingTest Unit Tests
    ///</summary>
    [TestFixture]
    public class HashingTest
    {
        [Test, Repeat(50)]
        public void GetHash()
        {
            foreach (string hash in Enum.GetNames(typeof(HashingAlgorithm)))
            {
                var type = (HashingAlgorithm)Enum.Parse(typeof(HashingAlgorithm), hash);

                string normalText = DataGeneration.RandomString(3, 500);

                string hashed = DataHashing.Compute(type, normalText, Encoding.UTF8);

                Assert.IsTrue(DataHashing.Validate(type, normalText, hashed, Encoding.UTF8));

            }
        }

        [Test, Repeat(50)]
        public void GetHashFile()
        {
            string tempFile = Path.GetTempFileName();

            using (var sw = new StreamWriter(tempFile, false))
            {
                for (int i = 0; i < 100; i++)
                {
                    sw.Write(DataGeneration.RandomString(3, 2000));
                    sw.Write(" ");
                }
            }

            var file = new FileInfo(tempFile);

            foreach (string hash in Enum.GetNames(typeof(HashingAlgorithm)))
            {
                var type = (HashingAlgorithm)Enum.Parse(typeof(HashingAlgorithm), hash);

                string hashed = DataHashing.Compute(type, file);

                Assert.IsTrue(DataHashing.Validate(type, file, hashed));
            }

            file.Delete();
        }

        [Test, Repeat(50)]
        public void GetHMACHash()
        {
            foreach (string hash in Enum.GetNames(typeof(HashingAlgorithm)))
            {
                var type = (HashingAlgorithm)Enum.Parse(typeof(HashingAlgorithm), hash);

                string normalText = DataGeneration.RandomString(3, 500);
                string keyText = DataGeneration.RandomString(3, 500);

                string hashed = DataHashing.ComputeHMAC(type, normalText, keyText, Encoding.UTF8);

                Assert.IsTrue(DataHashing.ValidateHMAC(type, normalText, keyText, hashed, Encoding.UTF8));
            }
        }

        [Test, Repeat(50)]
        public void GetHMACHashFile()
        {
            string tempFile = Path.GetTempFileName();

            using (var sw = new StreamWriter(tempFile, false))
            {
                for (int i = 0; i < 100; i++)
                {
                    sw.Write(DataGeneration.RandomString(3, 2000));
                    sw.Write(" ");
                }
            }

            var file = new FileInfo(tempFile);

            foreach (string hash in Enum.GetNames(typeof(HashingAlgorithm)))
            {
                var type = (HashingAlgorithm)Enum.Parse(typeof(HashingAlgorithm), hash);

                string keyText = DataGeneration.RandomString(3, 500);
                string hashed = DataHashing.ComputeHMAC(type, file, keyText, Encoding.UTF8);

                Assert.IsTrue(DataHashing.ValidateHMAC(type, file, keyText, hashed, Encoding.UTF8));
            }

            file.Delete();
        }

    }
}