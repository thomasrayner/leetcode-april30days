using System;
using System.Linq;

namespace day23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.RangeBitwiseAnd(ints[0], ints[1]);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            // In a range, only the left-most common bits will AND together, so we need to keep shifting right
            // until m and n are equal (the only bits left are in common, and they will be the left-most because
            // we're shifting right and discarding the least significant - rightmost - bits). Then, we need to
            // shift back (shifting left fills the new left-most spot with zero, which would be the result of
            // ANDing the range)

            int shiftToLeftCommon = 0;

            while (m != n)
            {
                m >>= 1;
                n >>= 1;
                shiftToLeftCommon++;
            }

            return m << shiftToLeftCommon;
        }
    }
}
