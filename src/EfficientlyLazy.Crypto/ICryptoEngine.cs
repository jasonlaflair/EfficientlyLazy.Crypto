using System;
using System.Data.SqlClient;
using EfficientlyLazy.Crypto.Configuration;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Encryption/Decryption interface
    /// </summary>
    public interface ICryptoEngine : IDisposable
    {
        /// <summary>
        /// Encrypts the specified byte array.
        /// </summary>
        /// <param name="plaintext">Unencrypted byte array.</param>
        /// <returns>Encrypted byte array</returns>
        byte[] Encrypt(byte[] plaintext);

        /// <summary>
        /// Encrypts the specified unencrypted string.
        /// </summary>
        /// <param name="plaintext">Unencrypted string.</param>
        /// <returns>Encrypted string</returns>
        string Encrypt(string plaintext);

        /// <summary>
        /// Decrypts the specified encrypted byte array.
        /// </summary>
        /// <param name="cipherText">Encrypted byte array</param>
        /// <returns>Decrypted byte array</returns>
        byte[] Decrypt(byte[] cipherText);

        /// <summary>
        /// Decrypts the specified encrypted string
        /// </summary>
        /// <param name="cipherText">Encrypted string</param>
        /// <returns>Decrypted string</returns>
        string Decrypt(string cipherText);

        ///<summary>
        /// Returns the value in the <see cref="SecureSection"/>
        ///</summary>
        ///<param name="key">Value used to identify the <see cref="SecureSetting"/> value</param>
        ///<returns>Returns specified value if exists, returns string.Empty if invalid or missing</returns>
        string GetSetting(string key);

        ///<summary>
        /// Returns the value in the <see cref="SqlConnectionString"/>
        ///</summary>
        ///<param name="key">Value used to identify the <see cref="SqlConnectionString"/> value</param>
        ///<returns>Returns specified <see cref="SqlConnectionStringBuilder"/> value if exists, returns null if invalid or missing</returns>
        SqlConnectionStringBuilder GetSqlConnectionString(string key);
    }
}