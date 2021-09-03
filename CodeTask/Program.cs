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

            foreach (var f in StringUtils.FizzBuzz(15))
            {
                Console.WriteLine(f);
            }

            Console.ReadKey();
        }
    }
}
