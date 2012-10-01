using System.ComponentModel;
using System.Security.Cryptography;

namespace EfficientlyLazy.Crypto.Engines
{
    /// <summary><see cref="DES"/> Key Size</summary>
    public enum DESKeySize
    {
        /// <summary>64bit key length</summary>
        [Description("64bit")]
        Key64Bit = 64
    }
}