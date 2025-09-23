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
using System.Text;
using System.Text.Json;

namespace GenerateParentheses;

class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // allow ✓ on Windows

        var solution = new Solution();
        var inputs = new List<int> { 1, 2, 3, 4 };

        foreach (var n in inputs)
        {
            Console.WriteLine($"Input: n = {n}");
            ExecuteGenerateParenthesesBenchmark(solution, n);
            Console.WriteLine();
        }
    }

    private static void ExecuteGenerateParenthesesBenchmark(Solution solution, int n)
    {
        var funcBacktracking = (int n) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                var result = solution.GenerateParenthesesBacktracking(n);
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParenthesesBacktracking)}\t{stopwatch.ElapsedTicks} ticks"
                );
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParenthesesBacktracking)}\tNot implemented"
                );
                return new List<string>();
            }
        };

        var funcRecursive = (int n) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                var result = solution.GenerateParenthesesRecursive(n);
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParenthesesRecursive)}\t{stopwatch.ElapsedTicks} ticks"
                );
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParenthesesRecursive)}\tNot implemented"
                );
                return new List<string>();
            }
        };

        var funcDynamic = (int n) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                var result = solution.GenerateParenthesesDynamic(n);
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParenthesesDynamic)}\t{stopwatch.ElapsedTicks} ticks"
                );
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParenthesesDynamic)}\tNot implemented"
                );
                return new List<string>();
            }
        };

        var backtrackingResult = funcBacktracking(n);
        var recursiveResult = funcRecursive(n);
        var dynamicResult = funcDynamic(n);

        var funcDefault = (int n) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                var result = solution.GenerateParentheses(n);
                stopwatch.Stop();
                Console.WriteLine(
                    $"{nameof(solution.GenerateParentheses)}\t{stopwatch.ElapsedTicks} ticks"
                );
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine($"{nameof(solution.GenerateParentheses)}\tNot implemented");
                return new List<string>();
            }
        };

        var defaultResult = funcDefault(n);

        Console.WriteLine($"{nameof(solution.GenerateParenthesesBacktracking)} results:");
        foreach (var s in backtrackingResult)
        {
            Console.WriteLine($"{(IsValidParentheses(s) ? "✓" : "✗")} {s}");
        }

        Console.WriteLine($"{nameof(solution.GenerateParenthesesRecursive)} results:");
        foreach (var s in recursiveResult)
        {
            Console.WriteLine($"{(IsValidParentheses(s) ? "✓" : "✗")} {s}");
        }

        Console.WriteLine($"{nameof(solution.GenerateParenthesesDynamic)} results:");
        foreach (var s in dynamicResult)
        {
            Console.WriteLine($"{(IsValidParentheses(s) ? "✓" : "✗")} {s}");
        }

        Console.WriteLine($"{nameof(solution.GenerateParentheses)} results:");
        foreach (var s in defaultResult)
        {
            Console.WriteLine($"{(IsValidParentheses(s) ? "✓" : "✗")} {s}");
        }
    }

    private static bool IsValidParentheses(string s)
    {
        int balance = 0;
        foreach (var ch in s)
        {
            if (ch == '(')
                balance++;
            else if (ch == ')')
                balance--;
            if (balance < 0)
                return false;
        }
        return balance == 0;
    }
}
