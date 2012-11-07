using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Data Hashing
    /// </summary>
    public static class DataHashing
    {
        #region Compute

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        /// <remarks>Using Encoding.UTF8 for character encoding</remarks>
        public static string Compute(HashType hashType, string plaintext)
        {
            return Compute(hashType, plaintext, Encoding.UTF8);
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(HashType hashType, string plaintext, Encoding encoding)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return Compute(hashType, encoding.GetBytes(plaintext));
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(HashType hashType, byte[] plaintext)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }

            var hashValue = HashAlgorithm.Create(hashType.ToString()).ComputeHash(plaintext);

            return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
        }

        /// <summary>
        /// Get File Hash
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <returns>Hashed string</returns>
        public static string Compute(HashType hashType, FileSystemInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }

            string strRet;

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                var hashValue = HashAlgorithm.Create(hashType.ToString()).ComputeHash(fs);

                strRet = BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
            }

            return strRet;
        }

        #endregion

        #region ComputeHMAC

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <returns>Hashed string</returns>
        /// <remarks>Using Encoding.UTF8 for character encoding</remarks>
        public static string ComputeHMAC(HashType hashType, string plaintext, string key)
        {
            return ComputeHMAC(hashType, plaintext, key, Encoding.UTF8);
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType hashType, string plaintext, string key, Encoding encoding)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return ComputeHMAC(hashType, encoding.GetBytes(plaintext), encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash hashType.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType hashType, byte[] plaintext, byte[] key)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }

            var hash = HMAC.Create("HMAC" + hashType);
            hash.Key = key;

            var hashValue = hash.ComputeHash(plaintext);

            var strRet = string.Empty;

            foreach (var b in hashValue)
            {
                strRet += string.Format("{0:x2}", b);
            }

            return strRet;
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <returns>Hashed string</returns>
        /// <remarks>Using Encoding.UTF8 for character encoding</remarks>
        public static string ComputeHMAC(HashType hashType, FileSystemInfo file, string key)
        {
            return ComputeHMAC(hashType, file, key, Encoding.UTF8);
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType hashType, FileSystemInfo file, string key, Encoding encoding)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return ComputeHMAC(hashType, file, encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType hashType, FileSystemInfo file, byte[] key)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }

            var strRet = string.Empty;

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                var hash = HMAC.Create("HMAC" + hashType);
                hash.Key = key;

                var hashValue = hash.ComputeHash(fs);

                foreach (var b in hashValue)
                {
                    strRet += string.Format("{0:x2}", b);
                }
            }

            return strRet;
        }

        #endregion

        #region Validate

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.UTF8 for character encoding</remarks>
        public static bool Validate(HashType hashType, string originalValue, string hashValue)
        {
            return Validate(hashType, Encoding.UTF8.GetBytes(originalValue), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashType hashType, string originalValue, string hashValue, Encoding encoding)
        {
            return Validate(hashType, encoding.GetBytes(originalValue), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashType hashType, byte[] originalValue, string hashValue)
        {
            return string.Equals(Compute(hashType, originalValue), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Checks the file with a hash.
        /// </summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file that was hashed.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashType hashType, FileSystemInfo file, string hashValue)
        {
            return string.Equals(Compute(hashType, file), hashValue, StringComparison.CurrentCulture);
        }

        #endregion

        #region ValidateHMAC

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType hashType, byte[] originalValue, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(hashType, originalValue, key), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.UTF8 for character encoding</remarks>
        public static bool ValidateHMAC(HashType hashType, string originalValue, string key, string hashValue)
        {
            return ValidateHMAC(hashType, Encoding.UTF8.GetBytes(originalValue), Encoding.UTF8.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType hashType, string originalValue, string key, string hashValue, Encoding encoding)
        {
            return ValidateHMAC(hashType, encoding.GetBytes(originalValue), encoding.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.UTF8 for character encoding</remarks>
        public static bool ValidateHMAC(HashType hashType, FileSystemInfo file, string key, string hashValue)
        {
            return string.Equals(ComputeHMAC(hashType, file, key, Encoding.UTF8), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType hashType, FileSystemInfo file, string key, string hashValue, Encoding encoding)
        {
            return string.Equals(ComputeHMAC(hashType, file, key, encoding), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashType"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash hashType</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType hashType, FileSystemInfo file, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(hashType, file, key), hashValue, StringComparison.CurrentCulture);
        }

        #endregion
    }
}