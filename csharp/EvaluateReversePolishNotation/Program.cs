/*
Evaluate Reverse Polish Notation
Medium

You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.

Evaluate the expression. Return an integer that represents the value of the expression.

Note that:

The valid operators are '+', '-', '*', and '/'.
Each operand may be an integer or another expression.
The division between two integers always truncates toward zero.
There will not be any division by zero.
The input represents a valid arithmetic expression in a Reverse Polish Notation.
The answer and all the intermediate calculations can be represented in a 32-bit integer.

Example 1:

Input: tokens = ["2","1","+","3","*"]
Output: 9
Explanation: ((2 + 1) * 3) = 9
Example 2:

Input: tokens = ["4","13","5","/","+"]
Output: 6
Explanation: (4 + (13 / 5)) = 6
Example 3:

Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
Output: 22
Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
= ((10 * (6 / (12 * -11))) + 17) + 5
= ((10 * (6 / -132)) + 17) + 5
= ((10 * 0) + 17) + 5
= (0 + 17) + 5
= 22

Constraints:

1 <= tokens.length <= 104
tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].
*/

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace EvaluateReversePolishNotation;

class Program
{
    private static void Main(string[] args)
    {
        var inputs = new List<(string[] tokens, int expected)>
        {
            // Basic examples from problem statement
            (new string[] { "2", "1", "+", "3", "*" }, 9),
            (new string[] { "4", "13", "5", "/", "+" }, 6),
            (
                new string[]
                {
                    "10",
                    "6",
                    "9",
                    "3",
                    "+",
                    "-11",
                    "*",
                    "/",
                    "*",
                    "17",
                    "+",
                    "5",
                    "+",
                },
                22
            ),
            // Single number
            (new string[] { "42" }, 42),
            // Simple operations
            (new string[] { "5", "3", "+" }, 8),
            (new string[] { "15", "7", "-" }, 8),
            (new string[] { "3", "4", "*" }, 12),
            (new string[] { "20", "4", "/" }, 5),
            // Negative numbers
            (new string[] { "-5", "3", "+" }, -2),
            (new string[] { "5", "-3", "+" }, 2),
            (new string[] { "-10", "-5", "*" }, 50),
            (new string[] { "-15", "3", "/" }, -5),
            // Division truncation toward zero
            (new string[] { "7", "3", "/" }, 2),
            (new string[] { "-7", "3", "/" }, -2),
            (new string[] { "7", "-3", "/" }, -2),
            (new string[] { "-7", "-3", "/" }, 2),
            // More complex expressions
            (new string[] { "1", "2", "+", "3", "4", "+", "*" }, 21), // (1+2) * (3+4) = 3 * 7 = 21
            (
                new string[]
                {
                    "15",
                    "7",
                    "1",
                    "1",
                    "+",
                    "-",
                    "/",
                    "3",
                    "*",
                    "2",
                    "1",
                    "1",
                    "+",
                    "+",
                    "-",
                },
                5
            ), // ((15/(7-(1+1)))*3)-(2+(1+1)) = (15/5)*3-4 = 9-4 = 5
            (new string[] { "2", "1", "*", "2", "/" }, 1), // (2*1)/2 = 1
            (new string[] { "4", "2", "/", "2", "/", "2", "*" }, 2), // ((4/2)/2)*2 = (2/2)*2 = 1*2 = 2
            // Edge cases with zero
            (new string[] { "0", "5", "+" }, 5),
            (new string[] { "0", "5", "*" }, 0),
            (new string[] { "5", "0", "-" }, 5),
        };

        foreach (var input in inputs)
        {
            //print the input
            Console.WriteLine($@"{nameof(input.tokens)}	{JsonSerializer.Serialize(input.tokens)}");
            Console.WriteLine($@"Expected: {input.expected}");
            ExecuteEvalRPNBenchmark(input.tokens, input.expected);
            //new line
            Console.WriteLine();
        }
    }

    private static void ExecuteEvalRPNBenchmark(string[] tokens, int expected)
    {
        var solution = new Solution();
        var funcEvalRPN = (string[] tokens) =>
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = solution.ComputeReversePolishNotation(tokens);
            stopwatch.Stop();
            Console.WriteLine(
                $@"{nameof(Solution.ComputeReversePolishNotation)}	{stopwatch.ElapsedTicks} ticks"
            );
            return result;
        };

        var actualResult = funcEvalRPN(tokens);
        var isCorrect = actualResult == expected;
        var checkmark = isCorrect ? "✅" : "❌";

        Console.WriteLine($@"Result: {actualResult} {checkmark}");
        Console.WriteLine($@"{nameof(Solution.ComputeReversePolishNotation)}	{actualResult}");
    }

    /***
     * You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.
     * Evaluate the expression. Return an integer that represents the value of the expression.
     *
     * Example 1: Input: tokens = ["2","1","+","3","*"] Output: 9 Explanation: ((2 + 1) * 3) = 9
     * Example 2: Input: tokens = ["4","13","5","/","+"] Output: 6 Explanation: (4 + (13 / 5)) = 6
     **/

    // speed: O(n) space: O(n)
    // Implementation moved to Solution class
}
