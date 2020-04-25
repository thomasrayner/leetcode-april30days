using System;
using System.Linq;

namespace day25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            bool final = sol.CanJump(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            // the location in the array that we need to be able to reach
            int loc = nums.Length - 1;

            // work backwards from where we know we need to go, if we get stranded then we know
            // that this is false, but you have to check the whole array in case the first value
            // can jump to the end
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                // if the value in the current slot in the array can reach the target, then we
                // know that the original target is reachable, and the new target is this point
                // in the array, and so on, until we get to the start of the array
                if (i + nums[i] >= loc)
                {
                    loc = i;
                }
            }

            return loc == 0;
        }
    }
}
