using System;

namespace EfficientlyLazyCrypto
{
    ///<summary>
    /// Indicates when prompts to the user are to be displayed.
    ///</summary>
    [Flags]
    internal enum DPAPINative_CryptProtectPromptFlags
    {
        ///<summary>
        /// This flag can be combined with CRYPTPROTECT_PROMPT_ON_PROTECT to enforce the UI (user interface) policy of the caller. When CryptUnprotectData is called, the dwPromptFlags specified in the CryptProtectData call are enforced.
        ///</summary>
        CRYPTPROTECT_PROMPT_ON_UNPROTECT = 0x1,

        ///<summary>
        /// This flag is used to provide the prompt for the protect phase.
        ///</summary>
        CRYPTPROTECT_PROMPT_ON_PROTECT = 0x2
    }
}