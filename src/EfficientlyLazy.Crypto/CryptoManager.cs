using System;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Static manager to wrap the specified ICryptoEngine.
    /// </summary>
    public static class CryptoManager
    {
        private static ICryptoEngine _engine;

        /// <summary>
        /// Initializes the CryptoEngine to use.
        /// </summary>
        /// <param name="engine">CryptoEngine to use</param>
        public static void Initialize(ICryptoEngine engine)
        {
            _engine = engine;   
        }

        private static void CheckInitialization()
        {
            if (_engine != null)
            {
                return;
            }

            throw new InvalidOperationException("Initialize has not yet been called");
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] plaintext)
        {
            CheckInitialization();

            return _engine.Encrypt(plaintext);
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public static string Encrypt(string plaintext)
        {
            CheckInitialization();

            return _engine.Encrypt(plaintext);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] cipherText)
        {
            CheckInitialization();

            return _engine.Decrypt(cipherText);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            CheckInitialization();

            return _engine.Decrypt(cipherText);
        }
    }
}
