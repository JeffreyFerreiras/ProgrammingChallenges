using System.Runtime.CompilerServices;

namespace LongestRepeatingCharacterReplacement;

public class Solution
{
    /// <summary>
    /// Computes the length of the longest repeating character substring after at most k replacements.
    /// Uses a sliding window tracking the highest frequency within the window.
    /// </summary>
    public int CharacterReplacement(string s, int k)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int maxLength = 0;
        int highestCharacterCount = 0;
        int left = 0;
        var charCount = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++)
        {
            char currentChar = s[right];

            // Add current character to window
            if (!charCount.ContainsKey(currentChar))
               charCount[currentChar] = 0;

            charCount[currentChar]++;

            // Update max frequency in current window
            highestCharacterCount = Math.Max(highestCharacterCount, charCount[currentChar]);

            // Calculate replacements needed
            int windowSize = right - left + 1;
            int replacements = windowSize - highestCharacterCount;

            // If we need more than k replacements, shrink window from left
            if (replacements > k)
            {
                charCount[s[left]]--;
                left++;
            }

            // Update max length
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    public int CharacterReplacement_BruteForce(string s, int k)
    {
        if (string.IsNullOrEmpty(s) || k < 0)
            return 0;

        int maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var charCount = new int[26];
            int maxFreq = 0;

            for (int j = i; j < s.Length; j++)
            {
                charCount[s[j] - 'A']++;
                maxFreq = Math.Max(maxFreq, charCount[s[j] - 'A']);

                int windowSize = j - i + 1;
                int replacements = windowSize - maxFreq;

                if (replacements <= k)
                {
                    maxLength = Math.Max(maxLength, windowSize);
                }
                else
                {
                    break; // No point checking further in this starting position
                }
            }
        }

        return maxLength;
    }
}
