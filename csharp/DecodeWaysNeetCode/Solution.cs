namespace DecodeWaysNeetCode;

public class Solution
{
    /// <summary>
    /// Calculates the number of ways to decode the numeric string into letters.
    /// </summary>
    public int NumDecodings(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var twoBack = 1;
        var oneBack = s[0] == '0' ? 0 : 1;

        for (var i = 1; i < s.Length; i++)
        {
            var current = 0;

            if (s[i] != '0')
            {
                current += oneBack;
            }

            var twoDigit = (s[i - 1] - '0') * 10 + (s[i] - '0');
            if (twoDigit >= 10 && twoDigit <= 26)
            {
                current += twoBack;
            }

            twoBack = oneBack;
            oneBack = current;
        }

        return oneBack;
    }
}
