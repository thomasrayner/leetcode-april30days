using System;
using System.Collections.Generic;

namespace day09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter S: ");
            string s = Console.ReadLine();
            Console.Write("Enter T: ");
            string t = Console.ReadLine();

            Solution sol = new Solution();
            bool final = sol.BackspaceCompare(s, t);

            Console.WriteLine("S: " + sol.ParseString(s) + " T: " + sol.ParseString(t));
            Console.WriteLine("Match: " + final.ToString());
        }
    }

    public class Solution
    {
        public bool BackspaceCompare(string S, string T)
        {
            if (ParseString(S) == ParseString(T))
            {
                return true;
            }

            return false;
        }

        public string ParseString(string rawString)
        {
            char bs = '#';

            for (int i = 0; i < rawString.Length; i++)
            {
                if (rawString[i] != bs)
                {
                    continue;
                }

                if (i > 0)
                {
                    i--;
                    rawString = rawString.Remove(i, 2);
                }

                else
                {
                    rawString = rawString.Remove(i, 1);
                }

                i--;
            }

            return rawString;
        }
    }
}
