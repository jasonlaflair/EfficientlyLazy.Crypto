using System;
using System.Collections.Generic;
using System.Linq;
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
        [InlineData(2, 200)]
        [InlineData(5, 500)]
        [InlineData(60, 60)]
        public void SetDefaults_Length_Successful(int min, int max)
        {
            // Act
            DataGenerator.SetDefaults(min, max, CharacterSet.All);

            // Assert
            Assert.Equal(min, DataGenerator.DefaultMinimumLength);
            Assert.Equal(max, DataGenerator.DefaultMaximumLength);
        }

        [Theory]
        [InlineData(CharacterSet.Lowercase)]
        [InlineData(CharacterSet.Uppercase)]
        [InlineData(CharacterSet.Numeric)]
        [InlineData(CharacterSet.Special)]
        [InlineData(CharacterSet.All)]
        [InlineData(CharacterSet.Lowercase | CharacterSet.Uppercase)]
        [InlineData(CharacterSet.Lowercase | CharacterSet.Uppercase | CharacterSet.Numeric)]
        [InlineData(CharacterSet.Special | CharacterSet.Lowercase | CharacterSet.Numeric)]
        public void SetDefaults_CharacterSets_Successful(CharacterSet set)
        {
            // Arrange
            var expectedPool = new List<char>();

            if (set == (set | CharacterSet.Uppercase))
            {
                expectedPool.AddRange(DataGenerator.UppercaseCharacters);
            }
            if (set == (set | CharacterSet.Lowercase))
            {
                expectedPool.AddRange(DataGenerator.LowercaseCharacters);
            }
            if (set == (set | CharacterSet.Numeric))
            {
                expectedPool.AddRange(DataGenerator.NumericCharacters);
            }
            if (set == (set | CharacterSet.Special))
            {
                expectedPool.AddRange(DataGenerator.SpecialCharacters);
            }

            // Act
            DataGenerator.SetDefaults(5, 10, set);

            // Assert
            Assert.True(!DataGenerator.DefaultCharacterPool.Except(expectedPool).Any());
        }

        [Fact]
        public void SetDefaults_CharacterList_Successful()
        {
            // Arrange
            var expectedPool = new List<char>
                {
                    'A',
                    'Z',
                    '%',
                    '1'
                };

            // Act
            DataGenerator.SetDefaults(5, 10, expectedPool);

            // Assert
            Assert.True(!DataGenerator.DefaultCharacterPool.Except(expectedPool).Any());
            Assert.NotEqual(expectedPool, DataGenerator.DefaultCharacterPool);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void SetDefaults_CharacterSet_Throws_Exception_When_Mininmum_Is(int minimumValue)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.SetDefaults(minimumValue, 50, CharacterSet.All));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(3)]
        public void SetDefaults_CharacterSet_Throws_Exception_When_Maximum_Is(int maximumValue)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.SetDefaults(5, maximumValue, CharacterSet.All));
        }

        [Fact]
        public void SetDefaults_CharacterSet_Throws_Exception_When_None_Specified()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.SetDefaults(5, 10, CharacterSet.None));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void SetDefaults_CharacterList_Throws_Exception_When_Mininmum_Is(int minimumValue)
        {
            // Arrange
            var charPool = new List<char>
                {
                    'A',
                    'Z',
                    '%',
                    '1'
                };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.SetDefaults(minimumValue, 50, charPool));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(3)]
        public void SetDefaults_CharacterList_Throws_Exception_When_Maximum_Is(int maximumValue)
        {
            // Arrange
            var charPool = new List<char>
                {
                    'A',
                    'Z',
                    '%',
                    '1'
                };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.SetDefaults(5, maximumValue, charPool));
        }

        [Fact]
        public void SetDefaults_CharacterList_Throws_Exception_When_None_Specified()
        {
            // Arrange
            var charPool = new List<char>();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.SetDefaults(5, 10, charPool));
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(1, int.MaxValue)]
        [InlineData(5, 5)]
        public void Integer_With_Min_Max_Returns_Valid_Random_Integer(int min, int max)
        {
            // Act
            var actual = DataGenerator.Integer(min, max);

            // Assert
            Assert.InRange(actual, min, max);
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(1, int.MaxValue)]
        [InlineData(5, 5)]
        public void Integer_With_Defaults_Returns_Valid_Random_Integer(int min, int max)
        {
            // Arrange
            DataGenerator.SetDefaults(min, max, CharacterSet.All);

            // Act
            var actual = DataGenerator.Integer();

            // Assert
            Assert.Equal(min, DataGenerator.DefaultMinimumLength);
            Assert.Equal(max, DataGenerator.DefaultMaximumLength);
            Assert.InRange(actual, min, max);
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
        [InlineData(10, 50, CharacterSet.All)]
        [InlineData(10, 50, CharacterSet.Lowercase)]
        [InlineData(10, 50, CharacterSet.Uppercase)]
        [InlineData(10, 50, CharacterSet.Numeric)]
        [InlineData(10, 50, CharacterSet.Special)]
        [InlineData(10, 50, CharacterSet.Lowercase | CharacterSet.Uppercase)]
        public void String_With_CharacterSet_Successful(int min, int max, CharacterSet charSets)
        {
            // Arrange
            var expectedPool = new List<char>();

            if (charSets == (charSets | CharacterSet.Uppercase))
            {
                expectedPool.AddRange(DataGenerator.UppercaseCharacters);
            }
            if (charSets == (charSets | CharacterSet.Lowercase))
            {
                expectedPool.AddRange(DataGenerator.LowercaseCharacters);
            }
            if (charSets == (charSets | CharacterSet.Numeric))
            {
                expectedPool.AddRange(DataGenerator.NumericCharacters);
            }
            if (charSets == (charSets | CharacterSet.Special))
            {
                expectedPool.AddRange(DataGenerator.SpecialCharacters);
            }

            // Act
            var actual = DataGenerator.String(min, max, charSets);

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
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.String(min, 10, CharacterSet.All));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(3)]
        public void String_With_CharacterSet_Throws_Exception_When_Maximum_Is(int max)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.String(5, max, CharacterSet.All));
        }

        [Fact]
        public void String_With_CharacterSet_Throws_Exception_When_CharacterSet_Is_None()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => DataGenerator.String(5, 10, CharacterSet.None));
        }

        [Fact]
        public void String_With_CharacterList_Successful()
        {
            // Arrange
            var expectedPool = new List<char>(DataGenerator.LowercaseCharacters);

            // Act
            var actual = DataGenerator.String(5, 55, expectedPool);

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
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.String(min, 10, charList));
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
            Assert.Throws<ArgumentOutOfRangeException>(() => DataGenerator.String(5, max, charList));
        }

        [Fact]
        public void String_With_CharacterList_Throws_Exception_When_CharacterList_Is_None()
        {
            // Arrange
            var charList = new List<char>();

            // Assert
            Assert.Throws<ArgumentException>(() => DataGenerator.String(5, 10, charList));
        }

        [Theory]
        [InlineData(10, 50, CharacterSet.All)]
        [InlineData(10, 50, CharacterSet.Lowercase)]
        [InlineData(10, 50, CharacterSet.Uppercase)]
        [InlineData(10, 50, CharacterSet.Numeric)]
        [InlineData(10, 50, CharacterSet.Special)]
        [InlineData(10, 50, CharacterSet.Lowercase | CharacterSet.Uppercase)]
        public void String_Default_Successful(int min, int max, CharacterSet charSets)
        {
            // Arrange
            var expectedPool = new List<char>();

            if (charSets == (charSets | CharacterSet.Uppercase))
            {
                expectedPool.AddRange(DataGenerator.UppercaseCharacters);
            }
            if (charSets == (charSets | CharacterSet.Lowercase))
            {
                expectedPool.AddRange(DataGenerator.LowercaseCharacters);
            }
            if (charSets == (charSets | CharacterSet.Numeric))
            {
                expectedPool.AddRange(DataGenerator.NumericCharacters);
            }
            if (charSets == (charSets | CharacterSet.Special))
            {
                expectedPool.AddRange(DataGenerator.SpecialCharacters);
            }

            DataGenerator.SetDefaults(min, max, charSets);

            // Act
            var actual = DataGenerator.String();

            // Assert
            Assert.Equal(min, DataGenerator.DefaultMinimumLength);
            Assert.Equal(max, DataGenerator.DefaultMaximumLength);
            Assert.True(!expectedPool.Except(DataGenerator.DefaultCharacterPool).Any());
            Assert.InRange(actual.Length, min, max);
            foreach (var ch in actual)
            {
                Assert.Contains(ch, expectedPool);
            }
        }
    }
}