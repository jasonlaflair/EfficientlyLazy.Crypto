using System;
using System.Collections.Generic;
using MbUnit.Framework;

namespace EfficientlyLazyCrypto.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class DataGeneratorTests
    {
        //[Test, Parallelizable]
        //[Row(10, 20)]
        //[Row(10, 20, ExpectedException = typeof(ArgumentOutOfRangeException))]
        //public void Constructor2Params(int min, int max)
        //{
        //    DataGenerator dg = new DataGenerator(min, max);
        //}

        [Test, Parallelizable]
        [Row(5)]
        [Row(10)]
        [Row(159135)]
        public void RandomBytes(int bufferLength)
        {
            byte[] buffer = new byte[bufferLength];

            Assert.AreEqual(bufferLength, buffer.Length);
            foreach (byte b in buffer)
            {
                Assert.AreEqual(0, b);
            }

            DataGenerator.RandomBytes(buffer);

            int zeroCount = 0;

            Assert.AreEqual(bufferLength, buffer.Length);
            foreach (byte b in buffer)
            {
                if (b == 0) zeroCount++;
            }

            Assert.AreNotEqual(zeroCount, bufferLength);
        }

        [Test, Parallelizable, ExpectedArgumentNullException]
        public void RandomBytesInvalid()
        {
            byte[] buffer = null;

            DataGenerator.RandomBytes(buffer);
        }

        [Test, Parallelizable]
        [Row(5)]
        [Row(900)]
        [Row(18000)]
        public void RandomDouble(int loopCount)
        {
            SortedDictionary<double, int> tracking = new SortedDictionary<double, int>();

            for (int i = 0; i <= loopCount; i++)
            {
                double value = DataGenerator.RandomDouble();

                if (tracking.ContainsKey(value))
                {
                    Assert.Fail(string.Format("Track: {0} Value: {1} LoopCount: {2}", tracking.Count, value, loopCount));
                }
                else
                {
                    tracking.Add(value, 0);
                }
            }
        }

        [Test, Parallelizable]
        [Row(10, 50)]
        [Row(12, 90)]
        [Row(1, 5)]
        [Row(106, 250)]
        public void RandomInteger(int min, int max)
        {
            SortedList<int, int> values = new SortedList<int, int>();

            for (int i = min; i <= max; i++)
            {
                int value = DataGenerator.RandomInteger(min, max);

                if (!values.ContainsKey(value))
                {
                    values.Add(value, 0);
                }

                values[value]++;
            }

            foreach (var pair in values)
            {
                if (pair.Value >= 5)
                {
                    Assert.Fail(string.Format("{0} Generated Too Many ({1}) Times ({2}/{3})", pair.Key, pair.Value, min, max));
                }
            }
        }

        [Test, Parallelizable]
        [Row(-1, 100, -1, "minimum", "minimum must be greater than 0")]
        [Row(0, 100, 0, "minimum", "minimum must be greater than 0")]
        [Row(-50, 100, -50, "minimum", "minimum must be greater than 0")]
        [Row(32, -1, -1, "maximum", "maximum must be greater than 0")]
        [Row(1, 0, 0, "maximum", "maximum must be greater than 0")]
        [Row(50, -25, -25, "maximum", "maximum must be greater than 0")]
        [Row(25, 20, null, "maximum", "maximum must be greater than or equal to minimum")]
        [Row(2, 1, null, "maximum", "maximum must be greater than or equal to minimum")]
        public void RandomIntegerInvalid(int min, int max, int? actual, string param, string error)
        {
            bool caught = false;

            try
            {
                DataGenerator.RandomInteger(min, max);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(param, ex.ParamName);
                Assert.StartsWith(ex.Message, error);
                Assert.AreEqual(actual, ex.ActualValue);

                caught = true;
            }

            Assert.IsTrue(caught);
        }

        [Test, Parallelizable]
        [Row(20, 100, true, true, true, true)]
        [Row(20, 100, true, true, true, false)]
        [Row(20, 100, true, true, false, true)]
        [Row(20, 100, true, true, false, false)]
        [Row(20, 100, true, false, true, true)]
        [Row(20, 100, true, false, true, false)]
        [Row(20, 100, true, false, false, true)]
        [Row(20, 100, true, false, false, false)]
        [Row(20, 100, false, true, true, true)]
        [Row(20, 100, false, true, true, false)]
        [Row(20, 100, false, true, false, true)]
        [Row(20, 100, false, true, false, false)]
        [Row(20, 100, false, false, true, true)]
        [Row(20, 100, false, false, true, false)]
        [Row(20, 100, false, false, false, true)]
        //[Row(20, 100, false, false, false, false)] 
        public void RandomString(int min, int max, bool upper, bool lower, bool numbers, bool special)
        {
            string value = DataGenerator.RandomString(min, max, upper, lower, numbers, special);

            Assert.Between(value.Length, min, max);
        }

        [Test, Parallelizable]
        [Row(-1, 100, -1, "minimumLength", "minimumLength must be greater than 0")]
        [Row(0, 100, 0, "minimumLength", "minimumLength must be greater than 0")]
        [Row(-50, 100, -50, "minimumLength", "minimumLength must be greater than 0")]
        [Row(32, -1, -1, "maximumLength", "maximumLength must be greater than 0")]
        [Row(1, 0, 0, "maximumLength", "maximumLength must be greater than 0")]
        [Row(50, -25, -25, "maximumLength", "maximumLength must be greater than 0")]
        [Row(25, 20, null, "maximumLength", "maximumLength must be greater than or equal to minimumLength")]
        [Row(2, 1, null, "maximumLength", "maximumLength must be greater than or equal to minimumLength")]
        public void RandomStringInvalidLength(int min, int max, int? actual, string param, string error)
        {
            bool caught = false;

            try
            {
                DataGenerator.RandomString(min, max, true, true, true, true);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(param, ex.ParamName);
                Assert.StartsWith(ex.Message, error);
                Assert.AreEqual(actual, ex.ActualValue);

                caught = true;
            }

            Assert.IsTrue(caught);
        }

        [Test, Parallelizable, ExpectedArgumentException]
        public void RandomStringInvalidCharacters()
        {
            DataGenerator.RandomString(10, 20, false, false, false, false);
        }
    }
}