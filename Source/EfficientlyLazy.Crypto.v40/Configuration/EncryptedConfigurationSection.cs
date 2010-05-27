using System.Configuration;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    /// Represents a section within a configuration file
    ///</summary>
    public class EncryptedConfigurationSection : ConfigurationSection
    {
        ///<summary>
        /// Collection of <see cref="EncryptedSettingElement"/>
        ///</summary>
        [ConfigurationProperty("Settings")]
        public EncryptedSettingCollection Settings
        {
            get { return ((EncryptedSettingCollection)(base["Settings"])); }
        }

        ///<summary>
        /// Collection of <see cref="EncryptedConnectionStringElement"/>
        ///</summary>
        [ConfigurationProperty("ConnectionStrings")]
        public EncryptedConnectionStringCollection ConnectionStrings
        {
            get { return ((EncryptedConnectionStringCollection)(base["ConnectionStrings"])); }
        }
    }
}