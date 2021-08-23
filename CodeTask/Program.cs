using System;

namespace CodeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = "Have a nice day";
            var rearrangedWordsSentence = StringUtils.RearrangeWords(sentence);

            Console.WriteLine(rearrangedWordsSentence);

            Console.ReadKey();
        }
    }
}
