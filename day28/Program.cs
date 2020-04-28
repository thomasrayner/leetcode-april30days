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
        public LinkedList<int> NumQueue { get; set; }
        public Dictionary<int, int> NumDict { get; set; }

        public FirstUnique(int[] nums)
        {
            NumQueue = new LinkedList<int>();
            NumDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                Add(nums[i]);
            }
        }

        public void Add(int num)
        {
            if (NumDict.ContainsKey(num))
            {
                NumDict[num]++;
            }
            else
            {
                NumDict.Add(num, 1);
                NumQueue.AddLast(num);
            }
        }

        public int ShowFirstUnique()
        {
            while (NumQueue.Count > 0)
            {
                int c = NumQueue.First.Value;

                if (NumDict[c] == 1)
                {
                    return c;
                }

                NumQueue.RemoveFirst();
            }

            return -1;
        }
    }

    /**
     * Your FirstUnique object will be instantiated and called as such:
     * FirstUnique obj = new FirstUnique(nums);
     * int param_1 = obj.ShowFirstUnique();
     * obj.Add(value);
     */
}
