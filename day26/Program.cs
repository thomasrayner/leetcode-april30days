using System;

namespace day26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Text 1: ");
            string text1 = Console.ReadLine();
            Console.Write("Text 2: ");
            string text2 = Console.ReadLine();

            Solution sol = new Solution();
            int final = sol.LongestCommonSubsequence(text1, text2);

            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        // Dynamic Programming isn't something I've ever dug into before, and had to look up an
        // answer for this one. Still working on undestanding how and why it works.
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] prog = new int[text2.Length + 1, text1.Length + 1];

            for (int i = 0; i <= text2.Length; i++)
            {
                for (int j = 0; j <= text1.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        prog[i, j] = 0;
                        continue;
                    }

                    if (text1[j - 1] == text2[i - 1])
                    {
                        prog[i, j] = 1 + prog[i - 1, j - 1];
                    }
                    else
                    {
                        prog[i, j] = Math.Max(prog[i, j - 1], prog[i - 1, j]);
                    }
                }

            }

            return prog[text2.Length, text1.Length];
        }
    }
}
