namespace EfficientlyLazy.Crypto
{
    ///<summary>
    ///</summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public static byte[] Encrypt(this byte[] plaintext)
        {
            return CryptoManager.Encrypt(plaintext);
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plaintext">The plain text.</param>
        /// <returns></returns>
        public static string Encrypt(this string plaintext)
        {
            return CryptoManager.Encrypt(plaintext);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static byte[] Decrypt(this byte[] cipherText)
        {
            return CryptoManager.Decrypt(cipherText);
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static string Decrypt(this string cipherText)
        {
            return CryptoManager.Decrypt(cipherText);
        }
    }
}
