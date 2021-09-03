using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTask.Lib
{
    public class FizzBuzzGenerator
    {
        public IEnumerable<string> GenerateFizzBuzz(int count)
        {
            var fizCounter = 0;
            var buzCounter = 0;
            return Enumerable.Range(1, count)
                .Select(n =>
                {
                    if (n % 15 == 0)
                    {
                        return $"{Fiz(fizCounter++)}-{Buz(buzCounter++)}";
                    }
                    else if (n % 3 == 0)
                    {
                        return Fiz(fizCounter++);
                    }
                    else if (n % 5 == 0)
                    {
                        return Buz(buzCounter++);
                    }
                    else
                    {
                        return n.ToString();
                    }
                });                
        }

        private string Fiz(int fizCounter)
        {
            return "Fiz" + new string('z', fizCounter);
        }

        private string Buz(int buzCounter)
        {
            return "Buz" + new string('z', buzCounter);
        }
    }
}
