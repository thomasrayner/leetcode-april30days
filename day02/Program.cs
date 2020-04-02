using System;
using System.Collections.Generic;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var happinessChecker = new HappinessChecker();

            Console.Write("Check number: ");
            int check = Convert.ToInt32(Console.ReadLine());
            var isHappy = happinessChecker.IsHappy(check);

            if (isHappy)
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine("false");
            }
        }
    }

    class HappinessChecker{
        public bool IsHappy(int n)
        {
            HashSet<int> seenNumbers = new HashSet<int>();
            int route = NumberCheck(n);

            while (seenNumbers.Add(route))
            {
                if (route == 1)
                {
                    return true;
                }

                route = NumberCheck(route);
            }

            return false;
        }

        public int NumberCheck(int num)
        {
            int calc = 0;
            List<int> listOfInts = new List<int>();

            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            foreach (int digit in listOfInts)
            {
                calc += Convert.ToInt32(Math.Pow(digit, 2));
            }

            return calc;
        }
    }
}
