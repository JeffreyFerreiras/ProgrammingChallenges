using System;
using System.Collections.Generic;

namespace EvaluateReversePolishNotation;

public class Solution
{
    public int ComputeReversePolishNotation(string[] tokens)
    {
        Stack<int> numbers = new();

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int num))
            {
                numbers.Push(num);
            }
            else
            {
                int second = numbers.Pop(); // Second operand
                int first = numbers.Pop(); // First operand
                int result = token switch
                {
                    "+" => first + second,
                    "-" => first - second,
                    "*" => first * second,
                    "/" => first / second,
                    _ => throw new NotSupportedException(),
                };
                numbers.Push(result);
            }
        }

        return numbers.Peek();
    }
}
