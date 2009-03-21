using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Security;
using System.Security.Permissions;

namespace EfficientlyLazyCrypto
{
    /// <summary>
    /// Encryption/Decryption using the windows crypto API.
    /// </summary>
    public sealed class DPAPIEngine : ICryptoEngine
    {
        private readonly DPAPINative_Methods _nativeMethods = new DPAPINative_Methods();

        ///<summary>
        ///</summary>
        public SecureString Entropy { get; private set; }
        ///<summary>
        ///</summary>
        public DPAPIKeyType KeyType { get; private set; }
        ///<summary>
        ///</summary>
        public Encoding Encoding { get; private set; }

        ///<summary>
        ///</summary>
        ///<param name="keyType"></param>
        public DPAPIEngine(DPAPIKeyType keyType)
        {
            KeyType = keyType;
            Entropy = ToSecureString(string.Empty);
            Encoding = Encoding.UTF8;
        }

        ///<summary>
        ///</summary>
        ///<param name="entropy"></param>
        ///<returns></returns>
        public DPAPIEngine SetEntropy(string entropy)
        {
            Entropy = ToSecureString(entropy);

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="entropy"></param>
        ///<returns></returns>
        public DPAPIEngine SetEntropy(SecureString entropy)
        {
            entropy.MakeReadOnly();
            Entropy = entropy;

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="keyType"></param>
        ///<returns></returns>
        public DPAPIEngine SetKeyType(DPAPIKeyType keyType)
        {
            KeyType = keyType;

            return this;
        }

        ///<summary>
        ///</summary>
        ///<param name="encoding"></param>
        ///<returns></returns>
        ///<exception cref="ArgumentNullException"></exception>
        public DPAPIEngine SetEncoding(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding", "encoding cannot be null");
            }

            Encoding = encoding;

            return this;
        }

        /// <summary>
        /// Encrypts the specified plain text to a byte array.
        /// </summary>
        /// <param name="plaintext">The plain text to encrypt.</param>
        /// <returns>Byte array of encrypted data.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public byte[] Encrypt(byte[] plaintext)
        {
            return DPAPI_Encrypt(KeyType, plaintext, Encoding.GetBytes(ToString(Entropy)));
        }

        /// <summary>
        /// Encrypts the specified plain text to a string.
        /// </summary>
        /// <param name="plaintext">The plain text to encrypt.</param>
        /// <returns>String of encrypted data.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string Encrypt(string plaintext)
        {
            return Convert.ToBase64String(Encrypt(Encoding.GetBytes(plaintext)));
        }

        /// <summary>
        /// Encrypts the specified input file.
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="outputFile">The encrypted file.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool Encrypt(string inputFile, string outputFile)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public byte[] Decrypt(byte[] cipherText)
        {
            return DPAPI_Decrypt(cipherText, Encoding.GetBytes(ToString(Entropy)));
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public string Decrypt(string cipherText)
        {
            return Encoding.GetString(Decrypt(Convert.FromBase64String(cipherText)));
        }

        /// <summary>
        /// Decrypts the specified encrypted file.
        /// </summary>
        /// <param name="inputFile">The encrypted file.</param>
        /// <param name="outputFile">The output file.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool Decrypt(string inputFile, string outputFile)
        {
            throw new NotImplementedException();
        }

        #region DPAPI Helper functions

        // DPAPI key initialization flags.
        private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;
        private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private byte[] DPAPI_Encrypt(DPAPIKeyType keyType, byte[] plainTextBytes, byte[] entropyBytes)
        {
            // Create Null BLOBs to hold data, they will be initialized later.
            var plainTextBlob = DPAPINative_DATA_BLOB.Null();
            var cipherTextBlob = DPAPINative_DATA_BLOB.Null();
            var entropyBlob = DPAPINative_DATA_BLOB.Null();

            // We only need prompt structure because it is a required parameter.
            var prompt = DPAPINative_CRYPTPROTECT_PROMPTSTRUCT.Default();

            byte[] cipherTextBytes;

            try
            {
                // Convert plaintext bytes into a BLOB structure.
                plainTextBlob = DPAPINative_DATA_BLOB.Init(plainTextBytes); // InitBLOB(plainTextBytes);

                // Convert entropy bytes into a BLOB structure.
                entropyBlob = DPAPINative_DATA_BLOB.Init(entropyBytes); // InitBLOB(entropyBytes);

                // Disable any types of UI.
                int flags = CRYPTPROTECT_UI_FORBIDDEN;

                // When using machine-specific key, set up machine flag.
                if (keyType == DPAPIKeyType.MachineKey) flags |= CRYPTPROTECT_LOCAL_MACHINE;

                // Call DPAPI to encrypt data.
                bool success = _nativeMethods.ProtectData(ref plainTextBlob, string.Empty, ref entropyBlob, IntPtr.Zero, ref prompt, flags, ref cipherTextBlob);

                // Check the result.
                if (!success)
                {
                    // If operation failed, retrieve last Win32 error.
                    int errCode = Marshal.GetLastWin32Error();

                    // Win32Exception will contain error message corresponding
                    // to the Windows error code.
                    throw new CryptographicException("CryptProtectData failed.", new Win32Exception(errCode));
                }

                // Allocate memory to hold ciphertext.
                cipherTextBytes = new byte[cipherTextBlob.DataLength];

                // Copy ciphertext from the BLOB to a byte array.
                Marshal.Copy(cipherTextBlob.DataPointer, cipherTextBytes, 0, cipherTextBlob.DataLength);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("DPAPI was unable to encrypt data.", ex);
            }
            finally
            {
                // Free all memory allocated for BLOBs.
                plainTextBlob.Dispose();
                cipherTextBlob.Dispose();
                entropyBlob.Dispose();

                prompt.Dispose();
            }

            // Return the result.
            return cipherTextBytes;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private byte[] DPAPI_Decrypt(byte[] cipherText, byte[] entropy)
        {
            // Create BLOBs to hold data.
            var plainTextBlob = new DPAPINative_DATA_BLOB();
            var cipherTextBlob = new DPAPINative_DATA_BLOB();
            var entropyBlob = new DPAPINative_DATA_BLOB();

            // We only need prompt structure because it is a required parameter.
            var prompt = DPAPINative_CRYPTPROTECT_PROMPTSTRUCT.Default();

            byte[] plainTextBytes;

            try
            {
                // Convert ciphertext bytes into a BLOB structure.
                cipherTextBlob = DPAPINative_DATA_BLOB.Init(cipherText);

                // Convert entropy bytes into a BLOB structure.
                entropyBlob = DPAPINative_DATA_BLOB.Init(entropy);

                // Initialize description string.
                string description = String.Empty;

                // Call DPAPI to decrypt data.
                bool success = _nativeMethods.UnprotectData(ref cipherTextBlob, ref description, ref entropyBlob, IntPtr.Zero, ref prompt,
                                                            CRYPTPROTECT_UI_FORBIDDEN, ref plainTextBlob);

                // Check the result.
                if (!success)
                {
                    // If operation failed, retrieve last Win32 error.
                    int errCode = Marshal.GetLastWin32Error();

                    // Win32Exception will contain error message corresponding
                    // to the Windows error code.
                    throw new CryptographicException("CryptUnprotectData failed.", new Win32Exception(errCode));
                }

                // Allocate memory to hold plaintext.
                plainTextBytes = new byte[plainTextBlob.DataLength];

                // Copy ciphertext from the BLOB to a byte array.
                Marshal.Copy(plainTextBlob.DataPointer, plainTextBytes, 0, plainTextBlob.DataLength);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("DPAPI was unable to decrypt data.", ex);
            }
            finally
            {
                // Free all memory allocated for BLOBs.
                plainTextBlob.Dispose();
                cipherTextBlob.Dispose();
                entropyBlob.Dispose();

                prompt.Dispose();
            }

            // Return the result.
            return plainTextBytes;
        }

        private static SecureString ToSecureString(string text)
        {
            var ss = new SecureString();

            foreach (char ch in text)
            {
                ss.AppendChar(ch);
            }

            ss.MakeReadOnly();

            return ss;
        }

        private static string ToString(SecureString secureString)
        {
            string text;

            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                text = Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }

            return text;
        }

        #endregion
    }
}