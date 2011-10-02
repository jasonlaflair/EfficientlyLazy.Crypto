using System.Xml.Serialization;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    ///</summary>
    [XmlRoot("setting")]
    public class SecureSetting : ISecureSetting
    {
        ///<summary>
        ///</summary>
        [XmlAttribute("key")]
        public string Key { get; set; }

        ///<summary>
        ///</summary>
        [XmlAttribute("value")]
        public string Value { get; set; }

        ///<summary>
        ///</summary>
        [XmlAttribute("isencrypted")]
        public bool IsEncrypted { get; set; }
    }
}