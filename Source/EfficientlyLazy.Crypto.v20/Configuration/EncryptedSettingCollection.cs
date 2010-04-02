using System.Configuration;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    /// Represents a configuration element containing a collection of child elements.
    ///</summary>
    [ConfigurationCollection(typeof(EncryptedSettingElement))]
    public class EncryptedSettingCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new EncryptedSettingElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement"/>.
        /// </returns>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement"/> to return the key for. 
        ///                 </param>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EncryptedSettingElement)(element)).Key;
        }

        ///<summary>
        ///</summary>
        ///<param name="idx">The index location of the EncryptedSettingElement to return</param>
        public EncryptedSettingElement this[int idx]
        {
            get { return (EncryptedSettingElement)BaseGet(idx); }
        }
    }
}