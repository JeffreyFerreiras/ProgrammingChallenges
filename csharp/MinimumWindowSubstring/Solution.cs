namespace MinimumWindowSubstring;

public class Solution
{
    /// <summary>
    /// Returns the smallest substring of s that contains all characters of t.
    /// Optimized sliding window approach.
    /// </summary>
    public string MinWindow(string source, string substring)
    {
        if (
            string.IsNullOrEmpty(source)
            || string.IsNullOrEmpty(substring)
            || source.Length < substring.Length
        )
            return string.Empty;

        var substringCharCounts = substring
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());

        // Sliding window with frequency tracking
        var windowCounts = new Dictionary<char, int>();
        int left = 0;
        int minLen = int.MaxValue;
        int minStart = 0;
        int matched = 0; // Count of characters that meet the required frequency

        for (int right = 0; right < source.Length; right++)
        {
            // Expand window: add character from right
            char rightChar = source[right];
            windowCounts[rightChar] = windowCounts.GetValueOrDefault(rightChar) + 1;

            // Check if the window character is in substring and meets the required frequency
            if (
                substringCharCounts.TryGetValue(rightChar, out int value)
                && windowCounts[rightChar] == value
            )
            {
                matched++; // One more character requirement met
            }

            // Contract window: try to minimize while valid
            while (matched == substringCharCounts.Count)
            {
                // Update minimum window
                if ((right - left + 1) < minLen)
                {
                    minLen = right - left + 1;
                    minStart = left;
                }

                // Remove character from left
                char leftChar = source[left];
                if (
                    substringCharCounts.TryGetValue(leftChar, out int occurrenceCount)
                    && windowCounts[leftChar] == occurrenceCount // Before decrementing, it previously met the character and frequency requirement, so now it won't after decrementing
                )
                {
                    matched--; // One character requirement no longer met, its okay to not match the window anymore because minLen and minStart have already been updated
                }

                windowCounts[leftChar]--; // Decrease count of left character
                left++; // decrease window size from the left
            }
        }

        return minLen == int.MaxValue ? string.Empty : source[minStart..(minStart + minLen)];
    }

    /// <summary>
    /// Brute force approach: Check all possible substrings.
    /// Time Complexity: O(n^2 * m) where n = s.Length, m = t.Length
    /// </summary>
    public string MinWindow_BruteForce(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            return string.Empty;

        string minWindow = string.Empty;
        int minLength = int.MaxValue;

        // Try all possible substrings
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + t.Length - 1; j < s.Length; j++)
            {
                string substring = s.Substring(i, j - i + 1);
                if (ContainsAllCharacters(substring, t))
                {
                    if (substring.Length < minLength)
                    {
                        minLength = substring.Length;
                        minWindow = substring;
                    }
                }
            }
        }

        return minWindow;
    }

    private bool ContainsAllCharacters(string s, string t)
    {
        var tCounts = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (tCounts.ContainsKey(c))
                tCounts[c]++;
            else
                tCounts[c] = 1;
        }

        var sCounts = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (sCounts.ContainsKey(c))
                sCounts[c]++;
            else
                sCounts[c] = 1;
        }

        foreach (var kvp in tCounts)
        {
            if (!sCounts.ContainsKey(kvp.Key) || sCounts[kvp.Key] < kvp.Value)
                return false;
        }

        return true;
    }
}
