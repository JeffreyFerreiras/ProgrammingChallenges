namespace MinimumWindowSubstring;

public class Solution
{
    /// <summary>
    /// Returns the smallest substring of s that contains all characters of t.
    /// Optimized sliding window approach.
    /// </summary>
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
            return string.Empty;

        // map t with character counts
        var sCounts = new Dictionary<char, List<int>>();

        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (sCounts.ContainsKey(c))
                sCounts[c].Add(i);
            else
                sCounts[c] = [i];
        }

        var window = string.Empty;
        //find all posible windows
        while (t.All(target => sCounts.ContainsKey(target) && sCounts[target].Count > 0))
        {
            int left = s.Length;
            int right = -1;

            foreach (var c in t)
            {
                if (!sCounts.ContainsKey(c))
                    break;

                var maxIndex = sCounts[c].Max();

                sCounts[c].Remove(maxIndex);

                if (sCounts[c].Count == 0)
                    sCounts.Remove(c);

                left = Math.Min(left, maxIndex);
                right = Math.Max(right, maxIndex);
            }
            var currentWindow = s[left..(right + 1)];
            if (window == string.Empty || currentWindow.Length < window.Length)
                window = currentWindow;
        }

        return window;
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
