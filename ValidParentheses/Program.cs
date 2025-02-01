/*
 * Valid Parentheses
 * 
 * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"

Output: true

Example 2:

Input: s = "()[]{}"

Output: true

Example 3:

Input: s = "(]"

Output: false

Example 4:

Input: s = "([])"

Output: true




Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.*/
using System.Diagnostics;

namespace ValidParentheses;

internal class Program
{
    static void Main(string[] args)
    {
        var testCases = new Dictionary<string, bool>
        {
            { "()", true },
            { "()[]{}", true },
            { "(]", false },
            { "([])", true }
        };

        foreach (var testCase in testCases)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = Solution.IsValid(testCase.Key);
            stopwatch.Stop();

            Console.WriteLine($"Method: IsValid, Input: {testCase.Key}, Result: {result}, Expected: {testCase.Value}, Time: {stopwatch.ElapsedTicks} ticks");
        }
    }
}

public class Solution
{
    public static bool IsValid(string s)
    {
        var pairs = new Dictionary<char, char>()
        {
            {'{', '}'},
            {'(', ')'},
            {'[', ']'}
        };

        var opens = new Stack<char>(); //use a stack to add opens

        foreach (char c in s)
        {
            if (pairs.ContainsKey(c))
            {
                opens.Push(c);
            }
            else
            {
                if (!opens.Any())
                {
                    return false;
                }

                var openBracket = opens.Peek();

                if (pairs[openBracket] == c)
                {
                    opens.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return opens.Count() == 0;
    }
}
