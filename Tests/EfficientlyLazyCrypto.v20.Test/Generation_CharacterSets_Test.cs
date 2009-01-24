using System.Collections.Generic;
using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class Generation_CharacterSets_Test
    {
        [Test]
        [Row(0)]
        [Row(2)]
        public void CharacterSetAllUppercase(int required)
        {
            CharacterSet set = required == 0 ? CharacterSet.AllUppercase() : CharacterSet.AllUppercase(required);

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < set.Characters.Count; i++)
            {
                Assert.AreEqual(chars[i], set.Characters[i], chars[i].ToString());
            }

            Assert.AreEqual(chars.Length, set.Characters.Count);
            Assert.AreEqual(required, set.MinimumRequired);
        }

        [Test]
        [Row(0)]
        [Row(2)]
        public void CharacterSetAllLowercase(int required)
        {
            CharacterSet set = required == 0 ? CharacterSet.AllLowercase() : CharacterSet.AllLowercase(required);

            string chars = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < set.Characters.Count; i++)
            {
                Assert.AreEqual(chars[i], set.Characters[i], chars[i].ToString());
            }

            Assert.AreEqual(chars.Length, set.Characters.Count);
            Assert.AreEqual(required, set.MinimumRequired);
        }

        [Test]
        [Row(0)]
        [Row(2)]
        public void CharacterSetAllNumeric(int required)
        {
            CharacterSet set = required == 0 ? CharacterSet.AllNumeric() : CharacterSet.AllNumeric(required);

            string chars = "0123456789";

            for (int i = 0; i < set.Characters.Count; i++)
            {
                Assert.AreEqual(chars[i], set.Characters[i], chars[i].ToString());
            }

            Assert.AreEqual(chars.Length, set.Characters.Count);
            Assert.AreEqual(required, set.MinimumRequired);
        }

        [Test]
        [Row(0)]
        [Row(2)]
        public void CharacterSetAllSpecial(int required)
        {
            CharacterSet set = required == 0 ? CharacterSet.AllSpecial() : CharacterSet.AllSpecial(required);

            string chars = "`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?";

            for (int i = 0; i < set.Characters.Count; i++)
            {
                Assert.AreEqual(chars[i], set.Characters[i], chars[i].ToString());
            }

            Assert.AreEqual(chars.Length, set.Characters.Count);
            Assert.AreEqual(required, set.MinimumRequired);
        }

        [Test]
        [Row(0)]
        [Row(2)]
        public void CharacterSetCustomCharList(int required)
        {
            List<char> custom = new List<char>();
            custom.AddRange(CharacterSet.AllLowercase().Characters);
            custom.AddRange(CharacterSet.AllSpecial().Characters);

            CharacterSet set = required == 0 ? new CharacterSet(custom) : new CharacterSet(custom, required);

            for (int i = 0; i < set.Characters.Count; i++)
            {
                Assert.AreEqual(custom[i], set.Characters[i], custom[i].ToString());
            }

            Assert.AreEqual(custom.Count, set.Characters.Count);
            Assert.AreEqual(required, set.MinimumRequired);
        }

        [Test]
        [Row(0)]
        [Row(2)]
        public void CharacterSetCustomString(int required)
        {
            List<char> customList = new List<char>();
            customList.AddRange(CharacterSet.AllLowercase().Characters);
            customList.AddRange(CharacterSet.AllSpecial().Characters);

            string custom = new string(customList.ToArray());

            CharacterSet set = required == 0 ? new CharacterSet(custom) : new CharacterSet(custom, required);

            for (int i = 0; i < set.Characters.Count; i++)
            {
                Assert.AreEqual(custom[i], set.Characters[i], custom[i].ToString());
            }

            Assert.AreEqual(custom.Length, set.Characters.Count);
            Assert.AreEqual(required, set.MinimumRequired);
        }
    }
}