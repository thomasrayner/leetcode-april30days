using System;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        private int MaxDiameter = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            GetHeight(root);
            return MaxDiameter;
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);
            int diameter = leftHeight + rightHeight;

            if (diameter > MaxDiameter)
            {
                MaxDiameter = diameter;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
