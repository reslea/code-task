using CodeTask.Lib;
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

		[Theory]
		[InlineData("aaabbcccccdddde", 2, "aabbccdde")]
		[InlineData("aaabbcccccddddeabc", 1, "abcdeabc")]
		[InlineData("aaabbcccccddddeaaaab", 2, "aabbccddeaab")]
		[InlineData("", 2, "")]
		public void TestRemoveConsecutiveChars(string input, int maxLimit, string expectedOutput)
		{
			var actualOutput = input.RemoveConsecutiveChars(maxLimit);
			Assert.Equal(expectedOutput, actualOutput);
		}

		[Theory]
		[InlineData(15,
		new[]
		{
				"1",
				"2",
				"Fiz",
				"4",
				"Buz",
				"Fizz",
				"7",
				"8",
				"Fizzz",
				"Buzz",
				"11",
				"Fizzzz",
				"13",
				"14",
				"Fizzzzz-Buzzz"
		})]
		public void TestFizzBuzz(int count, string[] expectedOutput)
		{
			var actualOutput = StringUtils.FizzBuzz(count);
			Assert.Equal(expectedOutput, actualOutput);
		}
	}
}
