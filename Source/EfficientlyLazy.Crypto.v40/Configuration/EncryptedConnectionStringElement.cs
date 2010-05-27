using System.Configuration;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    /// Represents a configuration element within a configuration file.
    ///</summary>
    public class EncryptedConnectionStringElement : ConfigurationElement
    {
        ///<summary>
        /// Name given to identify the connection string.
        ///</summary>
        [ConfigurationProperty("alias", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Alias
        {
            get { return base["alias"].ToString(); }
            set { base["alias"] = value; }
        }

        ///<summary>
        /// The encrypted connection string within the element
        ///</summary>
        [ConfigurationProperty("value", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string EncryptedConnectionString
        {
            get { return base["value"].ToString(); }
            set { base["value"] = value; }
        }
    }
}