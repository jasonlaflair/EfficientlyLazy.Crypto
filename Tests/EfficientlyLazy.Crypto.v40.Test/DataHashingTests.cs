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
    using System.IO;
    using System.Text;
    using MbUnit.Framework;

    /// <summary>
    ///This is a test class for HashingTest and is intended
    ///to contain all HashingTest Unit Tests
    ///</summary>
    [TestFixture]
    public class DataHashingTests : RandomBase
    {
        [Test]
        [Parallelizable]
        [Repeat(50)]
        [Row(Algorithm.SHA1, false, false)]
        [Row(Algorithm.SHA256, false, false)]
        [Row(Algorithm.SHA384, false, false)]
        [Row(Algorithm.SHA512, false, false)]
        [Row(Algorithm.SHA1, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHash(Algorithm algorithm, bool useNullString, bool useNullEncoding)
        {
            string normalText = useNullString ? null : GenerateText(100, 500);
            Encoding encoding = useNullEncoding ? null : Encoding.UTF8;

            string hashed = DataHashing.Compute(algorithm, normalText, encoding);

            Assert.IsTrue(DataHashing.Validate(algorithm, normalText, hashed, encoding));
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        //[Row(Algorithm.MD5)]
        [Row(Algorithm.SHA1, false)]
        [Row(Algorithm.SHA256, false)]
        [Row(Algorithm.SHA384, false)]
        [Row(Algorithm.SHA512, false)]
        [Row(Algorithm.SHA1, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHash(Algorithm algorithm, bool useNullByte)
        {
            byte[] bytes = null;

            if (!useNullByte)
            {
                bytes = Encoding.UTF8.GetBytes(GenerateText(100, 500));
            }

            string hashed = DataHashing.Compute(algorithm, bytes);

            Assert.IsTrue(DataHashing.Validate(algorithm, bytes, hashed));
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        //[Row(Algorithm.MD5)]
        [Row(Algorithm.SHA1, false)]
        [Row(Algorithm.SHA256, false)]
        [Row(Algorithm.SHA384, false)]
        [Row(Algorithm.SHA512, false)]
        [Row(Algorithm.SHA1, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHashFile(Algorithm algorithm, bool useNullFile)
        {
            FileInfo file = null;

            if (!useNullFile)
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

                file = new FileInfo(tempFile);
            }

            string hashed = DataHashing.Compute(algorithm, file);

            Assert.IsTrue(DataHashing.Validate(algorithm, file, hashed));

            if (!useNullFile)
            {
                file.Delete();
            }
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        //[Row(Algorithm.MD5)]
        [Row(Algorithm.SHA1, false, false, false)]
        [Row(Algorithm.SHA256, false, false, false)]
        [Row(Algorithm.SHA384, false, false, false)]
        [Row(Algorithm.SHA512, false, false, false)]
        [Row(Algorithm.SHA1, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHash(Algorithm algorithm, bool useNullText, bool useNullKey, bool useNullEncoding)
        {
            string normalText = useNullText ? null : GenerateText(3, 500);
            string keyText = useNullKey ? null : GenerateText(10, 50);
            Encoding encoding = useNullEncoding ? null : Encoding.UTF8;

            string hashed = DataHashing.ComputeHMAC(algorithm, normalText, keyText, encoding);

            Assert.IsTrue(DataHashing.ValidateHMAC(algorithm, normalText, keyText, hashed, encoding));
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        //[Row(Algorithm.MD5)]
        [Row(Algorithm.SHA1, false, false)]
        [Row(Algorithm.SHA256, false, false)]
        [Row(Algorithm.SHA384, false, false)]
        [Row(Algorithm.SHA512, false, false)]
        [Row(Algorithm.SHA1, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHash(Algorithm algorithm, bool useNullBytes, bool useNullKey)
        {
            byte[] bytes = useNullBytes ? null : Encoding.UTF8.GetBytes(GenerateText(100, 500));
            byte[] key = useNullKey ? null : Encoding.UTF8.GetBytes(GenerateText(10, 50));

            string hashed = DataHashing.ComputeHMAC(algorithm, bytes, key);

            Assert.IsTrue(DataHashing.ValidateHMAC(algorithm, bytes, key, hashed));
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        //[Row(Algorithm.MD5)]
        [Row(Algorithm.SHA1, false, false, false)]
        [Row(Algorithm.SHA256, false, false, false)]
        [Row(Algorithm.SHA384, false, false, false)]
        [Row(Algorithm.SHA512, false, false, false)]
        [Row(Algorithm.SHA1, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHashFile(Algorithm algorithm, bool useNullFile, bool useNullKey, bool useNullEncoding)
        {
            FileInfo file = null;

            if (!useNullFile)
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

                file = new FileInfo(tempFile);
            }

            string keyText = useNullKey ? null : GenerateText(10, 50);
            Encoding encoding = useNullEncoding ? null : Encoding.UTF8;

            string hashed = DataHashing.ComputeHMAC(algorithm, file, keyText, encoding);

            Assert.IsTrue(DataHashing.ValidateHMAC(algorithm, file, keyText, hashed, encoding));

            if (!useNullFile)
            {
                file.Delete();
            }
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        //[Row(Algorithm.MD5)]
        [Row(Algorithm.SHA1, false, false)]
        [Row(Algorithm.SHA256, false, false)]
        [Row(Algorithm.SHA384, false, false)]
        [Row(Algorithm.SHA512, false, false)]
        [Row(Algorithm.SHA1, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, false, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, false, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA1, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA256, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA384, true, true, ExpectedException = typeof (ArgumentNullException))]
        [Row(Algorithm.SHA512, true, true, ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHashFile(Algorithm algorithm, bool useNullFile, bool useNullKey)
        {
            FileInfo file = null;

            if (!useNullFile)
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

                file = new FileInfo(tempFile);
            }

            byte[] key = useNullKey ? null : Encoding.UTF8.GetBytes(GenerateText(10, 50));

            string hashed = DataHashing.ComputeHMAC(algorithm, file, key);

            Assert.IsTrue(DataHashing.ValidateHMAC(algorithm, file, key, hashed));

            if (!useNullFile)
            {
                file.Delete();
            }
        }
    }
}