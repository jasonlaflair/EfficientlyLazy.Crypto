using System;
using System.Data.SqlClient;

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
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        string GetSetting(string key);

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        SqlConnectionStringBuilder GetSqlConnectionString(string key);
    }
}