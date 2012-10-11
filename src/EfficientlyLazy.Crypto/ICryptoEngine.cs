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
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        byte[] Encrypt(byte[] plaintext);

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        string Encrypt(string plaintext);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        byte[] Decrypt(byte[] cipherText);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
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