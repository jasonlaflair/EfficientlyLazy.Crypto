using System;
using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class GenerationTest
    {
        //[Test]
        //public void RandomSeedValue()
        //{
        //    SortedList<int, int> returnedValues = new SortedList<int, int>();

        //    int seed;

        //    for (int i = 0; i <= int.MaxValue - 5000; i++)
        //    {
        //        seed = DataGeneration.RandomSeedValue();

        //        if (returnedValues.ContainsKey(seed))
        //        {
        //            Assert.Fail(string.Format("Seed: {0} - Values: {1}", seed, returnedValues.Count));
        //        }

        //        returnedValues.Add(seed, seed);

        //        Console.WriteLine(seed);
        //    }
        //}

        [Test]
        public void Test()
        {
            RandomStringRequirements requirements = new RandomStringRequirements(20, 50)
                .AddCharacterSet(CharacterSet.AllUppercase(30));

            string rand = DataGeneration.RandomString(requirements);

            Assert.IsTrue(!string.IsNullOrEmpty(rand));
        }


































        //[Test, Repeat(50), ExpectedException(typeof(ArgumentException))]
        //public void ExceptionNothingRequired()
        //{
        //    DataGeneration.RandomString(5, 10, false, false, false, false);
        //}

        //[Test, Repeat(50), ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ExceptionMinValueLessThanZero()
        //{
        //    DataGeneration.RandomString(0, 5, true, false, false, false);
        //}

        //[Test, Repeat(50), ExpectedException(typeof(ArgumentException))]
        //public void ExceptionMinValueGreaterThanMaxValue()
        //{
        //    DataGeneration.RandomString(10, 5, true, false, false, false);
        //}

        //[Test, Repeat(50)]
        //public void Complete()
        //{
        //    DataGeneration.RandomString(10, 50, 1, 1, 1, 1);
        //}

        //[Test, Repeat(50), ExpectedException(typeof(InvalidOperationException))]
        //public void CompleteButWithTooManyIterations()
        //{
        //    DataGeneration.RandomString(1, 3, 1, 1, 1, 1);
        //}

        [Test, Repeat(50)]
        public void RandomNumberTest_Valid()
        {
            int minValue = DataGeneration.RandomInteger(10, 100);
            int maxValue = DataGeneration.RandomInteger(101, 500);

            int rnd = DataGeneration.RandomInteger(minValue, maxValue);

            Assert.IsTrue(minValue <= rnd && rnd <= maxValue);
            Assert.IsTrue(minValue < maxValue);
        }

        [Test, Repeat(50), ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandomNumberTest_MinGreaterThanMin()
        {
            int maxValue = DataGeneration.RandomInteger(10, 100);
            int minValue = DataGeneration.RandomInteger(101, 500);

            int rnd = DataGeneration.RandomInteger(minValue, maxValue);

            Assert.IsTrue(minValue <= rnd && rnd <= maxValue);
            Assert.IsTrue(minValue < maxValue);
        }

    }
}