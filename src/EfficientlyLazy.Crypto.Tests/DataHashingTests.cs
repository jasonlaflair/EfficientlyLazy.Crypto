using System;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Test
{
    /// <summary>
    ///This is a test class for HashingTest and is intended
    ///to contain all HashingTest Unit Tests
    ///</summary>
    public class DataHashingTests : RandomBase
    {
        [Theory]
        [InlineData(Algorithm.MD5, false, false)]
        [InlineData(Algorithm.SHA1, false, false)]
        [InlineData(Algorithm.SHA256, false, false)]
        [InlineData(Algorithm.SHA384, false, false)]
        [InlineData(Algorithm.SHA512, false, false)]
        //[InlineData(Algorithm.SHA1, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHash3(Algorithm algorithm, bool useNullString, bool useNullEncoding)
        {
            string normalText = useNullString ? null : GenerateText(100, 500);
            Encoding encoding = useNullEncoding ? null : Encoding.UTF8;

            string hashed = DataHashing.Compute(algorithm, normalText, encoding);

            Assert.True(DataHashing.Validate(algorithm, normalText, hashed, encoding));
        }

        [Theory]
        [InlineData(Algorithm.MD5, false)]
        [InlineData(Algorithm.SHA1, false)]
        [InlineData(Algorithm.SHA256, false)]
        [InlineData(Algorithm.SHA384, false)]
        [InlineData(Algorithm.SHA512, false)]
        //[InlineData(Algorithm.SHA1, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHash2(Algorithm algorithm, bool useNullByte)
        {
            byte[] bytes = null;

            if (!useNullByte)
            {
                bytes = Encoding.UTF8.GetBytes(GenerateText(100, 500));
            }

            string hashed = DataHashing.Compute(algorithm, bytes);

            Assert.True(DataHashing.Validate(algorithm, bytes, hashed));
        }

        [Theory]
        [InlineData(Algorithm.MD5, false)]
        [InlineData(Algorithm.SHA1, false)]
        [InlineData(Algorithm.SHA256, false)]
        [InlineData(Algorithm.SHA384, false)]
        [InlineData(Algorithm.SHA512, false)]
        //[InlineData(Algorithm.SHA1, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHashFile2(Algorithm algorithm, bool useNullFile)
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

            Assert.True(DataHashing.Validate(algorithm, file, hashed));

            if (!useNullFile)
            {
                file.Delete();
            }
        }

        [Theory]
        [InlineData(Algorithm.MD5, false, false, false)]
        [InlineData(Algorithm.SHA1, false, false, false)]
        [InlineData(Algorithm.SHA256, false, false, false)]
        [InlineData(Algorithm.SHA384, false, false, false)]
        [InlineData(Algorithm.SHA512, false, false, false)]
        //[InlineData(Algorithm.SHA1, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHash4(Algorithm algorithm, bool useNullText, bool useNullKey, bool useNullEncoding)
        {
            string normalText = useNullText ? null : GenerateText(3, 500);
            string keyText = useNullKey ? null : GenerateText(10, 50);
            Encoding encoding = useNullEncoding ? null : Encoding.UTF8;

            string hashed = DataHashing.ComputeHMAC(algorithm, normalText, keyText, encoding);

            Assert.True(DataHashing.ValidateHMAC(algorithm, normalText, keyText, hashed, encoding));
        }

        [Theory]
        [InlineData(Algorithm.MD5, false, false)]
        [InlineData(Algorithm.SHA1, false, false)]
        [InlineData(Algorithm.SHA256, false, false)]
        [InlineData(Algorithm.SHA384, false, false)]
        [InlineData(Algorithm.SHA512, false, false)]
        //[InlineData(Algorithm.SHA1, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHash3(Algorithm algorithm, bool useNullBytes, bool useNullKey)
        {
            byte[] bytes = useNullBytes ? null : Encoding.UTF8.GetBytes(GenerateText(100, 500));
            byte[] key = useNullKey ? null : Encoding.UTF8.GetBytes(GenerateText(10, 50));

            string hashed = DataHashing.ComputeHMAC(algorithm, bytes, key);

            Assert.True(DataHashing.ValidateHMAC(algorithm, bytes, key, hashed));
        }

        [Theory]
        [InlineData(Algorithm.MD5, false, false, false)]
        [InlineData(Algorithm.SHA1, false, false, false)]
        [InlineData(Algorithm.SHA256, false, false, false)]
        [InlineData(Algorithm.SHA384, false, false, false)]
        [InlineData(Algorithm.SHA512, false, false, false)]
        //[InlineData(Algorithm.SHA1, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHashFile4(Algorithm algorithm, bool useNullFile, bool useNullKey, bool useNullEncoding)
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

            Assert.True(DataHashing.ValidateHMAC(algorithm, file, keyText, hashed, encoding));

            if (!useNullFile)
            {
                file.Delete();
            }
        }

        [Theory]
        [InlineData(Algorithm.MD5, false, false)]
        [InlineData(Algorithm.SHA1, false, false)]
        [InlineData(Algorithm.SHA256, false, false)]
        [InlineData(Algorithm.SHA384, false, false)]
        [InlineData(Algorithm.SHA512, false, false)]
        //[InlineData(Algorithm.SHA1, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, false, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, false)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA1, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHMACHashFile3(Algorithm algorithm, bool useNullFile, bool useNullKey)
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

            Assert.True(DataHashing.ValidateHMAC(algorithm, file, key, hashed));

            if (!useNullFile)
            {
                file.Delete();
            }
        }
    }
}