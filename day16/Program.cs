using System;

namespace day16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("String to check: ");
            string s = Console.ReadLine();

            Solution sol = new Solution();
            bool final = sol.CheckValidString(s);
            Console.WriteLine("Answer: " + final.ToString());
        }
    }

    public class Solution
    {
        public bool CheckValidString(string s)
        {
            int low = 0, high = 0;
            char[] c = s.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                low += c[i] == '(' ? 1 : -1;
                high += c[i] != ')' ? 1 : -1;

                if (high < 0)
                {
                    return false;
                }

                low = Math.Max(low, 0);
            }

            return low == 0;
        }
    }
}
