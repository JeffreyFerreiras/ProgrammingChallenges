namespace LongestRepeatingCharacterReplacement;

public class Solution
{
    /// <summary>
    /// Computes the length of the longest repeating character substring after at most k replacements.
    /// TODO: Maintain a sliding window tracking the highest frequency within the window.
    /// </summary>
    public int CharacterReplacement(string s, int k)
    {
        if (s?.Length <= 1)
            return s?.Length ?? 0;

        int maxLength = 0;
        for (int i = 0; i < s!.Length; i++)
        {
            int rep = k;
            int max = 1;

            for (int j = 0; j < s.Length; j++)
            {
                if (j == i)
                    continue;
                if (s[j] == s[i])
                {
                    max++;
                }
                else if (rep > 0)
                {
                    rep--;
                    max++;
                }
                else
                    break;
            }

            maxLength = Math.Max(maxLength, max);
            if (max > (s.Length - i))
            {
                break;
            }
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
