using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Test
{
    /// <summary>
    /// Summary description for DataGeneratorTests
    /// </summary>
    public class DataGeneratorTests
    {
        [Theory]
        [InlineData(10, 20)]
        //[InlineData(10, 5)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(0, 15)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-1, 15)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, 0)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, -1)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void Constructor2Params(int min, int max)
        {
            var dg = new DataGenerator(min, max);

            Assert.NotNull(dg);
        }

        [Theory]
        [InlineData(20, 100, true, true, true, true)]
        [InlineData(20, 100, true, true, true, false)]
        [InlineData(20, 100, true, true, false, true)]
        [InlineData(20, 100, true, true, false, false)]
        [InlineData(20, 100, true, false, true, true)]
        [InlineData(20, 100, true, false, true, false)]
        [InlineData(20, 100, true, false, false, true)]
        [InlineData(20, 100, true, false, false, false)]
        [InlineData(20, 100, false, true, true, true)]
        [InlineData(20, 100, false, true, true, false)]
        [InlineData(20, 100, false, true, false, true)]
        [InlineData(20, 100, false, true, false, false)]
        [InlineData(20, 100, false, false, true, true)]
        [InlineData(20, 100, false, false, true, false)]
        [InlineData(20, 100, false, false, false, true)]
        //[InlineData(20, 100, false, false, false, false)] // TODO : ExpectedException = typeof (ArgumentException))]
        //[InlineData(0, 100, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-1, 100, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, 0, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, -1, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, 5, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void Constructor6Params(int minimum, int maximum, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            var dg = new DataGenerator(minimum, maximum, includeUppercase, includeLowercase, includeNumbers, includeSpecials);

            Assert.NotNull(dg);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(true, true, true, false)]
        [InlineData(true, true, false, true)]
        [InlineData(true, true, false, false)]
        [InlineData(true, false, true, true)]
        [InlineData(true, false, true, false)]
        [InlineData(true, false, false, true)]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, true, true)]
        [InlineData(false, true, true, false)]
        [InlineData(false, true, false, true)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, true)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        //[InlineData(false, false, false, false)] // TODO : ExpectedException = typeof (ArgumentException))]
        public void ResetCharacterRequirements(bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            var dg = new DataGenerator(100, 200);

            Assert.NotNull(dg);

            dg.ResetCharacterRequirements(includeUppercase, includeLowercase, includeNumbers, includeSpecials);
        }

        [Theory]
        [InlineData(10, 20)]
        [InlineData(15, 15)]
        //[InlineData(-1, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(0, 15)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, -1)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, 0)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void ResetLengths(int minimum, int maximum)
        {
            var dg = new DataGenerator(100, 200);

            Assert.NotNull(dg);

            dg.ResetLengths(minimum, maximum);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(159135)]
        //[InlineData(0)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-5)] // TODO : ExpectedException = typeof (OverflowException))]
        //[InlineData(null)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void RandomBytes(int? bufferLength)
        {
            byte[] original = null;
            byte[] buffer = null;

            if (bufferLength.HasValue)
            {
                original = new byte[bufferLength.Value];
                buffer = new byte[bufferLength.Value];
            }

            DataGenerator.RandomBytes(buffer);

            if (original == null)
            {
                //Assert.Fail("Original Is Null");
                return;
            }

            int matches = 0;

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == buffer[i])
                {
                    matches++;
                }
            }

            //Assert.NotEqual(matches, original.Length, "{0} - {1}", matches, original.Length);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(159135)]
        //[InlineData(0)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-5)] // TODO : ExpectedException = typeof (OverflowException))]
        //[InlineData(null)] // TODO : ExpectedException = typeof (ArgumentNullException))]
        public void NextBytes(int? bufferLength)
        {
            byte[] original = null;
            byte[] buffer = null;

            if (bufferLength.HasValue)
            {
                original = new byte[bufferLength.Value];
                buffer = new byte[bufferLength.Value];
            }

            var dataGenerator = new DataGenerator(10, 100);
            dataGenerator.NextBytes(buffer);

            if (original == null)
            {
                //Assert.Fail("Original Is Null");
                return;
            }

            int matches = 0;

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] == buffer[i])
                {
                    matches++;
                }
            }

            //Assert.NotEqual(matches, original.Length, "{0} - {1}", matches, original.Length);
        }

        [Fact]
        public void RandomDouble()
        {
            double value = DataGenerator.RandomDouble();

            //Assert.Between(value, 0, 1);
        }

        [Fact]
        public void NextDouble()
        {
            var dataGenerator = new DataGenerator(10, 100);

            double value = dataGenerator.NextDouble();

            //Assert.Between(value, 0, 1);
        }

        [Theory]
        [InlineData(10, 50)]
        [InlineData(12, 90)]
        [InlineData(1, 5)]
        [InlineData(106, 250)]
        //[InlineData(0, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-1, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, 0)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, -1)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(15, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void RandomInteger(int min, int max)
        {
            int value = DataGenerator.RandomInteger(min, max);

            //Assert.Between(value, min, max);
        }

        [Theory]
        [InlineData(10, 50)]
        [InlineData(12, 90)]
        [InlineData(1, 5)]
        [InlineData(106, 250)]
        //[InlineData(0, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-1, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, 0)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(10, -1)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(15, 10)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void NextInteger(int min, int max)
        {
            var dataGenerator = new DataGenerator(min, max);

            int value = dataGenerator.NextInteger();

            //Assert.Between(value, min, max);
        }

        [Theory]
        [InlineData(20, 100, true, true, true, true)]
        [InlineData(20, 100, true, true, true, false)]
        [InlineData(20, 100, true, true, false, true)]
        [InlineData(20, 100, true, true, false, false)]
        [InlineData(20, 100, true, false, true, true)]
        [InlineData(20, 100, true, false, true, false)]
        [InlineData(20, 100, true, false, false, true)]
        [InlineData(20, 100, true, false, false, false)]
        [InlineData(20, 100, false, true, true, true)]
        [InlineData(20, 100, false, true, true, false)]
        [InlineData(20, 100, false, true, false, true)]
        [InlineData(20, 100, false, true, false, false)]
        [InlineData(20, 100, false, false, true, true)]
        [InlineData(20, 100, false, false, true, false)]
        [InlineData(20, 100, false, false, false, true)]
        //[InlineData(20, 100, false, false, false, false)] // TODO : ExpectedException = typeof (ArgumentException))]
        //[InlineData(0, 100, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-1, 100, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, 0, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, -1, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, 10, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void RandomString(int min, int max, bool upper, bool lower, bool numbers, bool special)
        {
            string value = DataGenerator.RandomString(min, max, upper, lower, numbers, special);

            //Assert.Between(value.Length, min, max);
        }

        [Theory]
        [InlineData(20, 100, true, true, true, true)]
        [InlineData(20, 100, true, true, true, false)]
        [InlineData(20, 100, true, true, false, true)]
        [InlineData(20, 100, true, true, false, false)]
        [InlineData(20, 100, true, false, true, true)]
        [InlineData(20, 100, true, false, true, false)]
        [InlineData(20, 100, true, false, false, true)]
        [InlineData(20, 100, true, false, false, false)]
        [InlineData(20, 100, false, true, true, true)]
        [InlineData(20, 100, false, true, true, false)]
        [InlineData(20, 100, false, true, false, true)]
        [InlineData(20, 100, false, true, false, false)]
        [InlineData(20, 100, false, false, true, true)]
        [InlineData(20, 100, false, false, true, false)]
        [InlineData(20, 100, false, false, false, true)]
        //[InlineData(20, 100, false, false, false, false)] // TODO : ExpectedException = typeof (ArgumentException))]
        //[InlineData(0, 100, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(-1, 100, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, 0, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, -1, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        //[InlineData(20, 10, true, true, true, true)] // TODO : ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void NextString(int min, int max, bool upper, bool lower, bool numbers, bool special)
        {
            var dataGenerator = new DataGenerator(min, max, upper, lower, numbers, special);

            string value = dataGenerator.NextString();

            //Assert.Between(value.Length, min, max);
        }
    }
}