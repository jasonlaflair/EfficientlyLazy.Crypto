﻿// // Copyright 2008-2009 LaFlair.NET
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
namespace EfficientlyLazy.Crypto.Demo
{
    using System.Windows.Forms;

    public class CryptoUserControl : UserControl
    {
        public virtual string DisplayName { get; private set; }

        public virtual string Encrypt(string clearText)
        {
            return string.Empty;
        }

        public virtual string Decrypt(string encryptedText)
        {
            return string.Empty;
        }
    }
}