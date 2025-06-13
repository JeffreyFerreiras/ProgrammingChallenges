using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ValidAnagram;

//Valid Anagram
/**
LeetCode: Easy
Given two strings s and t , write a function to determine if t is an anagram of s.

Example 1:

Input: s = "anagram", t = "nagaram"
Output: true
Example 2:

Input: s = "rat", t = "car"
Output: false
Note:
You may assume the string contains only lowercase alphabets.

Follow up:
What if the inputs contain unicode characters? How would you adapt your solution to such case?

 */
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Valid Anagram - LeetCode Problem");
        Console.WriteLine("=================================\n");
        Console.WriteLine("Given two strings s and t, write a function to determine if t is an anagram of s.\n");

        // Test cases
        var testCases = new[]
        {
            (s: "anagram", t: "nagaram", expected: true),
            (s: "rat", t: "car", expected: false),
            (s: "abc", t: "cba", expected: true),
        };

        foreach (var test in testCases)
        {
            RunTest("IsAnagram", test.s, test.t, test.expected, (s, t) => IsAnagram(s, t));
            RunTest("IsAnagram2", test.s, test.t, test.expected, (s, t) => IsAnagram2(s, t));
            Console.WriteLine();
        }
    }

    static void RunTest(string methodName, string s, string t, bool expected, Func<string, string, bool> method)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        bool result = method(s, t);
        stopwatch.Stop();

        Console.WriteLine($"Method: {methodName}");
        Console.WriteLine($"Input: s = \"{s}\", t = \"{t}\"");
        Console.WriteLine($"Expected: `{expected}`, Result: `{result}`");
        Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedMilliseconds} ms)");
    }

    static bool IsAnagram(string source, string target)
    {
        if (source.Length != target.Length) return false;

        int[] sourceMap = new int[26];
        int[] targetMap = new int[26];

        for (int i = 0; i < source.Length; i++)
        {
            sourceMap[source[i] - 'a']++;
        }

        for (int i = 0; i < target.Length; i++)
        {
            targetMap[target[i] - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (targetMap[i] != sourceMap[i])
            {
                return false;
            }
        }

        return true;
    }

    static bool IsAnagram2(string s, string t){
        if (s.Length != t.Length) return false;

        Dictionary<char, int> counter = [];
        foreach (char c in s)
        {
            if(!counter.TryAdd(c, 1))
                counter[c] += 1;
        }

        foreach (char c in t)
        {
            if (counter.TryGetValue(c, out int value) && value > 0)
            {
                counter[c] = --value; //use up a letter
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
