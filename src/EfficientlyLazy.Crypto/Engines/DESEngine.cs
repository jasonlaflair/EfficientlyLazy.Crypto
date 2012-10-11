using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// <see cref="ICryptoEngine"/> based on <see cref="DESCryptoServiceProvider"/>.
    /// </summary>
    public sealed class DESEngine : AbstractSymmetricEngine<DESKeySize>
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="DESCryptoServiceProvider"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public DESEngine(string key)
            : base(key, DESKeySize.Key64Bit)
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine"/> based on <see cref="DESCryptoServiceProvider"/>.
        ///</summary>
        ///<param name="key">Represents the key for the algorithm</param>
        public DESEngine(SecureString key)
            : base(key, DESKeySize.Key64Bit)
        {
        }

        /// <summary>
        /// Generates the <see cref="SymmetricAlgorithm"/> based on <see cref="DESCryptoServiceProvider"/>
        /// </summary>
        /// <param name="cipherMode"><see cref="CipherMode"/> set for the generated <see cref="SymmetricAlgorithm"/></param>
        /// <returns><see cref="SymmetricAlgorithm"/> based on <see cref="DESCryptoServiceProvider"/></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new DESCryptoServiceProvider
                {
                    Mode = cipherMode
                };
        }
    }
}