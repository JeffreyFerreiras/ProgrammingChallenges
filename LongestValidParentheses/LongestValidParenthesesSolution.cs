public static class LongestValidParenthesesSolution
{
    public static int LongestValidParentheses(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int maxLen = 0;
        Stack<int> stack = new();
        stack.Push(-1);

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    maxLen = Math.Max(maxLen, i - stack.Peek());
                }
            }
        }

        return maxLen;
    }
}
