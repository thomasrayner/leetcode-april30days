using System;
using System.Linq;

namespace day27
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] testArray = {
                new char[] {'1', '0', '1', '0', '0'},
                new char[] {'1', '0', '1', '1', '1'},
                new char[] {'1', '1', '1', '1', '1'},
                new char[] {'1', '0', '0', '1', '0'}
            };

            Solution sol = new Solution();
            int final = sol.MaximalSquare(testArray);
            Console.WriteLine("Final (should be 4): " + final.ToString());
        }
    }

    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            int maxSquareLength = 0;
            int rows = matrix.Length;
            int cols = rows > 0 ? matrix[0].Length : 0; // Need to be able to handle null matrixes

            // build the blank DP
            int[][] prog = new int[rows + 1][];
            for (int i = 0; i < rows + 1; i++)
            {
                prog[i] = new int[cols + 1];
            }

            // DP matrix is 1 longer and 1 taller than the matrix we're passed, so if the char in matrix
            // is a 1, the spot down and to the right in DP corresponds. We check left, up, dia-up-left
            // to see what the max square those cells can make is (min of all), and increment 1.
            for (int i = 1; i < prog.Length; i++)
            {
                for (int j = 1; j < prog[0].Length; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        prog[i][j] = new [] {prog[i - 1][j], prog[i][j - 1], prog[i - 1][j - 1]}.Min() + 1;
                        maxSquareLength = Math.Max(maxSquareLength, prog[i][j]);
                    }
                }
            }

            return maxSquareLength * maxSquareLength;
        }
    }
}
