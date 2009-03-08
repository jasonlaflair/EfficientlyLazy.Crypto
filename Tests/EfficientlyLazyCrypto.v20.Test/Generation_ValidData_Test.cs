using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class Generation_ValidData_Test
    {
        private readonly CharacterSet uppers = CharacterSet.AllUppercase();
        private readonly CharacterSet lowers = CharacterSet.AllLowercase();
        private readonly CharacterSet numbers = CharacterSet.AllNumeric();
        private readonly CharacterSet puncts = CharacterSet.AllSpecial();

        [Test, Repeat(50)]
        public void TestUppers()
        {
            int min = DataGeneration.RandomInteger(3, 500);
            int max = min + DataGeneration.RandomInteger(100, 500);

            string data = DataGeneration.RandomString(min, max, true, false, false, false);

            foreach (char ch in data)
            {
                if (!uppers.Characters.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestLowers()
        {
            int min = DataGeneration.RandomInteger(3, 500);
            int max = min + DataGeneration.RandomInteger(100, 500);

            string data = DataGeneration.RandomString(min, max, false, true, false, false);

            foreach (char ch in data)
            {
                if (!lowers.Characters.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestNumbers()
        {
            int min = DataGeneration.RandomInteger(3, 500);
            int max = min + DataGeneration.RandomInteger(100, 500);

            string data = DataGeneration.RandomString(min, max, false, false, true, false);

            foreach (char ch in data)
            {
                if (!numbers.Characters.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestPuncts()
        {
            int min = DataGeneration.RandomInteger(3, 500);
            int max = min + DataGeneration.RandomInteger(100, 500);

            string data = DataGeneration.RandomString(min, max, false, false, false, true);

            foreach (char ch in data)
            {
                if (!puncts.Characters.Contains(ch))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }

        [Test, Repeat(50)]
        public void TestAll()
        {
            int min = DataGeneration.RandomInteger(3, 500);
            int max = min + DataGeneration.RandomInteger(100, 500);

            string data = DataGeneration.RandomString(min, max, true, true, true, true);

            foreach (char ch in data)
            {
                if (!(uppers.Characters.Contains(ch) || lowers.Characters.Contains(ch) || numbers.Characters.Contains(ch) || puncts.Characters.Contains(ch)))
                {
                    Assert.Fail(string.Format("{0}\r\n\r\nChar: {1}", data, ch));
                }
            }
        }
    }
}