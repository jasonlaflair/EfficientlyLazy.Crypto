using System.Data.SqlClient;
using System.Security.Permissions;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Encryption/Decryption interface
    /// </summary>
    public interface ICryptoEngine
    {
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        byte[] Encrypt(byte[] plaintext);

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        string Encrypt(string plaintext);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        byte[] Decrypt(byte[] cipherText);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
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