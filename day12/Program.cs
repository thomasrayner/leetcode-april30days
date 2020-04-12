using System;
using System.Linq;
using System.Collections.Generic;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.LastStoneWeight(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int LastStoneWeight(int[] stones)
        {
            List<int> stoneList = stones.ToList();

            while (stoneList.Count() > 1)
            {
                int stoneX = stoneList.Max();
                stoneList.Remove(stoneX);
                int stoneY = stoneList.Max();
                stoneList.Remove(stoneY);

                if (stoneX == stoneY)
                {
                    continue;
                }

                stoneList.Add(Math.Abs(stoneX - stoneY));
            }

            return stoneList.Count() == 0 ? 0 : stoneList[0];
        }
    }
}
