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
    using System;
    using System.Configuration;
    using System.Xml;
    using System.Xml.Serialization;

    ///<summary>
    /// Handles access to secured configuration sections.
    ///</summary>
    public class SecureSectionHandler : IConfigurationSectionHandler
    {
        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <returns>
        /// The created section handler object.
        /// </returns>
        /// <param name="parent">Parent object.</param><param name="configContext">Configuration context object.</param><param name="section">Section XML node.</param><filterpriority>2</filterpriority>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var navigator = section.CreateNavigator();
            var typeOfObject = (string)navigator.Evaluate("string(@type)");
            var type = Type.GetType(typeOfObject);
            var xmlSerializer = new XmlSerializer(type);
            var nodeReader = new XmlNodeReader(section);
            return xmlSerializer.Deserialize(nodeReader);
        }
    }
}