using System;
using System.Collections.Generic;
using System.Linq;
using CodeTask.Lib;

namespace CodeTask
{
    public static class StringUtils
    {
        private static readonly IWordsReorderer DefaultReorderer = new ArrSortWordsReorderer();

        public static string RearrangeWords(string sentence)
        {
            return DefaultReorderer.GetReordered(sentence);
        }

        // for benchmark purposes
        public static string RearrangeWords(string sentence, IWordsReorderer reorderer)
        {
            reorderer ??= DefaultReorderer;

            return reorderer.GetReordered(sentence);
        }

        public static IEnumerable<string> FizzBuzz(int count)
        {
            return new FizzBuzzGenerator().GenerateFizzBuzz(15);
        }
    }
}
