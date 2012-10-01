using System.ComponentModel;

namespace EfficientlyLazy.Crypto.Engines
{
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
}