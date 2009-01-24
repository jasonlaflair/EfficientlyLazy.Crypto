using System;
using System.Runtime.InteropServices;

namespace EfficientlyLazyCrypto.DPAPINative
{
    /// <summary>
    /// Provides the text of a prompt and information about when and where that prompt is to be displayed when using the CryptProtectData and CryptUnprotectData functions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRYPTPROTECT_PROMPTSTRUCT : IDisposable
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Indicates when prompts to the user are to be displayed.
        /// </summary>
        public CryptProtectPromptFlags PromptFlags { get; set; }

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
        public static CRYPTPROTECT_PROMPTSTRUCT Default()
        {
            return new CRYPTPROTECT_PROMPTSTRUCT
                         {
                             Size = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT)),
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
}