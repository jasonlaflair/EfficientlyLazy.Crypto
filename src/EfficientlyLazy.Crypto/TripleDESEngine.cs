using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto
{
    /// <summary>
    /// Encryption/Decryption using <see cref="TripleDESCryptoServiceProvider"/>.
    /// </summary>
    public sealed class TripleDESEngine : SymmetricEngineBase<TripleDESKeySize>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public TripleDESEngine(string key)
            : base(key, TripleDESKeySize.Key192Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public TripleDESEngine(SecureString key)
            : base(key, TripleDESKeySize.Key192Bit)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherMode"></param>
        /// <returns></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new TripleDESCryptoServiceProvider
                {
                    Mode = cipherMode
                };
        }
    }
}