using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Tests
{
    /// <summary>
    /// Summary description for DataGeneratorTests
    /// </summary>
    public class DataGeneratorTests
    {
        [Theory]
        [InlineData(1, 100)]
        [InlineData(1, int.MaxValue)]
        [InlineData(5, 5)]
        public void Integer_With_Min_Max_Returns_Valid_Random_Integer(int min, int max)
        {
            // Act
            var actual = DataGenerator.NextInteger(min, max);

            // Assert
            Assert.InRange(actual, min, max);
        }

        [Fact]
        public void Double_Returns_Valid_Random_Double()
        {
            // Act
            var actual = DataGenerator.NextDouble();

            // Assert
            Assert.InRange(actual, 0, 1);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(159135)]
        public void Bytes(int bufferLength)
        {
            // Arrange
            var original = new byte[bufferLength];
            var buffer = new byte[bufferLength];
            Assert.Equal(original, buffer);

            // Act
            DataGenerator.Bytes(buffer);
            
            // Assert
            Assert.NotEqual(original, buffer);
            Assert.Equal(bufferLength, buffer.Length);
        }

        [Fact]
        public void Bytes_Throws_Exception_On_Null_Array()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => DataGenerator.Bytes(null));
        }

        [Fact]
        public void Bytes_Throws_Exception_On_Zero_Length_Array()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.Bytes(new byte[0]));
        }

        [Theory]
        [InlineData(5, 31)]
        [InlineData(10, 100)]
        [InlineData(159135, 342562)]
        public void Bytes_With_Min_Max(int min, int max)
        {
            // Act
            var bytes = DataGenerator.Bytes(min, max);

            // Assert
            Assert.NotEqual(new byte[bytes.Length], bytes);
            Assert.InRange(bytes.Length, min, max);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Bytes_With_Min_Max_Throw_Exception_When_Min_Is(int min)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.Bytes(min, 10));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(3)]
        public void Bytes_With_Min_Max_Throw_Exception_When_Max_Is(int max)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.Bytes(5, max));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(159135)]
        public void Bytes_With_Length(int length)
        {
            // Act
            var bytes = DataGenerator.Bytes(length);

            // Assert
            Assert.NotEqual(new byte[bytes.Length], bytes);
            Assert.Equal(bytes.Length, length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Bytes_With_Length_Throw_Exception_When_Length_Is(int length)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.Bytes(length));
        }

        [Theory]
        [InlineData(10, 50, CharacterSets.All)]
        [InlineData(10, 50, CharacterSets.Lowercase)]
        [InlineData(10, 50, CharacterSets.Uppercase)]
        [InlineData(10, 50, CharacterSets.Numeric)]
        [InlineData(10, 50, CharacterSets.Special)]
        [InlineData(10, 50, CharacterSets.Lowercase | CharacterSets.Uppercase)]
        public void String_With_CharacterSet_Successful(int min, int max, CharacterSets charSets)
        {
            // Arrange
            var expectedPool = new List<char>();

            if (charSets == (charSets | CharacterSets.Uppercase))
            {
                expectedPool.AddRange(DataGenerator.UppercaseCharacters);
            }
            if (charSets == (charSets | CharacterSets.Lowercase))
            {
                expectedPool.AddRange(DataGenerator.LowercaseCharacters);
            }
            if (charSets == (charSets | CharacterSets.Numeric))
            {
                expectedPool.AddRange(DataGenerator.NumericCharacters);
            }
            if (charSets == (charSets | CharacterSets.Special))
            {
                expectedPool.AddRange(DataGenerator.SpecialCharacters);
            }

            // Act
            var actual = DataGenerator.NextString(min, max, charSets);

            // Assert
            Assert.InRange(actual.Length, min, max);
            foreach (var ch in actual)
            {
                Assert.Contains(ch, expectedPool);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void String_With_CharacterSet_Throws_Exception_When_Minimum_Is(int min)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.NextString(min, 10, CharacterSets.All));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(3)]
        public void String_With_CharacterSet_Throws_Exception_When_Maximum_Is(int max)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.NextString(5, max, CharacterSets.All));
        }

        [Fact]
        public void String_With_CharacterSet_Throws_Exception_When_CharacterSet_Is_None()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => DataGenerator.NextString(5, 10, CharacterSets.None));
        }

        [Fact]
        public void String_With_CharacterList_Successful()
        {
            // Arrange
            var expectedPool = new List<char>(DataGenerator.LowercaseCharacters);

            // Act
            var actual = DataGenerator.NextString(5, 55, expectedPool);

            // Assert
            Assert.InRange(actual.Length, 5, 55);
            foreach (var ch in actual)
            {
                Assert.Contains(ch, expectedPool);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void String_With_CharacterList_Throws_Exception_When_Minimum_Is(int min)
        {
            // Arrange
            var charList = new List<char>
                {
                    'A',
                    '1',
                    'z'
                };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.NextString(min, 10, charList));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(3)]
        public void String_With_CharacterList_Throws_Exception_When_Maximum_Is(int max)
        {
            // Arrange
            var charList = new List<char>
                {
                    'A',
                    '1',
                    'z'
                };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.NextString(5, max, charList));
        }

        [Fact]
        public void String_With_CharacterList_Throws_Exception_When_CharacterList_Is_None()
        {
            // Arrange
            var charList = new List<char>();

            // Assert
            Assert.Throws<ArgumentException>(() => DataGenerator.NextString(5, 10, charList));
        }
    }
}