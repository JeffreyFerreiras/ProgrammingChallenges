using System.Diagnostics;

// LeetCode Problem: Longest Palindromic Substring
// 
// Given a string s, return the longest palindromic substring in s.
// For example:
//   Input: s = "babad"
//   Output: "bab" 
//   (Note: "aba" is also a valid answer.)
//
// Constraints:
//   • 1 <= s.length <= 1000
//   • s consists of only digits and English letters.
//
// Approach:
//   Uses "expand around center" technique.
// Testcases are timed for performance.

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testCases = [
                "babad",
                "cbbd",
                "a",
                "ac"
            ];
            
            var solution = new Solution();
            foreach(var test in testCases)
            {
                Stopwatch sw = Stopwatch.StartNew();
                string result = solution.LongestPalindrome(test);
                sw.Stop();
                Console.WriteLine($"Input: {test}  |  Result: {result}  |  Time(ms): {sw.Elapsed.TotalMilliseconds}");
            }
        }
    }
}
