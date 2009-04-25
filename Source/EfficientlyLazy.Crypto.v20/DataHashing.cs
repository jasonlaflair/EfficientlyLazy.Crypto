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
namespace EfficientlyLazy.Crypto
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Data Hashing
    /// </summary>
    public static class DataHashing
    {
        /// <summary>Generates the hash of a text.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static string Compute(Algorithm algorithm, string plaintext)
        {
            return Compute(algorithm, plaintext, Encoding.Default);
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(Algorithm algorithm, string plaintext, Encoding encoding)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            return Compute(algorithm, encoding.GetBytes(plaintext));
        }

        /// <summary>Generates the hash of a text.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string Compute(Algorithm algorithm, byte[] plaintext)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }

            byte[] hashValue = HashAlgorithm.Create(algorithm.ToString()).ComputeHash(plaintext);

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
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static string ComputeHMAC(Algorithm algorithm, string plaintext, string key)
        {
            return ComputeHMAC(algorithm, plaintext, key, Encoding.Default);
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(Algorithm algorithm, string plaintext, string key, Encoding encoding)
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

            return ComputeHMAC(algorithm, encoding.GetBytes(plaintext), encoding.GetBytes(key));
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="plaintext">The input to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(Algorithm algorithm, byte[] plaintext, byte[] key)
        {
            if (plaintext == null)
            {
                throw new ArgumentNullException("plainText", "plainText cannot be null");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key", "key cannot be null");
            }

            HMAC hash = HMAC.Create("HMAC" + algorithm);
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
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static string ComputeHMAC(Algorithm algorithm, FileSystemInfo file, string key)
        {
            return ComputeHMAC(algorithm, file, key, Encoding.Default);
        }

        /// <summary>
        /// Hash-based Message Authentication Code Hashing
        /// </summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(Algorithm algorithm, FileSystemInfo file, string key, Encoding encoding)
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
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <returns>Hashed string</returns>
        public static string ComputeHMAC(Algorithm algorithm, FileSystemInfo file, byte[] key)
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
                HMAC hash = HMAC.Create("HMAC" + algorithm);
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
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compute the hash code for.</param>
        /// <returns>Hashed string</returns>
        public static string Compute(Algorithm algorithm, FileSystemInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file", "file cannot be null");
            }

            string strRet = string.Empty;

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                byte[] hashValue = HashAlgorithm.Create(algorithm.ToString()).ComputeHash(fs);

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
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(Algorithm algorithm, byte[] originalValue, string hashValue)
        {
            return string.Equals(Compute(algorithm, originalValue), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static bool Validate(Algorithm algorithm, string originalValue, string hashValue)
        {
            return Validate(algorithm, Encoding.Default.GetBytes(originalValue), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(Algorithm algorithm, string originalValue, string hashValue, Encoding encoding)
        {
            return Validate(algorithm, encoding.GetBytes(originalValue), hashValue);
        }

        /// <summary>
        /// Checks the file with a hash.
        /// </summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file that was hashed.</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool Validate(Algorithm algorithm, FileSystemInfo file, string hashValue)
        {
            return string.Equals(Compute(algorithm, file), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(Algorithm algorithm, byte[] originalValue, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(algorithm, originalValue, key), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static bool ValidateHMAC(Algorithm algorithm, string originalValue, string key, string hashValue)
        {
            return ValidateHMAC(algorithm, Encoding.Default.GetBytes(originalValue), Encoding.Default.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="originalValue">The text to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(Algorithm algorithm, string originalValue, string key, string hashValue, Encoding encoding)
        {
            return ValidateHMAC(algorithm, encoding.GetBytes(originalValue), encoding.GetBytes(key), hashValue);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        /// <remarks>Using Encoding.Default for character encoding</remarks>
        public static bool ValidateHMAC(Algorithm algorithm, FileSystemInfo file, string key, string hashValue)
        {
            return string.Equals(ComputeHMAC(algorithm, file, key, Encoding.Default), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <param name="encoding">Character encoding to use.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(Algorithm algorithm, FileSystemInfo file, string key, string hashValue, Encoding encoding)
        {
            return string.Equals(ComputeHMAC(algorithm, file, key, encoding), hashValue, StringComparison.CurrentCulture);
        }

        /// <summary>Checks a text with a hash.</summary>
        /// <param name="algorithm"><see cref="Algorithm"/> to use.</param>
        /// <param name="file">The file to compare the hash against.</param>
        /// <param name="key">Key to use in the hash algorithm</param>
        /// <param name="hashValue">The hash to compare against.</param>
        /// <returns>True if the hash validates, false otherwise.</returns>
        public static bool ValidateHMAC(Algorithm algorithm, FileSystemInfo file, byte[] key, string hashValue)
        {
            return string.Equals(ComputeHMAC(algorithm, file, key), hashValue, StringComparison.CurrentCulture);
        }
    }
}