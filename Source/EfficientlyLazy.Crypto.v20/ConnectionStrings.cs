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
    ///</summary>
    public sealed class SecureConnectionStrings
    {
        private readonly ICryptoEngine _cryptoEngine;

        ///<summary>
        ///</summary>
        ///<param name="cryptoEngine"></param>
        public SecureConnectionStrings(ICryptoEngine cryptoEngine)
        {
            _cryptoEngine = cryptoEngine;
        }

        ///<summary>
        ///</summary>
        ///<param name="connectionStringName"></param>
        ///<returns></returns>
        public IConnectionStringSetting Get(string connectionStringName)
        {
            ConnectionStringSettings current = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (current == null)
            {
                return null;
            }

            ConnectionStringSetting setting = new ConnectionStringSetting
                                              {
                                                  ConnectionString = current.ConnectionString,
                                                  Name = current.Name,
                                                  ProviderName = current.ProviderName
                                              };

            string decrypted;
            if (IsEncrypted(current.ConnectionString, out decrypted))
            {
                setting.ConnectionString = decrypted;
            }

            return setting;
        }

        ///<summary>
        ///</summary>
        ///<param name="connectionStringName"></param>
        ///<param name="connectionString"></param>
        ///<param name="encrypt"></param>
        public void Update(string connectionStringName, string connectionString, bool encrypt)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings settings = config.ConnectionStrings.ConnectionStrings[connectionStringName];

            if (settings == null)
            {
                throw new ArgumentException("connectionStringName not found", "connectionStringName");
            }

            settings.ConnectionString = encrypt ? _cryptoEngine.Encrypt(connectionString) : connectionString;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");
        }

        ///<summary>
        ///</summary>
        ///<param name="connectionStringName"></param>
        public void Encrypt(string connectionStringName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings setting = config.ConnectionStrings.ConnectionStrings[connectionStringName];

            string encrypted;
            if (!IsDecrypted(setting.ConnectionString, out encrypted))
            {
                return;
            }
            
            setting.ConnectionString = encrypted;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");
        }

        ///<summary>
        ///</summary>
        ///<param name="connectionStringName"></param>
        public void Decrypt(string connectionStringName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings setting = config.ConnectionStrings.ConnectionStrings[connectionStringName];

            string decrypted;
            if (!IsEncrypted(setting.ConnectionString, out decrypted))
            {
                return;
            }
            
            setting.ConnectionString = decrypted;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private bool IsEncrypted(string encryptedText, out string decryptedText)
        {
            bool isEncrypted;

            try
            {
                decryptedText = _cryptoEngine.Decrypt(encryptedText);
                isEncrypted = true;
            }
            catch (Exception)
            {
                decryptedText = string.Empty;
                isEncrypted = false;
            }

            return isEncrypted;
        }

        private bool IsDecrypted(string decryptedText, out string encryptedText)
        {
            bool isDecrypted;

            try
            {
                _cryptoEngine.Decrypt(decryptedText);
                encryptedText = string.Empty;
                isDecrypted = false;
            }
            catch (Exception)
            {
                encryptedText = _cryptoEngine.Encrypt(decryptedText);
                isDecrypted = true;
            }

            return isDecrypted;
        }
    }
}