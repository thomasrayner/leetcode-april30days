using System;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] inputGrid = new int [][] {
                new int[] { 1, 3, 1 },
                new int[] { 1, 5, 1 },
                new int[] { 4, 2, 1 }
            };

            Solution sol = new Solution();
            int final = sol.MinPathSum(inputGrid);

            Console.WriteLine("Final (should be 7): " + final.ToString());
        }
    }

    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            // go through the grid and make a map (in adjustedGrid) that shows the cumulative
            // sums of the possible routes to that spot, choosing the smallest value as we go

            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int[][] adjustedGrid = new int[grid.Length][];
            adjustedGrid[0] = new int[grid[0].Length];

            // fill top left corner
            adjustedGrid[0][0] = grid[0][0];

            // fill top row
            for (int i = 1; i < grid.Length; i++)
            {
                adjustedGrid[i] = new int[grid[i].Length];
                adjustedGrid[i][0] = grid[i][0] + adjustedGrid[i - 1][0];
            }

            // fill left column
            for (int i = 1; i < grid[0].Length; i++)
            {
                adjustedGrid[0][i] = grid[0][i] + adjustedGrid[0][i - 1];
            }

            // fill in the rest of the cells
            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[0].Length; j++)
                {
                    adjustedGrid[i][j] = grid[i][j] + Math.Min(adjustedGrid[i - 1][j], adjustedGrid[i][j - 1]);
                }
            }

            return adjustedGrid[adjustedGrid.Length - 1][adjustedGrid[0].Length - 1];
        }
    }
}
