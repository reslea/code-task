using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTask.Lib
{
    public static class StringExtentions
    {
        public static string RemoveConsecutiveChars(this string input, int maxLimit)
        {
            input = input?.Trim();
            if (input is null || input.Length == 0)
            {
                return string.Empty; // or throw ArgumentException?
            }

            var borders = GetCharBorders(input);

            var sb = new StringBuilder(input.Length);
            for (int i = 0; i < borders.Count; i++)
            {
                var (currentStartIdx, currentLength) = borders[i];
                var length = maxLimit < currentLength
                    ? maxLimit
                    : currentLength;
                sb.Append(input.AsSpan(currentStartIdx, length));
            }

            return sb.ToString();
        }

        private static List<(int, int)> GetCharBorders(string input)
        {
            var borders = new List<(int, int)>(input.Length);
            char? prev = null;
            var currentStartIdx = 0;
            var currentLength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var current = input[i];
                if (prev == null || current == prev)
                {
                    currentLength++;
                }
                else
                {
                    borders.Add((currentStartIdx, currentLength));
                    currentLength = 1;
                    currentStartIdx = i;
                }

                prev = input[i];
            }

            var (start, length) = borders[borders.Count-1];

            var isLastCharSkipped = start + length != input.Length;
            if (isLastCharSkipped)
            {
                borders.Add((input.Length - 1, 1));
            }

            return borders;
        }
    }
}
