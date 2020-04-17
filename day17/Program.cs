using System;

namespace day17
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
        }
    }

    public class Solution
    {
        // Ended up having to look up this solution - spending too much time getting stuck in infinite recursion
        // Well, I ended up really close, and a ton of my issues were caused by the fact that leetcode's
        // scaffolding said NumIslands was receiving a char[,] but it's actually passing it a char[][], and
        // that additional confusion really messed me up, but by that point, I had already spoiled the problem
        // for myself by looking for help. I would have got it eventually, if leetcode hadn't lied to me.
        public int NumIslands(char[][] grid)
        {
            int islandCount = 0;

            if (grid == null) return islandCount;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        islandCount++;
                        updateGrid(grid, i, j);
                    }
                }
            }

            return islandCount;
        }

        private void updateGrid(char[][]grid, int i, int j)
        {
            // 1. row < 0
            // 2. row > grid length
            // 3. col < 0
            // 4. col > grid height
            // 5. if position is a 0
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0') return;

            grid[i][j] = '0';

            updateGrid(grid, i - 1, j); // down
            updateGrid(grid, i + 1, j); // up
            updateGrid(grid, i, j - 1); // left
            updateGrid(grid, i, j + 1); // right
        }
    }
}