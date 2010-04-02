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
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    ///<summary>
    /// Encryption/Decryption using <see cref="RSACryptoServiceProvider"/> with <see cref="X509Certificate2"/>.
    ///</summary>
    public class CertificateEngine : ICryptoEngine
    {
        private readonly RSACryptoServiceProvider _cryptoServiceProvider;

        ///<summary>
        /// Initializes a new instance of the <see cref="CertificateEngine"/> object.
        ///</summary>
        ///<param name="fileName">The name of a certificate file.</param>
        ///<param name="password">The password required to access the X.509 certificate data.</param>
        ///<param name="keyStorageFlags">One of the <see cref="X509KeyStorageFlags"/> values.</param>
        /// <exception cref="CryptographicException">
        /// <list type="bullet">
        /// <item><description>The certificate file does not exist.</description></item>
        /// <item><description></description>The certificate is invalid.</item>
        /// <item><description></description>The certificate's password is incorrect.</item>
        /// </list>
        /// </exception>
        public CertificateEngine(string fileName, string password, X509KeyStorageFlags keyStorageFlags)
        {
            X509Certificate2 certificate = new X509Certificate2(fileName, password, keyStorageFlags);

            _cryptoServiceProvider = (RSACryptoServiceProvider)certificate.PrivateKey;

            Encoding = Encoding.Default;
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="CertificateEngine"/> object.
        ///</summary>
        ///<param name="fileName">The name of a certificate file.</param>
        ///<param name="password">The password required to access the X.509 certificate data.</param>
        ///<param name="keyStorageFlags">One of the <see cref="X509KeyStorageFlags"/> values.</param>
        /// <exception cref="CryptographicException">
        /// <list type="bullet">
        /// <item><description>The certificate file does not exist.</description></item>
        /// <item><description></description>The certificate is invalid.</item>
        /// <item><description></description>The certificate's password is incorrect.</item>
        /// </list>
        /// </exception>
        public CertificateEngine(string fileName, SecureString password, X509KeyStorageFlags keyStorageFlags)
        {
            X509Certificate2 certificate = new X509Certificate2(fileName, password, keyStorageFlags);

            _cryptoServiceProvider = (RSACryptoServiceProvider)certificate.PrivateKey;

            Encoding = Encoding.Default;
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="CertificateEngine"/> object.
        ///</summary>
        ///<param name="storeName">One of the <see cref="StoreName"/> values.</param>
        ///<param name="storeLocation">One of the <see cref="StoreLocation"/> values.</param>
        ///<param name="findType">One of the <see cref="X509FindType"/> values.</param>
        ///<param name="findValue">The search criteria as an object.</param>
        ///<param name="validOnly"><c>true</c> to allow only valid certificates to be returned from the search; otherwise, <c>false</c>.</param>
        /// <exception cref="CryptographicException">The store is unreadable.</exception>
        /// <exception cref="CryptographicException">Multiple or no certifcates were found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="ArgumentException">The store contains invalid values.</exception>
        public CertificateEngine(StoreName storeName, StoreLocation storeLocation, X509FindType findType, object findValue, bool validOnly)
        {
            X509Store store = new X509Store(storeName, storeLocation);

            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certificates = store.Certificates.Find(findType, findValue, validOnly);

            if (certificates.Count == 0)
            {
                throw new CryptographicException("No certificate was found");
            }

            if (certificates.Count > 1)
            {
                throw new CryptographicException(string.Format("Multiple {0} certificates found", certificates.Count));
            }

            X509Certificate2 certificate = certificates[0];

            _cryptoServiceProvider = (RSACryptoServiceProvider)certificate.PrivateKey;

            Encoding = Encoding.Default;
        }

        ///<summary>
        /// Represents the character encoding
        ///</summary>
        public Encoding Encoding { get; private set; }

        #region ICryptoEngine Members

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public virtual byte[] Encrypt(byte[] plaintext)
        {
            return _cryptoServiceProvider.Encrypt(plaintext, false);
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public virtual string Encrypt(string plaintext)
        {
            return Convert.ToBase64String(Encrypt(Encoding.GetBytes(plaintext)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public virtual byte[] Decrypt(byte[] cipherText)
        {
            return _cryptoServiceProvider.Decrypt(cipherText, false);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public virtual string Decrypt(string cipherText)
        {
            return Encoding.GetString(Decrypt(Convert.FromBase64String(cipherText)));
        }

        #endregion

        ///<summary>
        /// Sets the character encoding
        ///</summary>
        ///<param name="encoding">The character encoding</param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public CertificateEngine SetEncoding(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            Encoding = encoding;

            return this;
        }
    }
}