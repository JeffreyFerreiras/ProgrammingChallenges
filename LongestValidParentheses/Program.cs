using System.Diagnostics;

class Program
{
    /*
    Hard -
    Longest Valid Parentheses:
    Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
    
    Example:
      Input: "(()"
      Output: 2
    
      Input: ")()())"
      Output: 4
    */

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var scenarios = new[]
        {
            new { Input = "(()", Expected = 2 },
            new { Input = ")()())", Expected = 4 }
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            int result = LongestValidParenthesesSolution.LongestValidParentheses(scenario.Input);
            stopwatch.Stop();
            Console.WriteLine($"LongestValidParentheses: {stopwatch.ElapsedTicks} ticks, Result: {result}, Expected: {scenario.Expected}");
        }
    }
}
