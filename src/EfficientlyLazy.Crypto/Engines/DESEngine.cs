using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// Encryption/Decryption using <see cref="System.Security.Cryptography.DESCryptoServiceProvider"/>.
    /// </summary>
    public sealed class DESEngine : AbstractSymmetricEngine<DESKeySize>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public DESEngine(string key)
            : base(key, DESKeySize.Key64Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public DESEngine(SecureString key)
            : base(key, DESKeySize.Key64Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherMode"></param>
        /// <returns></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new DESCryptoServiceProvider
                {
                    Mode = cipherMode
                };
        }
    }
}