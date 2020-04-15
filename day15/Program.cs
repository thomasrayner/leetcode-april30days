using System;
using System.Linq;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int[] final = sol.ProductExceptSelf(ints);
            Console.WriteLine(string.Join(", ", final));
        }
    }

    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] products = new int[nums.Length];

            int prevNextProd = 1;

            // set nums[i] = the product of nums[0]..nums[i-1] ie: everything to the left
            for (int i = 0; i < nums.Length; i++)
            {
                products[i] = prevNextProd;
                prevNextProd *= nums[i];
            }

            prevNextProd = 1;

            // multiply nums[i] by the product of nums[i + 1]..nums[nums.Length - 1] ie: everything to the right
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                products[i] *= prevNextProd;
                prevNextProd *= nums[i];
            }

            return products;
        }
    }
}
