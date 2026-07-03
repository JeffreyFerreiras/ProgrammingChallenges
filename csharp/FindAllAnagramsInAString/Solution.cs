namespace FindAllAnagramsInAString;

public class Solution
{
    /// <summary>
    /// Returns the starting indices of all anagrams of p within s.
    /// </summary>
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();

        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p) || p.Length > s.Length)
        {
            return result;
        }

        var window = new int[26];
        var target = new int[26];

        for (var i = 0; i < p.Length; i++)
        {
            target[p[i] - 'a']++;
            window[s[i] - 'a']++;
        }

        if (Matches(window, target))
        {
            result.Add(0);
        }

        for (var right = p.Length; right < s.Length; right++)
        {
            window[s[right] - 'a']++;
            window[s[right - p.Length] - 'a']--;

            if (Matches(window, target))
            {
                result.Add(right - p.Length + 1);
            }
        }

        return result;
    }

    private static bool Matches(int[] left, int[] right)
    {
        for (var i = 0; i < left.Length; i++)
        {
            if (left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }
}
