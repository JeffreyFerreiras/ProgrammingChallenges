namespace BinaryTree_MaximumDepthofBinaryTree {
	public class Solution {
		public int MaxDepth(TreeNode root) {
			if(root == null) return 0;
			if(root.left == null && root.right == null) return 1;
			return 1+ Math.Max(MaxDepth(root.left), MaxDepth(root.right));
		}
	}

	public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
		public int val = val;
		public TreeNode left = left;
		public TreeNode right = right;
    }
}
