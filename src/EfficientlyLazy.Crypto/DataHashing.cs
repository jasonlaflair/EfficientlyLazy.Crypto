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
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static string Compute(HashType algorithm, string plaintext)
        {
            return Compute(algorithm, plaintext, Encoding.Default);
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(HashType algorithm, string plaintext, Encoding encoding)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return Compute(algorithm, encoding.GetBytes(plaintext));
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(HashType algorithm, byte[] plaintext)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }

            var hashValue = HashAlgorithm.Create(algorithm.ToString()).ComputeHash(plaintext);

            return BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
        }

        /// <summary>
        /// Get File Hash
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <returns>Hashed string</returns>
        public static string Compute(HashType algorithm, FileSystemInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }

            var strRet = string.Empty;

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                var hashValue = HashAlgorithm.Create(algorithm.ToString()).ComputeHash(fs);

                strRet = BitConverter.ToString(hashValue).Replace("-", string.Empty).ToUpper();
            }

            return strRet;
        }

        #endregion

        #region ComputeHMAC

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static string ComputeHMAC(HashType algorithm, string plaintext, string key)
        {
            return ComputeHMAC(algorithm, plaintext, key, Encoding.Default);
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType algorithm, string plaintext, string key, Encoding encoding)
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

            return ComputeHMAC(algorithm, encoding.GetBytes(plaintext), encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType algorithm, byte[] plaintext, byte[] key)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plaintext", "plainText cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }

            var hash = HMAC.Create("HMAC" + algorithm);
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
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static string ComputeHMAC(HashType algorithm, FileSystemInfo file, string key)
        {
            return ComputeHMAC(algorithm, file, key, Encoding.Default);
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType algorithm, FileSystemInfo file, string key, Encoding encoding)
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

            return ComputeHMAC(algorithm, file, encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(HashType algorithm, FileSystemInfo file, byte[] key)
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
                var hash = HMAC.Create("HMAC" + algorithm);
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
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static bool Validate(HashType algorithm, string originalValue, string hashValue)
        {
            return Validate(algorithm, Encoding.Default.GetBytes(originalValue), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashType algorithm, string originalValue, string hashValue, Encoding encoding)
        {
            return Validate(algorithm, encoding.GetBytes(originalValue), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashType algorithm, byte[] originalValue, string hashValue)
        {
            return string.Equals(Compute(algorithm, originalValue), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Checks the file with a hash.
        /// </summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file that was hashed.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(HashType algorithm, FileSystemInfo file, string hashValue)
        {
            return string.Equals(Compute(algorithm, file), hashValue, StringComparison.CurrentCulture);
        }

        #endregion

        #region ValidateHMAC

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType algorithm, byte[] originalValue, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(algorithm, originalValue, key), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static bool ValidateHMAC(HashType algorithm, string originalValue, string key, string hashValue)
        {
            return ValidateHMAC(algorithm, Encoding.Default.GetBytes(originalValue), Encoding.Default.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType algorithm, string originalValue, string key, string hashValue, Encoding encoding)
        {
            return ValidateHMAC(algorithm, encoding.GetBytes(originalValue), encoding.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static bool ValidateHMAC(HashType algorithm, FileSystemInfo file, string key, string hashValue)
        {
            return string.Equals(ComputeHMAC(algorithm, file, key, Encoding.Default), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType algorithm, FileSystemInfo file, string key, string hashValue, Encoding encoding)
        {
            return string.Equals(ComputeHMAC(algorithm, file, key, encoding), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="HashType"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(HashType algorithm, FileSystemInfo file, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(algorithm, file, key), hashValue, StringComparison.CurrentCulture);
        }

        #endregion
    }
}