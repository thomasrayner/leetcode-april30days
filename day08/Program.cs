using System;
using System.Linq;

namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            LinkedList nodeList = new LinkedList();
            nodeList.AddFirst(ints[0]);

            for (int i = 1; i < ints.Length; i++)
            {
                nodeList.AddLast(ints[i]);
            }

            var sol = new Solution();
            ListNode final = sol.MiddleNode(nodeList.head);
            Console.WriteLine(final.val);
        }
    }

    public class LinkedList
    {
        public ListNode head;

        public void AddFirst(int data)
        {
            ListNode toAdd = new ListNode(data);
            toAdd.next = head;

            head = toAdd;
        }

        public void AddLast(int data)
        {
            if (head == null)
            {
                head = new ListNode(data);
                head.next = null;
            }
            else
            {
                ListNode toAdd = new ListNode(data);

                ListNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public int countNodes = 0;

        public void CountAllNodes(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            countNodes++;
            CountAllNodes(head.next);
        }

        public ListNode GetMiddleNode(int index, int countMiddle, ListNode node)
        {
            if (index == countMiddle)
            {
                return node;
            }

            return GetMiddleNode(index + 1, countMiddle, node.next);
        }

        public ListNode MiddleNode(ListNode head)
        {
            CountAllNodes(head);
            int countMiddle = countNodes / 2;

            if (countNodes % 2 != 0)
            {
                countMiddle++;
                return GetMiddleNode(0, countMiddle - 1, head);
            }

            else
            {
                return GetMiddleNode(0, countMiddle, head);
            }
        }
    }
}
