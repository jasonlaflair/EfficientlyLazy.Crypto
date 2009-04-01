using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace EfficientlyLazyCrypto
{
    /// <summary>Algorithms used for Data Hashing</summary>
    public enum HashingAlgorithm
    {
        /// <summary>MD5 Hashing</summary>
        [Obsolete("Should not be used as it has been proven insecure", true)]
        MD5 = 5,
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
        [Description("User Level")]
        UserKey = 1,
        /// <summary>Encrypt at the Machine Level</summary>
        [Description("Machine Level")]
        MachineKey = 0
    }

    /// <summary><see cref="Rijndael"/> Key Size</summary>
    public enum RijndaelKeySize
    {
        /// <summary>128bit key length</summary>
        [Description("128bit")]
        Key128Bit = 128,
        /// <summary>192bit key length</summary>
        [Description("192bit")]
        Key192Bit = 192,
        /// <summary>256bit key length</summary>
        [Description("256bit")]
        Key256Bit = 256
    }
}