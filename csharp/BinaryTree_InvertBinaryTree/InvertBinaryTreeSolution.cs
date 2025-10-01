namespace ProgrammingChallenges
{
    public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        public int val = val;
        public TreeNode left = left;
        public TreeNode right = right;
    }

    public class InvertBinaryTreeSolution
    {
        public static TreeNode? InvertTree(TreeNode? root)
        {
            if (root == null) return null;
            if (root.left == null && root.right == null) return root;

            var temp = InvertTree(root.left)!;
            root.left = InvertTree(root.right)!;
            root.right = temp!;

            return root;
        }
    }
}
