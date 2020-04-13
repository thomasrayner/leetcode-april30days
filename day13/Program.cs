using System;
using System.Linq;
using System.Collections.Generic;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.FindMaxLength(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> indexCountMap = new Dictionary<int, int>();
            int maxLength = 0;
            int relativeCount = 0;

            // Initialize at the "spot before the array", ones relative to zeros is zero
            indexCountMap.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                // If there is a one, increment the relative count, if there's a zero, decrement it
                // We don't care how many ones and zeros there are, just if the count of them is equal
                // So we're looking for indexes in the array that have the same relative count
                relativeCount += nums[i] == 1 ? 1 : -1;

                if (indexCountMap.ContainsKey(relativeCount))
                {
                    // If we've already seen this relative count, this is a candidate for the max length
                    // The new max length is either an already determined max length, or the difference
                    // Between this current spot in the index, or the first occrence of this relative
                    // Count
                    maxLength = Math.Max(maxLength, (i - indexCountMap[relativeCount]));
                }

                else 
                {
                    // We haven't seen this relative count before, so add it, identifying this spot as
                    // The first place we've seen this relative count
                    indexCountMap.Add(relativeCount, i);
                }
            }

            return maxLength;
        }
    }
}
