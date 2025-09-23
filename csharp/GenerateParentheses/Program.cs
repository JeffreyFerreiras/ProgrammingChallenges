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
using System.Text.Json;

namespace GenerateParentheses;

class Program
{
    private static void Main(string[] args)
    {
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
                Console.WriteLine($"{nameof(solution.GenerateParenthesesBacktracking)}\t{stopwatch.ElapsedTicks} ticks");
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine($"{nameof(solution.GenerateParenthesesBacktracking)}\tNot implemented");
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
                Console.WriteLine($"{nameof(solution.GenerateParenthesesRecursive)}\t{stopwatch.ElapsedTicks} ticks");
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine($"{nameof(solution.GenerateParenthesesRecursive)}\tNot implemented");
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
                Console.WriteLine($"{nameof(solution.GenerateParenthesesDynamic)}\t{stopwatch.ElapsedTicks} ticks");
                return result;
            }
            catch (NotImplementedException)
            {
                stopwatch.Stop();
                Console.WriteLine($"{nameof(solution.GenerateParenthesesDynamic)}\tNot implemented");
                return new List<string>();
            }
        };

        var backtrackingResult = funcBacktracking(n);
        var recursiveResult = funcRecursive(n);
        var dynamicResult = funcDynamic(n);

        Console.WriteLine($"{nameof(solution.GenerateParenthesesBacktracking)}\t{JsonSerializer.Serialize(backtrackingResult)}");
        Console.WriteLine($"{nameof(solution.GenerateParenthesesRecursive)}\t{JsonSerializer.Serialize(recursiveResult)}");
        Console.WriteLine($"{nameof(solution.GenerateParenthesesDynamic)}\t{JsonSerializer.Serialize(dynamicResult)}");
    }
}