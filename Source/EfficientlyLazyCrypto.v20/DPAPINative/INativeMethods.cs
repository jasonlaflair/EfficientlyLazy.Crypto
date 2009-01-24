using System;

namespace EfficientlyLazyCrypto.DPAPINative
{
    ///<summary>
    /// Native methods used for DPAPI encryption and decryption.
    ///</summary>
    public interface INativeMethods
    {
        ///<summary>
        /// Performs encryption on the data in a <see cref="DATA_BLOB"/> structure
        ///</summary>
        ///<param name="plainText">Structure that contains the plaintext to be encrypted.</param>
        ///<param name="description">A readable description of the data to be encrypted.</param>
        ///<param name="entropy">Structure that contains a password or other additional entropy used to encrypt the data.</param>
        ///<param name="reserved">Reserved for future use and must be set to NULL.</param>
        ///<param name="prompt">Structure that provides information about where and when prompts are to be displayed and what the content of those prompts should be.</param>
        ///<param name="flags">Crypt Protection</param>
        ///<param name="cipherText">Structure that receives the encrypted data.</param>
        ///<returns>If the function succeeds, then <c>TRUE</c> else <c>FALSE</c>.</returns>
        bool ProtectData(ref DATA_BLOB plainText,
                         string description,
                         ref DATA_BLOB entropy,
                         IntPtr reserved,
                         ref CRYPTPROTECT_PROMPTSTRUCT prompt,
                         int flags,
                         ref DATA_BLOB cipherText);

        ///<summary>
        /// Decrypts and does an integrity check of the data in a <see cref="DATA_BLOB"/> structure
        ///</summary>
        ///<param name="cipherText">Structure that contains the encrypted data.</param>
        ///<param name="description">A readable description of the data to be encrypted.</param>
        ///<param name="entropy">Structure that contains a password or other additional entropy used to encrypt the data.</param>
        ///<param name="reserved">Reserved for future use and must be set to NULL.</param>
        ///<param name="prompt">Structure that provides information about where and when prompts are to be displayed and what the content of those prompts should be.</param>
        ///<param name="flags">Crypt Protection</param>
        ///<param name="plainText">Structure that receives the decrypted data.</param>
        ///<returns>If the function succeeds, then <c>TRUE</c> else <c>FALSE</c>.</returns>
        bool UnprotectData(ref DATA_BLOB cipherText,
                           ref string description,
                           ref DATA_BLOB entropy,
                           IntPtr reserved,
                           ref CRYPTPROTECT_PROMPTSTRUCT prompt,
                           int flags,
                           ref DATA_BLOB plainText);
    }
}