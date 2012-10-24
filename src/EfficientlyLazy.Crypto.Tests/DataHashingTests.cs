using System;
using System.Collections.Generic;
using System.IO;
#if !NET20
using System.Linq;
#endif
using System.Security.Cryptography;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Tests
{
    public class HashTestPair
    {
        public HashType Algorithm { get; set; }
        public Encoding Encoding { get; set; }

        public HashTestPair(HashType alg, Encoding enc)
        {
            Algorithm = alg;
            Encoding = enc;
        }
    }

    /// <summary>
    ///This is a test class for HashingTest and is intended
    ///to contain all HashingTest Unit Tests
    ///</summary>
    public class DataHashingTests : RandomBase
    {
        [Theory]
        [InlineData(HashType.SHA1)]
        [InlineData(HashType.SHA256)]
        [InlineData(HashType.SHA384)]
        [InlineData(HashType.SHA512)]
        [InlineData(HashType.RIPEMD160)]
        public void Compute_Default_Encoding_Successful(HashType algorithm)
        {
            // Arrange
            const string PLAIN_TEXT = "The quick brown fox jumps over the lazy dog";
            var bytes = Encoding.Default.GetBytes(PLAIN_TEXT);
            var expectedHash = HashAlgorithm.Create(algorithm.ToString()).ComputeHash(bytes);
            var expectedString = BitConverter.ToString(expectedHash).Replace("-", string.Empty).ToUpper();

            // Act
            var actualHash = DataHashing.Compute(algorithm, PLAIN_TEXT);

            // Assert
            Assert.Equal(expectedString, actualHash);
        }

        public static IEnumerable<object[]> HashTestPairs
        {
            get
            {
                var encodings = new List<Encoding>
                    {
                        Encoding.ASCII,
                        Encoding.BigEndianUnicode,
                        Encoding.Default,
                        Encoding.UTF32,
                        Encoding.UTF7,
                        Encoding.UTF8,
                        Encoding.Unicode
                    };

                var list = new List<object[]>();

#if !NET20                
                var enumNames = Enum.GetNames(typeof(HashType)).Where(x => x != "MD5").Where(x => x != "None");
#else
                var enumNames = new List<string>(Enum.GetNames(typeof(HashType)));
                enumNames.Remove("MD5");
                enumNames.Remove("None");
#endif

                foreach (var algStr in enumNames)
                {
                    var alg = (HashType)Enum.Parse(typeof(HashType), algStr);

                    foreach (var enc in encodings)
                    {
                        list.Add(new object[]
                            {
                                new HashTestPair(alg, enc)
                            });
                    }
                }

                return list;
            }
        }

        [Theory]
        [PropertyData("HashTestPairs")]
        public void Compute_Specific_Encoding_Successful(HashTestPair pair)
        {
            // Arrange
            const string PLAIN_TEXT = "The quick brown fox jumps over the lazy dog";
            var bytes = pair.Encoding.GetBytes(PLAIN_TEXT);
            var expectedHash = HashAlgorithm.Create(pair.Algorithm.ToString()).ComputeHash(bytes);
            var expectedString = BitConverter.ToString(expectedHash).Replace("-", string.Empty).ToUpper();

            // Act
            var actualHash = DataHashing.Compute(pair.Algorithm, PLAIN_TEXT, pair.Encoding);

            // Assert
            Assert.Equal(expectedString, actualHash);
        }

        [Theory]
        [InlineData(HashType.MD5, false)]
        [InlineData(HashType.SHA1, false)]
        [InlineData(HashType.SHA256, false)]
        [InlineData(HashType.SHA384, false)]
        [InlineData(HashType.SHA512, false)]
        //[InlineData(Algorithm.SHA1, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA256, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA384, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        //[InlineData(Algorithm.SHA512, true)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void GetHashFile2(HashType algorithm, bool useNullFile)
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
        [InlineData(HashType.MD5, false, false, false)]
        [InlineData(HashType.SHA1, false, false, false)]
        [InlineData(HashType.SHA256, false, false, false)]
        [InlineData(HashType.SHA384, false, false, false)]
        [InlineData(HashType.SHA512, false, false, false)]
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
        public void GetHMACHash4(HashType algorithm, bool useNullText, bool useNullKey, bool useNullEncoding)
        {
            string normalText = useNullText ? null : GenerateText(3, 500);
            string keyText = useNullKey ? null : GenerateText(10, 50);
            Encoding encoding = useNullEncoding ? null : Encoding.UTF8;

            string hashed = DataHashing.ComputeHMAC(algorithm, normalText, keyText, encoding);

            Assert.True(DataHashing.ValidateHMAC(algorithm, normalText, keyText, hashed, encoding));
        }

        [Theory]
        [InlineData(HashType.MD5, false, false)]
        [InlineData(HashType.SHA1, false, false)]
        [InlineData(HashType.SHA256, false, false)]
        [InlineData(HashType.SHA384, false, false)]
        [InlineData(HashType.SHA512, false, false)]
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
        public void GetHMACHash3(HashType algorithm, bool useNullBytes, bool useNullKey)
        {
            byte[] bytes = useNullBytes ? null : Encoding.UTF8.GetBytes(GenerateText(100, 500));
            byte[] key = useNullKey ? null : Encoding.UTF8.GetBytes(GenerateText(10, 50));

            string hashed = DataHashing.ComputeHMAC(algorithm, bytes, key);

            Assert.True(DataHashing.ValidateHMAC(algorithm, bytes, key, hashed));
        }

        [Theory]
        [InlineData(HashType.MD5, false, false, false)]
        [InlineData(HashType.SHA1, false, false, false)]
        [InlineData(HashType.SHA256, false, false, false)]
        [InlineData(HashType.SHA384, false, false, false)]
        [InlineData(HashType.SHA512, false, false, false)]
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
        public void GetHMACHashFile4(HashType algorithm, bool useNullFile, bool useNullKey, bool useNullEncoding)
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
        [InlineData(HashType.MD5, false, false)]
        [InlineData(HashType.SHA1, false, false)]
        [InlineData(HashType.SHA256, false, false)]
        [InlineData(HashType.SHA384, false, false)]
        [InlineData(HashType.SHA512, false, false)]
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
        public void GetHMACHashFile3(HashType algorithm, bool useNullFile, bool useNullKey)
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