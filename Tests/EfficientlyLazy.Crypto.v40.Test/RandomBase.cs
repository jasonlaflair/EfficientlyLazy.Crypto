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
namespace EfficientlyLazy.Crypto.Test
{
    using System.Security;

    public class RandomBase
    {
        #region Encodings enum

        public enum Encodings
        {
            None,
            ASCII,
            Unicode,
            UTF32,
            UTF7,
            UTF8
        }

        #endregion

        protected static SecureString ToSS(string value)
        {
            SecureString ss = new SecureString();
            foreach (char ch in value)
            {
                ss.AppendChar(ch);
            }

            return ss;
        }

        protected static string GenerateText(int min, int max)
        {
            return DataGenerator.RandomString(min, max, true, true, true, true);
        }

        protected static string GenerateClearText()
        {
            return DataGenerator.RandomString(50, 300, true, true, true, true);
        }

        protected static string GeneratePassPhrase()
        {
            return DataGenerator.RandomString(100, 500, true, true, true, true);
        }

        protected static string GenerateRandomSalt()
        {
            return DataGenerator.RandomString(50, 250, true, true, true, true);
        }

        protected static string GenerateInitVector()
        {
            return DataGenerator.RandomString(16, 16, true, true, true, true);
        }
    }
}