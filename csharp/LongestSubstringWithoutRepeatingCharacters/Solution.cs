using System.Diagnostics;

namespace LongestSubstringWithoutRepeatingCharacters;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s?.Length < 2)
        {
            return s?.Length ?? 0;
        }

        int maxLength = 0;
        const short MaxPossible = 26;

        HashSet<char> charSet = new(MaxPossible);

        ushort start = 0,
            end = 0;

        while (end < s.Length)
        {
            if (charSet.Contains(s[end]))
            {
                maxLength = Math.Max(maxLength, charSet.Count);
                start += 1;
                end = start;
                charSet.Clear();
            }
            charSet.Add(s[end]);
            end += 1;
        }

        return Math.Max(maxLength, charSet.Count);
    }

    /// <summary>
    /// Optimized version using sliding window technique. Only removes characters when duplicates are found one at a time instead of clearing the entire set.
    /// </summary>
    /// <param name="s">Input string</param>
    /// <returns>Length of the longest substring without repeating characters</returns>
    public int LengthOfLongestSubstring_Optimized(string s)
    {
        if (s?.Length < 2)
            return s?.Length ?? 0;
        
        int maxLength = 0;
        const short MaxPossible = 26;

        HashSet<char> charSet = new(MaxPossible);
        int left = 0, right = 0;
        while (right < s.Length)
        {
            while (charSet.Contains(s[right]))
            {
                charSet.Remove(s[left]);
                left++;
            }
            charSet.Add(s[right]);
            right++;
            maxLength = Math.Max(maxLength, right - left);
        }
        return maxLength;
    }

    public int LengthOfLongestSubstring_BruteForce(string s)
    {
        if (s?.Length < 2)
        {
            return s?.Length ?? 0;
        }

        int maxLength = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            var seen = new HashSet<char>();
            for (int j = i; j < s.Length; j++)
            {
                if (seen.Contains(s[j]))
                    break;
                seen.Add(s[j]);
            }
            maxLength = Math.Max(maxLength, seen.Count);
        }
        
        return maxLength;
    }
}
