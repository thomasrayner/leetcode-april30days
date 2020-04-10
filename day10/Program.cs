using System;
using System.Collections;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine("Should be -3: " + minStack.GetMin());  //--> Returns - 3.
            minStack.Pop();
            Console.WriteLine("Should be 0: " + minStack.Top());     // --> Returns 0.
            Console.WriteLine("Should be -2: " + minStack.GetMin());  //--> Returns - 2.
        }
    }

    public class MinStack
    {
        public Stack fullStack { get; set; }
        /** initialize your data structure here. */
        public MinStack()
        {
            fullStack = new Stack();
        }

        public void Push(int x)
        {
            fullStack.Push(x);
        }

        public void Pop()
        {
            fullStack.Pop();
        }

        public int Top()
        {
            if (fullStack.Count == 0)
            {
                return int.MinValue;
            }

            return Convert.ToInt32(fullStack.Peek());
        }

        public int GetMin()
        {
            int min = int.MaxValue;

            foreach (int i in fullStack)
            {
                if (i < min)
                {
                    min = i;
                }
            }

            return min;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
