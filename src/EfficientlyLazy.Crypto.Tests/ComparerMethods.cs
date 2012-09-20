using System.Collections.Generic;

namespace EfficientlyLazy.Crypto.Tests
{
    internal static class ComparerMethods
    {
        public static bool AreMatch<T>(ICollection<T> list1, ICollection<T> list2)
        {
            if (list1 == null && list2 == null)
            {
                return true;
            }

            if (list1 == null || list2 == null)
            {
                return false;
            }

            if (list1.Count != list2.Count)
            {
                return false;
            }

            var diff1 = new List<T>(list1);
            var diff2 = new List<T>(list2);

            foreach (var diff in diff1)
            {
                if (!diff2.Remove(diff))
                {
                    return false;
                }
            }

            if (diff2.Count != 0)
            {
                return false;
            }

            diff1 = new List<T>(list1);
            diff2 = new List<T>(list2);

            foreach (var diff in diff2)
            {
                if (!diff1.Remove(diff))
                {
                    return false;
                }
            }

            if (diff1.Count != 0)
            {
                return false;
            }

            return true;
        }
    }
}
