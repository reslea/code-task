using System;
using System.Linq;
using System.Text;

namespace CodeTask.Lib
{
    public class SimpleWordsReorderer : IWordsReorderer
    {
        private static readonly string[] Separators = { " " };

    public string GetReordered(string sentence)
        {
            sentence = sentence?.Trim();
            if (sentence is null || sentence.Length == 0)
            {
                return string.Empty; // or throw ArgumentException?
            }

            var words = sentence.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            words[0] = FirstLetterToLower(words[0]);

            var reorderedWords = words
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
