using System.Diagnostics;

// Full LeetCode Problem Explanation and Examples:
// Problem 17. Letter Combinations of a Phone Number
// Given a string containing digits from 2-9 inclusive, return all possible letter combinations
// that the number could represent. A mapping of digit to letters (just like on the telephone buttons)
// is given below. Note that 1 does not map to any letters.
// Example:
// Input: digits = "23"
// Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
// Explanation: 
// 2 maps to "abc", 3 maps to "def". Thus the combinations are as above.
// ... (full explanation and examples can be added as needed)

namespace LetterCombinationsofAPhoneNumber;

class Program
{
    private static void Main(string[] args)
    {
        var solution = new Solution();
        var testScenarios = new List<(string input, IList<string> expected, string methodName)>
        {
            ("23", new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }, "LetterCombinations"),
            // Add more scenarios if needed.
        };

        foreach (var scenario in testScenarios)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = solution.LetterCombinations(scenario.input);
            stopwatch.Stop();

            Console.WriteLine($"Method: {scenario.methodName}");
            Console.WriteLine($"Time (ticks): {stopwatch.ElapsedTicks}");
            Console.WriteLine($"Input: {scenario.input}");
            Console.WriteLine($"Result: [{string.Join(", ", result)}]");
            Console.WriteLine($"Expected: [{string.Join(", ", scenario.expected)}]");
            Console.WriteLine(new string('-', 40));
        }
    }
}
