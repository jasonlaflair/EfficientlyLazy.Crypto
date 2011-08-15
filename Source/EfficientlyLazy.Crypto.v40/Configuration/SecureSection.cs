// // Copyright 2008-2009 LaFlair.NET
// // 
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// // 
// //     http://www.apache.org/licenses/LICENSE-2.0
// // 
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// 
namespace EfficientlyLazy.Crypto.Configuration
{
    using System.Xml.Serialization;

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