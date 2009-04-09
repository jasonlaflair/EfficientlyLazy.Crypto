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
namespace EfficientlyLazyCrypto.Demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumerationConversions
    {
        public static List<string> GetEnumDescriptions(Type value)
        {
            List<string> descriptions = new List<string>();

            FieldInfo[] fis = value.GetFields();
            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    descriptions.Add(attributes[0].Description);
                }
            }

            return descriptions;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static T GetEnumName<T>(string description)
        {
            FieldInfo[] fis = typeof (T).GetFields();
            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description == description)
                {
                    return
                        (T)fi.GetValue(typeof (T));
                }
            }

            return default(T);
        }
    }
}