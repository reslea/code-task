using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeTask.Lib
{
    public class RegexWordReorderer : IWordsReorderer
    {
        public static Regex NotWordRegex = new Regex(@"\W", RegexOptions.Compiled);
        
        public string GetReordered(string sentence)
        {
            sentence = sentence?.Trim();
            if (sentence is null || sentence.Length == 0)
            {
                return string.Empty;
            }

            var wordsToReorder = NotWordRegex.Split(sentence);

            wordsToReorder[0] = FirstLetterToLower(wordsToReorder[0]);

            var reorderedWords = wordsToReorder
                .OrderBy(w => w.Length)
                .ToArray();

            reorderedWords[0] = FirstLetterToUpper(reorderedWords[0]);

            var result = string.Join(' ', reorderedWords);
            return result;
        }

        private string FirstLetterToLower(string word)
        {
            return word.Length < 1
                ? word
                : char.ToLowerInvariant(word[0]) + word.Substring(1);
        }

        private string FirstLetterToUpper(string word)
        {
            return word.Length < 1
                ? word
                : char.ToUpperInvariant(word[0]) + word.Substring(1); ;
        }
    }
}
