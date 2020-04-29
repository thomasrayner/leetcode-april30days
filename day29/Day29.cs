using System;

namespace day29
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        int MaxSum = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            SumHelper(root);
            return MaxSum;
        }

        private int SumHelper(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = SumHelper(node.left);
            int right = SumHelper(node.right);
            int current = 0;
            current = Math.Max(current, Math.Max(left + node.val, right + node.val));
            MaxSum = Math.Max(MaxSum, left + node.val + right);

            return current;
        }
    }
}
