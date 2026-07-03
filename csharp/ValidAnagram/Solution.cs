namespace ValidAnagram
{
    /// <summary>
    /// LeetCode: Valid Anagram
    /// 
    /// Given two strings s and t, write a function to determine if t is an anagram of s.
    ///
    /// Example 1:
    /// Input: s = "anagram", t = "nagaram"
    /// Output: true
    ///
    /// Example 2:
    /// Input: s = "rat", t = "car"
    /// Output: false
    ///
    /// Note:
    /// You may assume the string contains only lowercase alphabets.
    ///
    /// Follow up:
    /// What if the inputs contain unicode characters? How would you adapt your solution to such case?
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Determines whether the second string is an anagram of the first string
        /// </summary>
        /// <param name="s">Source string</param>
        /// <param name="t">Target string</param>
        /// <returns>True if t is an anagram of s, otherwise false</returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            int[] counts = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a']++;
                counts[t[i] - 'a']--;
            }

            foreach (int count in counts)
            {
                if (count != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
