using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CodeTask.Lib;

namespace CodeTask.Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Bench), DefaultConfig.Instance.KeepBenchmarkFiles());
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    public class Bench
    {
        private static readonly Random Rnd = new Random();

        private const int ShortCount = 5;
        private const int MediumCount = 10;
        private const int LongCount = 20;

        private static readonly string[] ShortStrings;
        private static readonly string[] MediumStrings;
        private static readonly string[] LongStrings;

        private static readonly string[] ShortResults = new string[ShortCount];
        private static readonly string[] MediumResults = new string[MediumCount];
        private static readonly string[] LongResults = new string[LongCount];

        static Bench()
        {
            ShortStrings = GenerateStrings(ShortCount);
            MediumStrings = GenerateStrings(MediumCount);
            LongStrings = GenerateStrings(LongCount);
        }

        [Benchmark] 
        public void ShortSimple() => 
            SimpleWordReorderer(ShortCount, ShortStrings, ShortResults);

        [Benchmark(Baseline = true)]
        public void ShortArrSortSimple() =>
            ArrSortWordReorderer(ShortCount, ShortStrings, ShortResults);

        [Benchmark]
        public void ShortRegex() =>
            RegexWordsReorderer(ShortCount, ShortStrings, ShortResults);

        [Benchmark]
        public void MediumSimple() =>
            SimpleWordReorderer(MediumCount, MediumStrings, MediumResults);

        [Benchmark]
        public void MediumArrSortSimple() =>
            ArrSortWordReorderer(MediumCount, MediumStrings, MediumResults);

        [Benchmark]
        public void MediumRegex() =>
            RegexWordsReorderer(MediumCount, MediumStrings, MediumResults);

        [Benchmark]
        public void LongSimple() =>
            SimpleWordReorderer(LongCount, LongStrings, LongResults);

        [Benchmark]
        public void LongArrSortSimple() =>
            ArrSortWordReorderer(LongCount, LongStrings, LongResults);

        [Benchmark]
        public void LongRegex() =>
            RegexWordsReorderer(LongCount, LongStrings, LongResults);

        public void SimpleWordReorderer(int count, string[] input, string[] output)
        {
            var reorderer = new SimpleWordsReorderer();
            for (int i = 0; i < count; i++)
            {
                output[i] = StringUtils.RearrangeWords(input[i], reorderer);
            }
        }

        public void ArrSortWordReorderer(int count, string[] input, string[] output)
        {
            var reorderer = new ArrSortWordsReorderer();
            for (int i = 0; i < count; i++)
            {
                output[i] = StringUtils.RearrangeWords(input[i], reorderer);
            }
        }

        public void RegexWordsReorderer(int count, string[] input, string[] output)
        {
            var reorderer = new RegexWordReorderer();
            for (int i = 0; i < count; i++)
            {
                output[i] = StringUtils.RearrangeWords(input[i], reorderer);
            }
        }

        private static string[] GenerateStrings(int count)
        {
            var result = new string[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = GenerateString(count);
            }

            return result;
        }

        private static string GenerateString(int wordCount)
        {
            const char separator = ' ';
            var sb = new StringBuilder(wordCount * 6);
            for (int i = 0; i < wordCount; i++)
            {
                sb.Append(GenerateWord(Rnd.Next(1, 10)));
                sb.Append(separator);
            }

            return sb.ToString();
        }

        private static string GenerateWord(int length)
        {
            var chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)Rnd.Next('a', 'z' + 1);
            }

            return new string(chars);
        }
    }
}
