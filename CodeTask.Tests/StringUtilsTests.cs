using System;
using Xunit;

namespace CodeTask.Tests
{
    public class StringUtilsTests
    {
        [Theory]
        [InlineData("Coding is cool", "Is cool coding")]
        [InlineData("Keep calm and code on", "On and keep calm code")]
        [InlineData("To be or not to be", "To be or to be not")]
        public void Test(string input, string expectedOutput)
        {
            var actualOutput = StringUtils.RearrangeWords(input);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
