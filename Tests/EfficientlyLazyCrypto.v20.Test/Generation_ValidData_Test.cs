using System.Collections.Generic;
using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class Generation_ValidData_Test
    {
        private readonly List<char> uppers = new List<char>(DataGenerator._uppercase);
        private readonly List<char> lowers = new List<char>(DataGenerator._lowercase);
        private readonly List<char> numbers = new List<char>(DataGenerator._numbers);
        private readonly List<char> puncts = new List<char>(DataGenerator._specials);

        [Test, Repeat(50)]
        public void TestUppers()
        {
            int min = DataGenerator.Integer(3, 500);
            int max = min + DataGenerator.Integer(100, 500);

            string data = DataGenerator.String(min, max, true, false, false, false);

            foreach (char ch in data)
            {
                if (!uppers.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestLowers()
        {
            int min = DataGenerator.Integer(3, 500);
            int max = min + DataGenerator.Integer(100, 500);

            string data = DataGenerator.String(min, max, false, true, false, false);

            foreach (char ch in data)
            {
                if (!lowers.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestNumbers()
        {
            int min = DataGenerator.Integer(3, 500);
            int max = min + DataGenerator.Integer(100, 500);

            string data = DataGenerator.String(min, max, false, false, true, false);

            foreach (char ch in data)
            {
                if (!numbers.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestPuncts()
        {
            int min = DataGenerator.Integer(3, 500);
            int max = min + DataGenerator.Integer(100, 500);

            string data = DataGenerator.String(min, max, false, false, false, true);

            foreach (char ch in data)
            {
                if (!puncts.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestAll()
        {
            int min = DataGenerator.Integer(3, 500);
            int max = min + DataGenerator.Integer(100, 500);

            string data = DataGenerator.String(min, max, true, true, true, true);

            foreach (char ch in data)
            {
                if (!(uppers.Contains(ch) || lowers.Contains(ch) || numbers.Contains(ch) || puncts.Contains(ch)))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }
    }
}