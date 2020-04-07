using System;
using System.Linq;

namespace day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.CountElements(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int CountElements(int[] arr)
        {
            int finalCount = 0;

            foreach (int check in arr.Distinct())
            {
                if (arr.Contains(check + 1))
                {
                    finalCount += arr.Where(x => x == check).Count();
                }
            }

            return finalCount;
        }
    }
}
