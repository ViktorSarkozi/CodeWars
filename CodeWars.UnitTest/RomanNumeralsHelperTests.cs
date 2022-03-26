using FluentAssertions;
using Xunit;

namespace CodeWars.UnitTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(4, "IV")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(60, "LX")]
        [InlineData(468, "CDLXVIII")]
        [InlineData(3724, "MMMDCCXXIV")]
        public void TestToRoman(int input, string expected)
        {
            var actual = RomanNumerals.ToRoman(input);

            expected.Should().Be(actual);
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("CDLXVIII", 468)]
        [InlineData("MMMDCCXXIV", 3724)]
        public void TestFromRoman_001(string input, int expected)
        {
            var actual = RomanNumerals.FromRoman(input);

            expected.Should().Be(actual);
        }
    }
}