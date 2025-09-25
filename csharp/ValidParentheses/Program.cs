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
            // Basic examples
            { "()", true },
            { "()[]{}", true },
            { "(]", false },
            { "([])", true },
            // Edge cases
            { "", true }, // Empty string
            { "(", false }, // Single opening bracket
            { ")", false }, // Single closing bracket
            { "((", false }, // Only opening brackets
            { "))", false }, // Only closing brackets
            // Complex nesting
            { "{[()]}", true }, // Proper nested brackets
            { "([)]", false }, // Improper nesting
            { "{[({})]}", true }, // Deep nesting
            { "[({})]", true }, // Mixed proper nesting
            // Mismatch cases
            { "(}", false }, // Wrong closing bracket
            { "[)", false }, // Wrong closing bracket
            { "{]", false }, // Wrong closing bracket
            // Longer sequences
            { "()[]{}()", true }, // Multiple pairs
            { "((()))", true }, // Nested same type
            { "[[[]]]]", false }, // Extra closing bracket
            { "((([))))", false }, // Wrong order closing
            // Complex valid cases
            { "{[()]}[{}](([])){()}", true }, // Mixed complex nesting
            { "(){}[]", true }, // Simple sequence
            { "(((())))[[[[]]]]{{{{}}}})", false }, // Missing opening
            { "(((())))[[[[]]]][{{{}}}]", true }, // Complex balanced
        };

        foreach (var testCase in testCases)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = Solution.IsValid(testCase.Key);
            stopwatch.Stop();

            Console.WriteLine(
                $"Method: IsValid, Input: {testCase.Key}, Result: {result}, Expected: {testCase.Value}, Time: {stopwatch.ElapsedTicks} ticks"
            );
        }
    }
}
