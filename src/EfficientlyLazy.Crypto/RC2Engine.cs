using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Encryption/Decryption using <see cref="System.Security.Cryptography.RC2CryptoServiceProvider"/>.
    /// </summary>
    public sealed class RC2Engine : SymmetricEngineBase<RC2KeySize>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public RC2Engine(string key)
            : base(key, RC2KeySize.Key128Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public RC2Engine(SecureString key)
            : base(key, RC2KeySize.Key128Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherMode"></param>
        /// <returns></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new RC2CryptoServiceProvider
                {
                    Mode = cipherMode
                };
        }
    }
}