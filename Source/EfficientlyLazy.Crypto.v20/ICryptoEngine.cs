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
    using System.Security.Permissions;

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
        ///<param name="key">Key name given to the setting in the config file.</param>
        ///<returns>The setting value if available, if not, String.Empty is returned.</returns>
        string GetSettingFromConfiguration(string key);
        
        ///<summary>
        ///</summary>
        ///<param name="key">Name given to the setting in the config file.</param>
        ///<param name="defaultValue">Value returned if the setting key is not found.</param>
        ///<returns>The setting value if available, if not, the defaultValue is returned.</returns>
        string GetSettingFromConfiguration(string key, string defaultValue);

        ///<summary>
        ///</summary>
        ///<param name="alias">Alias name given to the connection string in the config file.</param>
        ///<returns>The connection string value if available, if not, String.Empty is returned.</returns>
        string GetConnectionStringFromConfiguration(string alias);

        ///<summary>
        ///</summary>
        ///<param name="alias">Alias given to the connection string in the config file.</param>
        ///<param name="defaultValue">Value returned if the connection string alias is not found.</param>
        ///<returns>The connection string value if available, if not, the defaultValue is returned.</returns>
        string GetConnectionStringFromConfiguration(string alias, string defaultValue);
    }
}