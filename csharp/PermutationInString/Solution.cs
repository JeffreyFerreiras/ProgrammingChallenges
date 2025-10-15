namespace PermutationInString;

public class Solution
{
    /// <summary>
    /// Determines whether s2 contains a permutation of s1 using a sliding window.
    /// TODO: Track frequency balance between the current window and s1.
    /// </summary>
    public bool CheckInclusion(string s1, string s2)
    {
        // declare the left and right plus dictionary
        var charCount = new Dictionary<char, int>();

        // make the permutation string a dictionary of character count
        foreach (char c in s1)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        int left = 0, right = s1.Length - 1;

        while (right < s2.Length)
        {
            string window = s2[left..(right + 1)];
            var windowCharCount = new Dictionary<char, int>(charCount);
            foreach (char c in window)
            {
                if (windowCharCount.ContainsKey(c))
                {
                    windowCharCount[c]--;
                }
            }

            if (windowCharCount.Values.All(v => v == 0))
            {
                return true;
            }

            left++;
            right++;
        }
        return false;
    }

    //check inclusion sorted
    public bool CheckInclusion_Sorted(string s1, string s2)
    {
        // sort the string
        if (s1.Length > s2.Length) return false;
        char[] s1Array = s1.ToCharArray();
        Array.Sort(s1Array);
        s1 = new string(s1Array);
        int left = 0, right = s1.Length - 1;

        while (right < s2.Length)
        {
            var windowArray = s2[left..(right + 1)].ToCharArray();
            Array.Sort(windowArray);

            if (new string(windowArray) == s1)
            {
                return true;
            }

            left++;
            right++;
        }
        return false;
    }
    
    public bool CheckInclusion_Optimized(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        // Use dictionary instead of array to handle all characters, not just lowercase
        var s1Count = new Dictionary<char, int>();
        var s2Count = new Dictionary<char, int>();

        // Initialize s1 character counts
        foreach (char c in s1)
        {
            s1Count[c] = s1Count.GetValueOrDefault(c) + 1;
        }

        // Initialize first window in s2
        for (int i = 0; i < s1.Length; i++)
        {
            s2Count[s2[i]] = s2Count.GetValueOrDefault(s2[i]) + 1;
        }

        // Check if first window matches
        if (DictionariesMatch(s1Count, s2Count)) return true;

        // Slide the window
        for (int i = s1.Length; i < s2.Length; i++)
        {
            // Add new character to window
            char charIn = s2[i];
            s2Count[charIn] = s2Count.GetValueOrDefault(charIn) + 1;

            // Remove old character from window
            char charOut = s2[i - s1.Length];
            s2Count[charOut]--;
            if (s2Count[charOut] == 0)
            {
                s2Count.Remove(charOut);
            }

            // Check if current window matches
            if (DictionariesMatch(s1Count, s2Count)) return true;
        }

        return false;
    }

    private bool DictionariesMatch(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        if (dict1.Count != dict2.Count) return false;
        
        foreach (var kvp in dict1)
        {
            if (!dict2.TryGetValue(kvp.Key, out int value) || value != kvp.Value)
            {
                return false;
            }
        }
        
        return true;
    }
}
