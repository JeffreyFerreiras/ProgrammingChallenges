/*
Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two ones added together. 
12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. 
Instead, the number four is written as IV. Because the one is before the five we subtract it making four. 
The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.

Constraints:
1 <= s.length <= 15
s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
It is guaranteed that s is a valid roman numeral in the range [1, 3999].
*/

namespace RomanToInteger;

public class Program
{

    static void Main(string[] args)
    {
        var program = new Program();
        var testCases = new[]
        {
            ("III", 3),
            ("IV", 4),
            ("IX", 9),
            ("LVIII", 58),
            ("MCMXCIV", 1994)
        };

        var allTestsPassed = true;
        var stopwatch = new System.Diagnostics.Stopwatch();

        foreach (var (input, expected) in testCases)
        {
            stopwatch.Restart();
            var result = program.RomanToInt(input);
            stopwatch.Stop();

            var passed = result == expected;
            allTestsPassed &= passed;

            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedMilliseconds}ms)");
            Console.WriteLine($"Test {(passed ? "PASSED" : "FAILED")}");
            Console.WriteLine();
        }

        Console.WriteLine($"All tests {(allTestsPassed ? "PASSED!" : "FAILED!")}");
    }

    /// <summary>
    /// Converts a Roman numeral string to an integer value
    /// </summary>
    /// <param name="s">The Roman numeral string to convert</param>
    /// <returns>The integer value of the Roman numeral</returns>
    public int RomanToInt(string s)
    {
        var sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // Get the value of current Roman numeral character
            var value = ToInt(s[i]);
            // Get the value of next Roman numeral character (0 if we're at the end)
            var next = s.Length - 1 == i ? 0 : ToInt(s[i + 1]);

            // If current value is greater or equal to next value,
            // simply add the current value to sum (e.g., VI = 5 + 1 = 6)
            if (value >= next)
            {
                sum += value;
            }
            // If current value is less than next value,
            // subtract current from next and add result to sum
            // (e.g., IV = 5 - 1 = 4)
            // Skip next character since we've already used it
            else
            {
                sum += (next - value);
                i++;
            }
        }

        return sum;
    }

    /// <summary>
    /// Converts a single Roman numeral character to its integer value
    /// </summary>
    /// <param name="c">The Roman numeral character to convert</param>
    /// <returns>The integer value of the Roman numeral character</returns>
    private int ToInt(char c)
    {
        return c switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => 0
        };
    }
}