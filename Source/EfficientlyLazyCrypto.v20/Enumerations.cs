using System.Security.Cryptography;

namespace EfficientlyLazyCrypto
{
    /// <summary>Algorithms used for Data Hashing</summary>
    public enum HashingAlgorithm
    {
        ///// <summary>MD5 Hashing</summary>
        //MD5 = 5,
        /// <summary>SHA1 Hashing</summary>
        SHA1 = 1,
        /// <summary>SHA256 Hashing</summary>
        SHA256 = 256,
        /// <summary>SHA384 Hashing</summary>
        SHA384 = 384,
        /// <summary>SHA512 Hashing</summary>
        SHA512 = 512
    }

    /// <summary>DPAPI Key Type</summary>
    public enum DPAPIKeyType
    {
        /// <summary>Encrypt at the User Level</summary>
        UserKey = 1,
        /// <summary>Encrypt at the Machine Level</summary>
        MachineKey = 0
    }

    /// <summary><see cref="Rijndael"/> Key Size</summary>
    public enum RijndaelKeySize
    {
        /// <summary>128bit key length</summary>
        Key128Bit = 128,
        /// <summary>192bit key length</summary>
        Key192Bit = 192,
        /// <summary>256bit key length</summary>
        Key256Bit = 256
    }
}