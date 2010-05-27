﻿// // Copyright 2008-2009 LaFlair.NET
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
namespace EfficientlyLazy.Crypto.Test
{
    using System;
    using MbUnit.Framework;

    /// <summary>
    /// Summary description for DataGeneratorTests
    /// </summary>
    [TestFixture]
    public class DataGeneratorTests
    {
        [Test]
        [Parallelizable]
        [Row(10, 20)]
        [Row(10, 5, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(0, 15, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-1, 15, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, 0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, -1, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void Constructor2Params(int min, int max)
        {
            DataGenerator dg = new DataGenerator(min, max);

            Assert.IsNotNull(dg);
        }

        [Test]
        [Parallelizable]
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
        [Row(20, 100, false, false, false, false, ExpectedException = typeof (ArgumentException))]
        [Row(0, 100, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-1, 100, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, 0, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, -1, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, 5, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void Constructor6Params(int minimum, int maximum, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            DataGenerator dg = new DataGenerator(minimum, maximum, includeUppercase, includeLowercase, includeNumbers, includeSpecials);

            Assert.IsNotNull(dg);
        }

        [Test]
        [Parallelizable]
        [Row(true, true, true, true)]
        [Row(true, true, true, false)]
        [Row(true, true, false, true)]
        [Row(true, true, false, false)]
        [Row(true, false, true, true)]
        [Row(true, false, true, false)]
        [Row(true, false, false, true)]
        [Row(true, false, false, false)]
        [Row(false, true, true, true)]
        [Row(false, true, true, false)]
        [Row(false, true, false, true)]
        [Row(false, true, false, false)]
        [Row(false, false, true, true)]
        [Row(false, false, true, false)]
        [Row(false, false, false, true)]
        [Row(false, false, false, false, ExpectedException = typeof (ArgumentException))]
        public void ResetCharacterRequirements(bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecials)
        {
            DataGenerator dg = new DataGenerator(100, 200);

            Assert.IsNotNull(dg);

            dg.ResetCharacterRequirements(includeUppercase, includeLowercase, includeNumbers, includeSpecials);
        }

        [Test]
        [Parallelizable]
        [Row(10, 20)]
        [Row(15, 15)]
        [Row(-1, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(0, 15, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, -1, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, 0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void ResetLengths(int minimum, int maximum)
        {
            DataGenerator dg = new DataGenerator(100, 200);

            Assert.IsNotNull(dg);

            dg.ResetLengths(minimum, maximum);
        }

        [Test]
        [Parallelizable]
        [Row(5)]
        [Row(10)]
        [Row(159135)]
        [Row(0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-5, ExpectedException = typeof (OverflowException))]
        [Row(null, ExpectedException = typeof (ArgumentNullException))]
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
                Assert.Fail("Original Is Null");
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

            Assert.AreNotEqual(matches, original.Length, "{0} - {1}", matches, original.Length);
        }

        [Test]
        [Parallelizable]
        [Row(5)]
        [Row(10)]
        [Row(159135)]
        [Row(0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-5, ExpectedException = typeof (OverflowException))]
        [Row(null, ExpectedException = typeof (ArgumentNullException))]
        public void NextBytes(int? bufferLength)
        {
            byte[] original = null;
            byte[] buffer = null;

            if (bufferLength.HasValue)
            {
                original = new byte[bufferLength.Value];
                buffer = new byte[bufferLength.Value];
            }

            DataGenerator dataGenerator = new DataGenerator(10, 100);
            dataGenerator.NextBytes(buffer);

            if (original == null)
            {
                Assert.Fail("Original Is Null");
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

            Assert.AreNotEqual(matches, original.Length, "{0} - {1}", matches, original.Length);
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        public void RandomDouble()
        {
            double value = DataGenerator.RandomDouble();

            Assert.Between(value, 0, 1);
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        public void NextDouble()
        {
            DataGenerator dataGenerator = new DataGenerator(10, 100);

            double value = dataGenerator.NextDouble();

            Assert.Between(value, 0, 1);
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        [Row(10, 50)]
        [Row(12, 90)]
        [Row(1, 5)]
        [Row(106, 250)]
        [Row(0, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-1, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, 0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, -1, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(15, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void RandomInteger(int min, int max)
        {
            int value = DataGenerator.RandomInteger(min, max);

            Assert.Between(value, min, max);
        }

        [Test]
        [Parallelizable]
        [Repeat(50)]
        [Row(10, 50)]
        [Row(12, 90)]
        [Row(1, 5)]
        [Row(106, 250)]
        [Row(0, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-1, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, 0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(10, -1, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(15, 10, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void NextInteger(int min, int max)
        {
            DataGenerator dataGenerator = new DataGenerator(min, max);

            int value = dataGenerator.NextInteger();

            Assert.Between(value, min, max);
        }

        [Test]
        [Parallelizable]
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
        [Row(20, 100, false, false, false, false, ExpectedException = typeof (ArgumentException))]
        [Row(0, 100, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-1, 100, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, 0, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, -1, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, 10, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void RandomString(int min, int max, bool upper, bool lower, bool numbers, bool special)
        {
            string value = DataGenerator.RandomString(min, max, upper, lower, numbers, special);

            Assert.Between(value.Length, min, max);
        }

        [Test]
        [Parallelizable]
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
        [Row(20, 100, false, false, false, false, ExpectedException = typeof (ArgumentException))]
        [Row(0, 100, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(-1, 100, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, 0, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, -1, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [Row(20, 10, true, true, true, true, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void NextString(int min, int max, bool upper, bool lower, bool numbers, bool special)
        {
            DataGenerator dataGenerator = new DataGenerator(min, max, upper, lower, numbers, special);

            string value = dataGenerator.NextString();

            Assert.Between(value.Length, min, max);
        }
    }
}