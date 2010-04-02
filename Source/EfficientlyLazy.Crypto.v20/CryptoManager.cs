using System;

namespace EfficientlyLazy.Crypto
{
    ///<summary>
    ///</summary>
    public static class CryptoManager
    {
        private static ICryptoEngine _engine;

        ///<summary>
        ///</summary>
        ///<param name="engine"></param>
        public static void Initialize(ICryptoEngine engine)
        {
            _engine = engine;
        }

        private static void ValidateInitialization()
        {
            if (_engine == null)
            {
                throw new InvalidOperationException("CryptoManager has not been Initialized");
            }
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] plaintext)
        {
            ValidateInitialization();

            return _engine.Encrypt(plaintext);
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public static string Encrypt(string plaintext)
        {
            ValidateInitialization();

            return _engine.Encrypt(plaintext);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] cipherText)
        {
            ValidateInitialization();

            return _engine.Decrypt(cipherText);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            ValidateInitialization();

            return _engine.Decrypt(cipherText);
        }

        ///<summary>
        ///</summary>
        ///<param name="key">Key name given to the setting in the config file.</param>
        ///<returns>The setting value if available, if not, String.Empty is returned.</returns>
        public static string GetSettingFromConfiguration(string key)
        {
            ValidateInitialization();

            return _engine.GetSettingFromConfiguration(key);
        }

        ///<summary>
        ///</summary>
        ///<param name="key">Name given to the setting in the config file.</param>
        ///<param name="defaultValue">Value returned if the setting key is not found.</param>
        ///<returns>The setting value if available, if not, the defaultValue is returned.</returns>
        public static string GetSettingFromConfiguration(string key, string defaultValue)
        {
            ValidateInitialization();

            return _engine.GetSettingFromConfiguration(key, defaultValue);
        }

        ///<summary>
        ///</summary>
        ///<param name="alias">Alias name given to the connection string in the config file.</param>
        ///<returns>The connection string value if available, if not, String.Empty is returned.</returns>
        public static string GetConnectionStringFromConfiguration(string alias)
        {
            ValidateInitialization();

            return _engine.GetConnectionStringFromConfiguration(alias);
        }

        ///<summary>
        ///</summary>
        ///<param name="alias">Alias given to the connection string in the config file.</param>
        ///<param name="defaultValue">Value returned if the connection string alias is not found.</param>
        ///<returns>The connection string value if available, if not, the defaultValue is returned.</returns>
        public static string GetConnectionStringFromConfiguration(string alias, string defaultValue)
        {
            ValidateInitialization();

            return _engine.GetConnectionStringFromConfiguration(alias, defaultValue);
        }
    }
}
