using FluentAssertions;
using Xunit;

namespace CodeWars.UnitTest
{
    public class PascalCaseToSnakeCaseTests
    {
        [Theory]
        [InlineData("TestController","test_controller")]
        [InlineData("ThisIsBeautifulDay","this_is_beautiful_day")]
        [InlineData("Am7Days","am7_days")]
        [InlineData("My3CodeIs4TimesBetter","my3_code_is4_times_better")]
        [InlineData(
            "ArbitrarilySendingDifferentTypesToFunctionsMakesKatasCool",
            "arbitrarily_sending_different_types_to_functions_makes_katas_cool")]
        public void WhenInputIsString_ReturnPascalCaseFormat(string input, string expected)
        {
            var result = PascalCaseToSnakeCase.ToUnderscore(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1,"1")]
        [InlineData(3,"3")]
        [InlineData(40,"40")]
        public void WhenInputIsInt_ReturnNumberAsString(int input, string expected)
        {
            var result = PascalCaseToSnakeCase.ToUnderscore(input);

            result.Should().Be(expected);
        }
    }
}