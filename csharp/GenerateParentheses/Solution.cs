/*
22. Generate Parentheses
Medium
Topics
Companies
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

Example 1:
Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:
Input: n = 1
Output: ["()"]

Constraints:
1 <= n <= 8
*/

using System;
using System.Collections.Generic;

namespace GenerateParentheses;

public class Solution
{
    public IList<string> GenerateParentheses(int n)
    {
        // iterative backtracking using an explicit stack of states
        var result = new List<string>();
        var stack = new Stack<(string current, int open, int close)>();

        if (n <= 0)
        {
            return result;
        }

        stack.Push(("(", 1, 0));

        while (stack.Count > 0)
        {
            var (current, open, close) = stack.Pop();

            if (current.Length == n * 2)
            {
                result.Add(current);
                continue;
            }

            if (open < n)
            {
                stack.Push((current + "(", open + 1, close));
            }

            if (close < open)
            {
                stack.Push((current + ")", open, close + 1));
            }
        }

        return result;
    }

    /// <summary>
    /// Backtracking approach: Build combinations by adding '(' and ')' with constraints
    /// Time: O(4^n / sqrt(n)) - Catalan number bound
    /// Space: O(4^n / sqrt(n)) - for result storage
    /// </summary>
    public IList<string> GenerateParenthesesBacktracking(int n)
    {
        List<string> result = new(n);

        Backtrack(result, "", 0, 0, n);

        return result;
    }

    /// <summary>
    /// Recursive approach: Generate all valid combinations recursively
    /// Time: O(4^n / sqrt(n)) - Catalan number bound
    /// Space: O(4^n / sqrt(n)) - for result storage + recursion stack
    /// </summary>
    public IList<string> GenerateParenthesesRecursive(int n)
    {
        var memo = new Dictionary<int, IList<string>>();
        return GenerateRecursiveInternal(n, memo);
    }

    /// <summary>
    /// Dynamic Programming approach: Build up solutions from smaller subproblems
    /// Time: O(4^n / sqrt(n)) - Catalan number bound
    /// Space: O(4^n / sqrt(n)) - for memoization and result storage
    /// </summary>
    public IList<string> GenerateParenthesesDynamic(int n)
    {
        var dp = new List<IList<string>>(n + 1);
        dp.Add(new List<string> { "" }); // dp[0]

        for (int i = 1; i <= n; i++)
        {
            var list = new List<string>();
            for (int p = 0; p < i; p++)
            {
                var leftList = dp[p];
                var rightList = dp[i - 1 - p];
                foreach (var left in leftList)
                {
                    foreach (var right in rightList)
                    {
                        list.Add("(" + left + ")" + right);
                    }
                }
            }
            dp.Add(list);
        }

        return dp[n];
    }

    // Helper method for backtracking (if needed)
    private void Backtrack(IList<string> result, string current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            result.Add(current);
            return;
        }

        if (open < max)
        {
            var next = current + "(";
            Backtrack(result, next, open + 1, close, max);
        }

        if (close < open)
        {
            var next = current + ")";
            Backtrack(result, next, open, close + 1, max);
        }
    }

    private IList<string> GenerateRecursiveInternal(int n, Dictionary<int, IList<string>> memo)
    {
        if (memo.TryGetValue(n, out IList<string> value))
            return value;

        var result = new List<string>();
        if (n == 0)
        {
            result.Add("");
            memo[n] = result;
            return result;
        }

        for (int p = 0; p < n; p++)
        {
            var leftList = GenerateRecursiveInternal(p, memo);
            var rightList = GenerateRecursiveInternal(n - 1 - p, memo);
            foreach (var left in leftList)
            {
                foreach (var right in rightList)
                {
                    result.Add("(" + left + ")" + right);
                }
            }
        }

        memo[n] = result;
        return result;
    }
}
