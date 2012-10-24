using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EfficientlyLazy.Crypto.Demo
{
    public static class EnumerationConversions
    {
        public static List<string> GetEnumDescriptions(Type value)
        {
            List<string> descriptions = new List<string>();

            FieldInfo[] fis = value.GetFields();
            foreach (FieldInfo fi in fis)
            {
                if (fi.Name == "value__")
                {
                    continue;
                }

                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    descriptions.Add(attributes[0].Description);
                }
                else
                {
                    descriptions.Add(fi.Name);
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