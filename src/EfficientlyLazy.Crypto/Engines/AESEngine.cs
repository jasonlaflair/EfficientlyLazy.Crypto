using System.Security;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary>
    /// Encryption/Decryption using <see cref="AesManaged"/>.
    /// </summary>
    /// <remarks>This engine is not available in the v2.0 framework</remarks>
    public sealed class AESEngine : AbstractSymmetricEngine<AESKeySize>
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="AESEngine"/> object.
        ///</summary>
        ///<param name="key">Represents the secret key for the algorithm</param>
        public AESEngine(string key)
            : base(key, AESKeySize.Key256Bit)
        {
            SetInitVector("                ");
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="AESEngine"/> object.
        ///</summary>
        ///<param name="key">Represents the secret key for the algorithm</param>
        public AESEngine(SecureString key)
            : base(key, AESKeySize.Key256Bit)
        {
            SetInitVector("                ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherMode"></param>
        /// <returns></returns>
        protected override SymmetricAlgorithm GenerateAlgorithmEngine(CipherMode cipherMode)
        {
            return new AesManaged
                {
                    Mode = cipherMode
                };
        }
    }
}