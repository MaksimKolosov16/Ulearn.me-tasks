using System;

namespace Benford_s_law
{
    internal class Program
    {
        public static void Main()
        {
            GetBenfordStatistics("1");
            GetBenfordStatistics("abc");
            GetBenfordStatistics("123 456 789");
            GetBenfordStatistics("abc 123 def 456 gf 789 i");
        }

        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];

            var wordOrNumbers = text.Split(' ');

            foreach (var wordOrNumber in wordOrNumbers.Where(w => w.Length > 0))
            {
                var firstSymbol = wordOrNumber[0];

                if (char.IsDigit(firstSymbol))
                {
                    statistics[firstSymbol - '0']++;
                }
            }

            return statistics;
        }
    }
}