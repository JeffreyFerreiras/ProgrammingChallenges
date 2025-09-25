namespace ValidParentheses;

public class Solution
{
    private static readonly Dictionary<char, char> s_pairs = new()
    {
        { '{', '}' },
        { '(', ')' },
        { '[', ']' },
    };

    public static bool IsValid(string s)
    {
        var opens = new Stack<char>();

        foreach (char c in s)
        {
            if (s_pairs.ContainsKey(c))
            {
                opens.Push(c);
            }
            else
            {
                if (opens.Count == 0)
                {
                    return false;
                }

                var openBracket = opens.Peek();

                if (s_pairs[openBracket] == c)
                {
                    opens.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return opens.Count == 0;
    }
}
