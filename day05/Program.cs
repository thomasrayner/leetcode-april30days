using System;
using System.Linq;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.MaxProfit(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var max = 0;

            for (var i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i] < prices[i + 1])
                {
                    max += prices[i + 1] - prices[i];
                }
            }

            return max;
        }
    }
}
