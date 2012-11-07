using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    ///   <see cref="ISymmetricEngine{T}" /> based on <see cref="RC2CryptoServiceProvider" />.
    /// </summary>
    public sealed class RC2Engine : AbstractSymmetricEngine<RC2KeySize>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine" /> based on <see cref="RC2CryptoServiceProvider" />.
        /// </summary>
        /// <param name="key">Represents the key for the algorithm</param>
        public RC2Engine(string key)
            : base(key, RC2KeySize.Key128Bit)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ICryptoEngine" /> based on <see cref="RC2CryptoServiceProvider" />.
        /// </summary>
        /// <param name="key">Represents the key for the algorithm</param>
        public RC2Engine(SecureString key)
            : base(key, RC2KeySize.Key128Bit)
        {
        }

        /// <summary>
        /// Generates the <see cref="SymmetricAlgorithm" /> based on <see cref="RC2CryptoServiceProvider" />
        /// </summary>
        /// <param name="cipherMode"><see cref="CipherMode" /> set for the generated <see cref="SymmetricAlgorithm" /></param>
        /// <returns>
        ///   <see cref="SymmetricAlgorithm" /> based on <see cref="RC2CryptoServiceProvider" />
        /// </returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new RC2CryptoServiceProvider
                {
                    Mode = cipherMode
                };
        }
    }
}