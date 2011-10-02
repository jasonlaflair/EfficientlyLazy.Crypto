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

        /////<summary>
        /////</summary>
        /////<param name="key">Key name given to the setting in the config file.</param>
        /////<returns>The setting value if available, if not, String.Empty is returned.</returns>
        //string GetSettingFromConfiguration(string key);
        
        /////<summary>
        /////</summary>
        /////<param name="key">Name given to the setting in the config file.</param>
        /////<param name="defaultValue">Value returned if the setting key is not found.</param>
        /////<returns>The setting value if available, if not, the defaultValue is returned.</returns>
        //string GetSettingFromConfiguration(string key, string defaultValue);

        /////<summary>
        /////</summary>
        /////<param name="alias">Alias name given to the connection string in the config file.</param>
        /////<returns>The connection string value if available, if not, String.Empty is returned.</returns>
        //string GetConnectionStringFromConfiguration(string alias);

        /////<summary>
        /////</summary>
        /////<param name="alias">Alias given to the connection string in the config file.</param>
        /////<param name="defaultValue">Value returned if the connection string alias is not found.</param>
        /////<returns>The connection string value if available, if not, the defaultValue is returned.</returns>
        //string GetConnectionStringFromConfiguration(string alias, string defaultValue);
    }
}