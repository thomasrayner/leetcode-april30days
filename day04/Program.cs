using System;
using System.Linq;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            sol.MoveZeroes(ints);
            Console.WriteLine(string.Join(", ", ints));
        }
    }

    public class Solution
    {
        // Input: [0,1,0,3,12]
        // Output: [1,3,12,0,0]
        public void MoveZeroes(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                   nums[count] = nums[i];
                   count++;
                }
            }

            while (count < nums.Length)
            {
                nums[count] = 0;
                count++;
            }
        }
    }
}
