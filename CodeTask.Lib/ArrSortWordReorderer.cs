using System;

namespace CodeTask.Lib
{
    public class ArrSortWordsReorderer : IWordsReorderer
    {
        private static readonly string[] Separators = {" "};

        public string GetReordered(string sentence)
        {
            sentence = sentence?.Trim();
            if (sentence is null || sentence.Length == 0)
            {
                return string.Empty; // or throw ArgumentException?
            }

            var words = sentence.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

            words[0] = FirstLetterToLower(words[0]);

            Array.Sort(words, (l, r) => l.Length - r.Length);

            words[0] = FirstLetterToUpper(words[0]);

            var result = string.Join(' ', words);
            return result;
        }

        public string FirstLetterToLower(string word)
        {
            return word.Length < 1
                ? word
                : char.ToLowerInvariant(word[0]) + word.Substring(1);
        }

        private static string FirstLetterToUpper(string word)
        {
            return word.Length < 1
                ? word
                : char.ToUpperInvariant(word[0]) + word.Substring(1);
        }
    }
}
