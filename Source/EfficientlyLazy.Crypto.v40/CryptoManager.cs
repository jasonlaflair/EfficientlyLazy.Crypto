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
