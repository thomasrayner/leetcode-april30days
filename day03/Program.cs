using System;
using System.Linq;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array of numbers: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            Solution sol = new Solution();
            Console.WriteLine("Answer: " + sol.MaxSubArray(ints));
        }
    }


    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var currentMax = nums[0];
            var maxHere = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                maxHere = Math.Max(nums[i], maxHere + nums[i]);
                currentMax = Math.Max(currentMax, maxHere);
            }

            return currentMax;
        }
    }
}
