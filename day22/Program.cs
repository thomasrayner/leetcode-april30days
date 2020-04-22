using System;
using System.Linq;
using System.Collections.Generic;

namespace day22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = "-1,-1,1"; //Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            Console.Write("Enter target sum: ");
            int target = 2;//Convert.ToInt32(Console.ReadLine());

            var sol = new Solution();
            int final = sol.SubarraySum(ints, target);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (map.ContainsKey(sum - k))
                {
                    count += map[sum - k];
                }
                    
                if (map.ContainsKey(sum))
                {
                    map[sum]++;
                }
                else
                {
                    map.Add(sum, 1);
                }
            }

            return count;
        }
    }
}
