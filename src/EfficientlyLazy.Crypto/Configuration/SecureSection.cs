using System.Xml.Serialization;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    ///</summary>
    [XmlRoot("SecureConfig")]
    public class SecureSection
    {
        ///<summary>
        ///</summary>
        public SecureSection()
        {
            Settings = new SecureCollection<SecureSetting>();
            SqlConnectionStrings = new SecureCollection<SqlConnectionString>();
        }

        ///<summary>
        ///</summary>
        [XmlArray("settings")]
        [XmlArrayItem("setting", typeof(SecureSetting))]
        public SecureCollection<SecureSetting> Settings { get; set; }

        ///<summary>
        ///</summary>
        [XmlArray("sqlservers")]
        [XmlArrayItem("sqlconnection", typeof(SqlConnectionString))]
        public SecureCollection<SqlConnectionString> SqlConnectionStrings { get; set; }
    }
}