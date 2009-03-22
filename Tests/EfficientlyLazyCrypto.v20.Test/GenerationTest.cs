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
        //        seed = DataGenerator.SeedValue();

        //        if (returnedValues.ContainsKey(seed))
        //        {
        //            Assert.Fail(string.Format("Seed: {0} - Values: {1}", seed, returnedValues.Count));
        //        }

        //        returnedValues.Add(seed, seed);

        //        Console.WriteLine(seed);
        //    }
        //}


































        //[Test, Repeat(50), ExpectedException(typeof(ArgumentException))]
        //public void ExceptionNothingRequired()
        //{
        //    DataGenerator.String(5, 10, false, false, false, false);
        //}

        //[Test, Repeat(50), ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void ExceptionMinValueLessThanZero()
        //{
        //    DataGenerator.String(0, 5, true, false, false, false);
        //}

        //[Test, Repeat(50), ExpectedException(typeof(ArgumentException))]
        //public void ExceptionMinValueGreaterThanMaxValue()
        //{
        //    DataGenerator.String(10, 5, true, false, false, false);
        //}

        //[Test, Repeat(50)]
        //public void Complete()
        //{
        //    DataGenerator.String(10, 50, 1, 1, 1, 1);
        //}

        //[Test, Repeat(50), ExpectedException(typeof(InvalidOperationException))]
        //public void CompleteButWithTooManyIterations()
        //{
        //    DataGenerator.String(1, 3, 1, 1, 1, 1);
        //}

        [Test, Repeat(50)]
        public void RandomNumberTest_Valid()
        {
            int minValue = DataGenerator.RandomInteger(10, 100);
            int maxValue = DataGenerator.RandomInteger(101, 500);

            int rnd = DataGenerator.RandomInteger(minValue, maxValue);

            Assert.IsTrue(minValue <= rnd && rnd <= maxValue);
            Assert.IsTrue(minValue < maxValue);
        }

        [Test, Repeat(50), ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandomNumberTest_MinGreaterThanMin()
        {
            int maxValue = DataGenerator.RandomInteger(10, 100);
            int minValue = DataGenerator.RandomInteger(101, 500);

            int rnd = DataGenerator.RandomInteger(minValue, maxValue);

            Assert.IsTrue(minValue <= rnd && rnd <= maxValue);
            Assert.IsTrue(minValue < maxValue);
        }

    }
}