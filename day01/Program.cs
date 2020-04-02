using System;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.SingleNumber(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            return nums.GroupBy(x => x).Where(y => y.Count() == 1).Select(z => z.Key).FirstOrDefault();
        }
    }
}
