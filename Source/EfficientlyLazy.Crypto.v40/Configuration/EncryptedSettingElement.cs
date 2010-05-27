using System.Configuration;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    /// Represents a configuration element within a configuration file.
    ///</summary>
    public class EncryptedSettingElement : ConfigurationElement
    {
        ///<summary>
        /// Name given to identify the setting.
        ///</summary>
        [ConfigurationProperty("key", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return base["key"].ToString(); }
            set { base["key"] = value; }
        }

        ///<summary>
        /// The encrypted value within the element
        ///</summary>
        [ConfigurationProperty("value", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string EncryptedValue
        {
            get { return base["value"].ToString(); }
            set { base["value"] = value; }
        }
    }
}
