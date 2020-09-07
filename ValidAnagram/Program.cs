using System;

namespace ValidAnagram
{
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
            Console.WriteLine("Hello World!");

            var r = IsAnagram("abc", "cba"); //true
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
    }
}
