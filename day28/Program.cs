using System;
using System.Collections.Generic;

namespace day28
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test case one
            FirstUnique firstUnique = new FirstUnique(new int[] { 2, 3, 5 });
            Console.WriteLine("Return 2: " + firstUnique.ShowFirstUnique()); // return 2
            firstUnique.Add(5);            // the queue is now [2,3,5,5]
            Console.WriteLine("Return 2: " + firstUnique.ShowFirstUnique()); // return 2
            firstUnique.Add(2);            // the queue is now [2,3,5,5,2]
            Console.WriteLine("Return 3: " + firstUnique.ShowFirstUnique()); // return 3
            firstUnique.Add(3);            // the queue is now [2,3,5,5,2,3]
            Console.WriteLine("Return -1: " + firstUnique.ShowFirstUnique()); // return -1

            // Test case two
            firstUnique = new FirstUnique(new int[] { 7, 7, 7, 7, 7, 7 });
            Console.WriteLine("Return -1: " + firstUnique.ShowFirstUnique()); // return -1
            firstUnique.Add(7);            // the queue is now [7,7,7,7,7,7,7]
            firstUnique.Add(3);            // the queue is now [7,7,7,7,7,7,7,3]
            firstUnique.Add(3);            // the queue is now [7,7,7,7,7,7,7,3,3]
            firstUnique.Add(7);            // the queue is now [7,7,7,7,7,7,7,3,3,7]
            firstUnique.Add(17);           // the queue is now [7,7,7,7,7,7,7,3,3,7,17]
            Console.WriteLine("Return 17: " + firstUnique.ShowFirstUnique()); // return 17

            // Test case three
            firstUnique = new FirstUnique(new int[] { 809 });
            Console.WriteLine("Return 809: " + firstUnique.ShowFirstUnique()); // return 809
            firstUnique.Add(809);          // the queue is now [809,809]
            Console.WriteLine("Return -1: " + firstUnique.ShowFirstUnique()); // return -1
        }
    }

    public class FirstUnique
    {
        public HashSet<int> NumList { get; set; }
        public List<int> UniqueNums { get; set; }

        public FirstUnique(int[] nums)
        {
            NumList = new HashSet<int>();
            UniqueNums = new List<int>();

            if (nums.Length < 1)
            {
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (NumList.Add(nums[i]))
                {
                    UniqueNums.Add(nums[i]);
                }
                else
                {
                    UniqueNums.Remove(nums[i]);
                }
            }
        }

        public int ShowFirstUnique()
        {
            return UniqueNums.Count > 0 ? UniqueNums[0] : -1;
        }

        public void Add(int value)
        {
            if (NumList.Add(value))
            {
                UniqueNums.Add(value);
            }
            else
            {
                UniqueNums.Remove(value);
            }
        }
    }

    /**
     * Your FirstUnique object will be instantiated and called as such:
     * FirstUnique obj = new FirstUnique(nums);
     * int param_1 = obj.ShowFirstUnique();
     * obj.Add(value);
     */
}
