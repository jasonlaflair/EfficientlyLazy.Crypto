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
    using System.Configuration;

    ///<summary>
    /// Simple class that allows access to the <see cref="ConnectionStringsSection"/> and
    /// save/update connection strings to be stored encrypted, yet being able to access them
    /// as if they stored in clear text.
    ///</summary>
    public sealed class SecuredConnectionStrings
    {
        private readonly ICryptoEngine _cryptoEngine;

        ///<summary>
        /// Initializes a new instance of the <see cref="SecuredConnectionStrings"/> object.
        ///</summary>
        ///<param name="cryptoEngine">The <see cref="ICryptoEngine"/> to use for encryption/decryption.</param>
        public SecuredConnectionStrings(ICryptoEngine cryptoEngine)
        {
            _cryptoEngine = cryptoEngine;
        }

        ///<summary>
        /// Gets the <see cref="SecuredConnectionStringSetting"/> and decrypts the connection string based on the provided <see cref="ICryptoEngine"/>.
        ///</summary>
        ///<param name="cryptoEngine">The <see cref="ICryptoEngine"/> to use for encryption/decryption.</param>
        ///<param name="connectionStringName">Name of the connection string to get.</param>
        ///<returns>A new instance of <see cref="SecuredConnectionStringSetting"/></returns>
        public static SecuredConnectionStringSetting Get(ICryptoEngine cryptoEngine, string connectionStringName)
        {
            SecuredConnectionStrings secureConnectionStrings = new SecuredConnectionStrings(cryptoEngine);

            return secureConnectionStrings.Get(connectionStringName);
        }

        ///<summary>
        /// Gets the <see cref="SecuredConnectionStringSetting"/> and decrypts the connection string.
        ///</summary>
        ///<param name="connectionStringName">Name of the connection string to get.</param>
        ///<returns>A new instance of <see cref="SecuredConnectionStringSetting"/></returns>
        public SecuredConnectionStringSetting Get(string connectionStringName)
        {
            ConnectionStringSettings current = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (current == null)
            {
                return new SecuredConnectionStringSetting();
            }

            SecuredConnectionStringSetting setting = new SecuredConnectionStringSetting
                                              {
                                                  ConnectionString = current.ConnectionString,
                                                  Name = current.Name,
                                                  ProviderName = current.ProviderName
                                              };

            try
            {
                string clearText = _cryptoEngine.Decrypt(setting.ConnectionString);
                setting.ConnectionString = clearText;
                setting.State = ConnectionStringStates.Decrypted;
            }
            catch
            {
                setting.State = ConnectionStringStates.ClearText;
            }

            return setting;
        }

        ///<summary>
        /// Updates and existing connection string with a new value.  Can be updated as clear text or encrypted.
        ///</summary>
        ///<param name="connectionStringName">Name of the connection string to update. (must already exist)</param>
        ///<param name="connectionString">Connection string</param>
        ///<param name="storeEncrypt">set to <c>true</c> to store encrypted, otherwise will be stored in clear text</param>
        ///<exception cref="ArgumentException">The connectionStringName does not exist.</exception>
        public void Update(string connectionStringName, string connectionString, bool storeEncrypt)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings current = config.ConnectionStrings.ConnectionStrings[connectionStringName];

            if (current == null)
            {
                throw new ArgumentException("connectionStringName not found", "connectionStringName");
            }

            current.ConnectionString = storeEncrypt ? _cryptoEngine.Encrypt(connectionString) : connectionString;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}