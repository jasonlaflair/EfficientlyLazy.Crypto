using System;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace EfficientlyLazy.Crypto.Configuration
{
    ///<summary>
    ///</summary>
    [XmlRoot("sqlconnection")]
    public class SqlConnectionString : ISecureSetting
    {
        ///<summary>
        ///</summary>
        [XmlAttribute("key")]
        public string Key { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("server")]
        public string Server { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("database")]
        public string Database { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("usewinauth")]
        public bool UseWinAuth { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("userid")]
        public string UserID { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("encrypteduserid")]
        public string EncryptedUserID { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("password")]
        public string Password { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("encryptedpassword")]
        public string EncryptedPassword { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("applicationname")]
        public string ApplicationName { get; set; }

        ///<summary>
        ///</summary>
        [XmlElement("showworkstationid", IsNullable = true)]
        public bool? ShowWorkstationID { get; set; }

        ///<summary>
        ///</summary>
        [XmlArray("settings")]
        [XmlArrayItem("setting", typeof(SecureSetting))]
        public SecureCollection<SecureSetting> ConnectionStringSettings;

        ///<summary>
        ///</summary>
        public SqlConnectionString()
        {
            ConnectionStringSettings = new SecureCollection<SecureSetting>();
        }

        ///<summary>
        ///</summary>
        public SqlConnectionStringBuilder GetBuilder(ICryptoEngine encryptionEngine)
        {
            var builder = new SqlConnectionStringBuilder
                              {
                                  DataSource = Server,
                                  InitialCatalog = Database,
                                  IntegratedSecurity = UseWinAuth
                              };

            if (!UseWinAuth)
            {
                //builder.Password = string.IsNullOrEmpty(EncryptedPassword) ? Password : encryptionEngine.Decrypt(EncryptedPassword);
                //builder.UserID = string.IsNullOrEmpty(EncryptedUserID) ? UserID : encryptionEngine.Decrypt(EncryptedUserID);

                if (!string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(UserID))
                {
                    builder.UserID = UserID;
                    builder.Password = Password;
                }
                else if (!string.IsNullOrEmpty(EncryptedPassword) && !string.IsNullOrEmpty(EncryptedUserID))
                {
                    builder.UserID = encryptionEngine.Decrypt(EncryptedUserID);
                    builder.Password = encryptionEngine.Decrypt(EncryptedPassword);
                }
            }

            if (!string.IsNullOrEmpty(ApplicationName)) builder.ApplicationName = ApplicationName;
            if (ShowWorkstationID.HasValue && ShowWorkstationID.Value) builder.WorkstationID = Environment.MachineName;

            foreach (var setting in ConnectionStringSettings)
            {
                if (builder.ContainsKey(setting.Key))
                {
                    var value = setting.IsEncrypted ? encryptionEngine.Decrypt(setting.Value) : setting.Value;

                    builder.Add(setting.Key, value);
                }
            }

            return builder;
        }
    }
}