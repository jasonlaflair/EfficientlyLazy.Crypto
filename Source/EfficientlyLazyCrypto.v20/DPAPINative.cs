using System;
using System.Runtime.InteropServices;

namespace EfficientlyLazyCrypto
{
    ///<summary>
    /// Native methods used for DPAPI encryption and decryption.
    ///</summary>
    internal class DPAPINative
    {
        #region DPAPI Native Methods

        ///<summary>
        /// Performs encryption on the data in a <see cref="DPAPINativeDATABLOB"/> structure
        ///</summary>
        ///<param name="plainText">Structure that contains the plaintext to be encrypted.</param>
        ///<param name="description">A readable description of the data to be encrypted.</param>
        ///<param name="entropy">Structure that contains a password or other additional entropy used to encrypt the data.</param>
        ///<param name="reserved">Reserved for future use and must be set to NULL.</param>
        ///<param name="prompt">Structure that provides information about where and when prompts are to be displayed and what the content of those prompts should be.</param>
        ///<param name="flags">Crypt Protection</param>
        ///<param name="cipherText">Structure that receives the encrypted data.</param>
        ///<returns>If the function succeeds, then <c>TRUE</c> else <c>FALSE</c>.</returns>
        public bool ProtectData(ref DPAPINativeDATABLOB plainText,
                                string description,
                                ref DPAPINativeDATABLOB entropy,
                                IntPtr reserved,
                                ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                int flags,
                                ref DPAPINativeDATABLOB cipherText)
        {
            return CryptProtectData(ref plainText, description, ref entropy, reserved, ref prompt, flags, ref cipherText);
        }


        // Wrapper for DPAPI CryptProtectData function.
        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptProtectData(ref DPAPINativeDATABLOB plainText,
                                                    string description,
                                                    ref DPAPINativeDATABLOB entropy,
                                                    IntPtr reserved,
                                                    ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                                    int flags,
                                                    ref DPAPINativeDATABLOB cipherText);

        ///<summary>
        /// Decrypts and does an integrity check of the data in a <see cref="DPAPINativeDATABLOB"/> structure
        ///</summary>
        ///<param name="cipherText">Structure that contains the encrypted data.</param>
        ///<param name="description">A readable description of the data to be encrypted.</param>
        ///<param name="entropy">Structure that contains a password or other additional entropy used to encrypt the data.</param>
        ///<param name="reserved">Reserved for future use and must be set to NULL.</param>
        ///<param name="prompt">Structure that provides information about where and when prompts are to be displayed and what the content of those prompts should be.</param>
        ///<param name="flags">Crypt Protection</param>
        ///<param name="plainText">Structure that receives the decrypted data.</param>
        ///<returns>If the function succeeds, then <c>TRUE</c> else <c>FALSE</c>.</returns>
        public bool UnprotectData(ref DPAPINativeDATABLOB cipherText,
                                  ref string description,
                                  ref DPAPINativeDATABLOB entropy,
                                  IntPtr reserved,
                                  ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                  int flags,
                                  ref DPAPINativeDATABLOB plainText)
        {
            return CryptUnprotectData(ref cipherText, ref description, ref entropy, reserved, ref prompt, flags, ref plainText);
        }

        // Wrapper for DPAPI CryptUnprotectData function.
        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptUnprotectData(ref DPAPINativeDATABLOB cipherText,
                                                      ref string description,
                                                      ref DPAPINativeDATABLOB entropy,
                                                      IntPtr reserved,
                                                      ref DPAPINativeCRYPTPROTECTPROMPTSTRUCT prompt,
                                                      int flags,
                                                      ref DPAPINativeDATABLOB plainText);

        #endregion

        #region DPAPI Structures

        ///<summary>
        /// Structure that holds the encrypted data.
        ///</summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DPAPINativeDATABLOB : IDisposable
        {
            ///<summary>
            /// Holds the length of the data
            ///</summary>
            public int DataLength { get; set; }

            ///<summary>
            /// Pointer to the byte string that contains the text to be encrypted.
            ///</summary>
            public IntPtr DataPointer { get; set; }

            ///<summary>
            /// Creates an empty DATA_BLOB.
            ///</summary>
            ///<returns>An empty DATA_BLOB</returns>
            public static DPAPINativeDATABLOB Null()
            {
                return new DPAPINativeDATABLOB
                {
                    DataLength = 0,
                    DataPointer = IntPtr.Zero
                };
            }

            ///<summary>
            /// Creates the structure that holds byte[] data to be encrypted.
            ///</summary>
            ///<param name="data">Data to be encrypted.</param>
            ///<returns>Structure that holds byte[] data to be encrypted.</returns>
            ///<exception cref="MemberAccessException">Unable to allocate data buffer for BLOB structure</exception>
            public static DPAPINativeDATABLOB Init(byte[] data)
            {
                // Use empty array for null parameter.
                if (data == null) data = new byte[0];

                var blob = new DPAPINativeDATABLOB
                {
                    DataPointer = Marshal.AllocHGlobal(data.Length),
                    DataLength = data.Length
                };

                // Make sure that memory allocation was successful.
                // With the null check on the data parameter, I don't think this is needed.
                //if (blob.pbData == IntPtr.Zero)
                //    throw new MemberAccessException("Unable to allocate data buffer for BLOB structure.");

                // Copy data from original source to the BLOB structure.
                Marshal.Copy(data, 0, blob.DataPointer, data.Length);

                return blob;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                if (DataPointer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(DataPointer);
                }

                GC.SuppressFinalize(this);
            }
        }

        ///<summary>
        /// Indicates when prompts to the user are to be displayed.
        ///</summary>
        [Flags]
        internal enum DPAPINativeCryptProtectPromptFlags
        {
            ///<summary>
            /// This flag can be combined with CRYPTPROTECT_PROMPT_ON_PROTECT to enforce the UI (user interface) policy of the caller. When CryptUnprotectData is called, the dwPromptFlags specified in the CryptProtectData call are enforced.
            ///</summary>
            PromptOnUnprotect = 0x1,

            ///<summary>
            /// This flag is used to provide the prompt for the protect phase.
            ///</summary>
            PromptOnProtect = 0x2
        }

        /// <summary>
        /// Provides the text of a prompt and information about when and where that prompt is to be displayed when using the CryptProtectData and CryptUnprotectData functions.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DPAPINativeCRYPTPROTECTPROMPTSTRUCT : IDisposable
        {
            /// <summary>
            /// The size, in bytes, of this structure.
            /// </summary>
            public int Size { get; set; }

            /// <summary>
            /// Indicates when prompts to the user are to be displayed.
            /// </summary>
            public DPAPINativeCryptProtectPromptFlags PromptFlags { get; set; }

            /// <summary>
            /// Window handle to the parent window.
            /// </summary>
            public IntPtr Handle { get; set; }

            /// <summary>
            /// A string containing the text of a prompt to be displayed.
            /// </summary>
            public string Prompt { get; set; }

            ///<summary>
            /// Creates a default instance of CRYPTPROTECT_PROMPTSTRUCT.
            ///</summary>
            ///<returns>The default instance of CRYPTPROTECT_PROMPTSTRUCT</returns>
            public static DPAPINativeCRYPTPROTECTPROMPTSTRUCT Default()
            {
                return new DPAPINativeCRYPTPROTECTPROMPTSTRUCT
                {
                    Size = Marshal.SizeOf(typeof(DPAPINativeCRYPTPROTECTPROMPTSTRUCT)),
                    PromptFlags = 0,
                    Handle = IntPtr.Zero,
                    Prompt = null
                };
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                if (Handle != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(Handle);
                }

                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}