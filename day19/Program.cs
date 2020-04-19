using System;
using System.Linq;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            Console.Write("Enter the target: ");
            int target = Convert.ToInt32(Console.ReadLine());

            var sol = new Solution();
            int final = sol.Search(ints, target);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;

            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] == target)
                {
                    // we found the target
                    return mid;
                }
                else if (nums[start] <= nums[mid])
                {
                    // the front half is in order
                    if (target >= nums[start] && target <= nums[mid])
                    {
                        // the target is in this segment - repeat the process within this segment
                        end = mid - 1;
                    }
                    else
                    {
                        // the target is in the other segment - repeat the process with other segment
                        start = mid + 1;
                    }
                }
                else
                {
                    // the back half must be in order
                    if (target >= nums[mid] && target <= nums[end])
                    {
                        // the target is in this segment
                        start = mid + 1;
                    }
                    else
                    {
                        // the target is in the other segment
                        end = mid - 1;
                    }
                }
            }

            // we get here if the target isn't in the array
            return -1;
        }
    }
}
