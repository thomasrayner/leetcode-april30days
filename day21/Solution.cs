using System;
using System.Collections.Generic;

namespace day21
{
    /**
     * // This is BinaryMatrix's API interface.
     * // You should not implement it, or speculate about its implementation
     * class BinaryMatrix {
     *     public int Get(int x, int y) {}
     *     public IList<int> Dimensions() {}
     * }
     */

    class Solution
    {
        // this is not ever going to work locally because it doesn't have the BinaryMatrix class
        // this is an "interactive problem": https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3306/
        // this solution is based on "hint 2" given in the problem (I'm not sure why the hint spoon fed the solution) - 
        // (Optimal Approach) Imagine there is a pointer p(x, y) starting from top right corner. p can only move
        // left or down. If the value at p is 0, move down. If the value at p is 1, move left. 
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            IList<int> dim = binaryMatrix.Dimensions();

            int ptrRow = 0;
            int ptrCol = dim[1] - 1;
            int leftMostCol = -1;

            while (ptrRow < dim[0] && ptrCol >= 0)
            {
                if (binaryMatrix.Get(ptrRow, ptrCol) == 0)
                {
                    ptrRow++;
                }
                else
                {
                    leftMostCol = ptrCol;
                    ptrCol--;
                }
            }

            return leftMostCol;
        }
    }
}
