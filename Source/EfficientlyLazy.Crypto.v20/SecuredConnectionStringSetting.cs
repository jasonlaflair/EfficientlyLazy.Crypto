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
namespace EfficientlyLazy.Crypto
{
    using System.Configuration;

    ///<summary>
    /// Represents a single, named connection string in the connection strings configuration file section. 
    ///</summary>
    public sealed class SecuredConnectionStringSetting
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="SecuredConnectionStringSetting"/> object.
        ///</summary>
        public SecuredConnectionStringSetting()
        {
            Name = string.Empty;
            ConnectionString = string.Empty;
            ProviderName = string.Empty;
            State = ConnectionStringStates.NotFound;
        }

        ///<summary>
        /// Gets the <see cref="ConnectionStringSettings"/> name
        ///</summary>
        public string Name { get; internal set; }

        ///<summary>
        /// Gets the connection string.
        ///</summary>
        public string ConnectionString { get; internal set; }

        ///<summary>
        /// Gets the provider name property.
        ///</summary>
        public string ProviderName { get; internal set; }

        ///<summary>
        /// Gets the current <see cref="ConnectionStringStates">state</see> of the connection string
        ///</summary>
        public ConnectionStringStates State { get; internal set; }
    }
}