using System;

namespace EfficientlyLazy.Crypto
{
    /// <summary>Algorithms used for Data Hashing</summary>
    public enum HashType
    {
        /// <summary>No Hashing</summary>
        None = 0,
        /// <summary>MD5 Hashing</summary>
        [Obsolete("Should not be used as it has been proven insecure", false)]
        MD5 = 5,
        /// <summary>SHA1 Hashing</summary>
        SHA1 = 1,
        /// <summary>SHA256 Hashing</summary>
        SHA256 = 256,
        /// <summary>SHA384 Hashing</summary>
        SHA384 = 384,
        /// <summary>SHA512 Hashing</summary>
        SHA512 = 512,
        /// <summary>RIPEMD160 Hashing</summary>
        RIPEMD160 = 160,
    }
}