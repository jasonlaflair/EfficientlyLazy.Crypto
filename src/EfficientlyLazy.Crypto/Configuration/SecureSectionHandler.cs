using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace EfficientlyLazy.Crypto.Configuration
{
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