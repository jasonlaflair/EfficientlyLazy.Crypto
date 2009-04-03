using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Data Hashing
    /// </summary>
    public static class DataHashing
    {
        /// <summary>Generates the hash of a text.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(HashingAlgorithm hashAlgorithm, string plaintext, Encoding encoding)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return Compute(hashAlgorithm, encoding.GetBytes(plaintext));
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(HashingAlgorithm hashAlgorithm, byte[] plaintext)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }
            
            byte[] hashValue = HashAlgorithm.Create(hashAlgorithm.ToString()).ComputeHash(plaintext);

            string strRet = string.Empty;

            if (hashValue != null)
            {
                foreach (byte b in hashValue)
                {
                    strRet += String.Format("{0:x2}", b);
                }
            }

            return strRet;
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashingAlgorithm hashAlgorithm, string plaintext, string key, Encoding encoding)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return ComputeHMAC(hashAlgorithm, encoding.GetBytes(plaintext), encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashingAlgorithm hashAlgorithm, byte[] plaintext, byte[] key)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }
            
            HMAC hash = HMAC.Create("HMAC" + hashAlgorithm);
            hash.Key = key;

            byte[] hashValue = hash.ComputeHash(plaintext);

            string strRet = string.Empty;

            if (hashValue != null)
            {
                foreach (byte b in hashValue)
                {
                    strRet += string.Format("{0:x2}", b);
                }
            }

            return strRet;
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashingAlgorithm hashAlgorithm, FileSystemInfo file, string key, Encoding encoding)
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

            return ComputeHMAC(hashAlgorithm, file, encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashingAlgorithm hashAlgorithm, FileSystemInfo file, byte[] key)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }
            
            string strRet = string.Empty;

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                HMAC hash = HMAC.Create("HMAC" + hashAlgorithm);
                hash.Key = key;

                byte[] hashValue = hash.ComputeHash(fs);

                if (hashValue != null)
                {
                    foreach (byte b in hashValue)
                    {
                        strRet += string.Format("{0:x2}", b);
                    }
                }
            }

            return strRet;
        }

        /// <summary>
        /// Get File Hash
        /// </summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <returns>Hashed string</returns>
        public static string Compute(HashingAlgorithm hashAlgorithm, FileSystemInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }
            
            string strRet = string.Empty;

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                byte[] hashValue = HashAlgorithm.Create(hashAlgorithm.ToString()).ComputeHash(fs);

                if (hashValue != null)
                {
                    foreach (byte b in hashValue)
                    {
                        strRet += String.Format("{0:x2}", b);
                    }
                }
            }

            return strRet;
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashingAlgorithm hashAlgorithm, byte[] originalValue, string hashValue)
        {
            return string.Equals(Compute(hashAlgorithm, originalValue), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashingAlgorithm hashAlgorithm, string originalValue, string hashValue, Encoding encoding)
        {
            return Validate(hashAlgorithm, encoding.GetBytes(originalValue), hashValue);
        }

        /// <summary>
        /// Checks the file with a hash.
        /// </summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="file">The file that was hashed.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashingAlgorithm hashAlgorithm, FileSystemInfo file, string hashValue)
        {
            return string.Equals(Compute(hashAlgorithm, file), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashingAlgorithm hashAlgorithm, byte[] originalValue, byte[] key, string hashValue)
        {
           return string.Equals(ComputeHMAC(hashAlgorithm, originalValue, key), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashingAlgorithm hashAlgorithm, string originalValue, string key, string hashValue, Encoding encoding)
        {
            return ValidateHMAC(hashAlgorithm, encoding.GetBytes(originalValue), encoding.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashingAlgorithm hashAlgorithm, FileSystemInfo file, string key, string hashValue, Encoding encoding)
        {
            return string.Equals(ComputeHMAC(hashAlgorithm, file, key, encoding), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="hashAlgorithm"><see cref="HashingAlgorithm"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashingAlgorithm hashAlgorithm, FileSystemInfo file, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(hashAlgorithm, file, key), hashValue, StringComparison.CurrentCulture);
        }
    }
}