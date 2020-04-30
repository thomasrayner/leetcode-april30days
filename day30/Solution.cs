using System;

namespace day30
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
        public int N { get; set; }
        public int[] A { get; set; }
        public bool IsValidSequence(TreeNode root, int[] arr)
        {
            N = arr.Length;
            A = arr;
            return Visit(root, 0);
        }

        public bool Visit(TreeNode node, int index)
        {
            try
            {
                if (index == N - 1)
                {
                    if (node != null && node.val == A[index])
                    {
                        return node.left == null && node.right == null;
                    }

                    return false;
                }

                if (node.val == A[index])
                {
                    return Visit(node.left, index + 1) || Visit(node.right, index + 1);
                }
            }
            catch (System.NullReferenceException)
            {
                // This is an awful way to work around the nullref exception I am getting, but
                // I'm low on time for this one, and wanted to get the daily challenge done today.
                return false;
            }

            return false;
        }
    }
}
