using System;

namespace day14
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "abcdefg";
            int[][] shift = {
                new int[] {1, 1},
                new int[] {1, 1},
                new int[] {0, 2},
                new int[] {1, 3}
            };

            Solution sol = new Solution();
            string final = sol.StringShift(s, shift);

            Console.WriteLine("Should be efgabcd: " + final);
        }
    }

    public class Solution
    {
        public string StringShift(string s, int[][] shift)
        {
            int finalShift = 0;

            for (int i = 0; i < shift.Length; i++)
            {
                finalShift = shift[i][0] == 0 ? finalShift - shift[i][1] : finalShift + shift[i][1];
            }

            if (finalShift == 0)
            {
                return s;
            }

            string direction = finalShift > 0 ? "right" : "left";
            Console.WriteLine("Direction: " + direction);

            for (int i = 0; i < Math.Abs(finalShift); i++)
            {
                s = Shift(direction, s);
            }

            return s;
        }

        public string Shift(string Direction, string s)
        {
            char c = new char();
            switch (Direction)
            {
                case "left": 
                    c = s[0];
                    s = s.Remove(0, 1);
                    s += c;
                    break;

                case "right":
                    c = s[s.Length - 1];
                    s = s.Remove(s.Length - 1, 1);
                    s = c + s;
                    break;
                default:
                    throw new ArgumentException("Direction must be left or right");
            }

            return s;
        }
    }
}
