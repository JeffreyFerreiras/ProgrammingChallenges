namespace WordBreak;

public class Solution
{
    /// <summary>
    /// Determines if the string can be segmented into dictionary words.
    /// </summary>
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var words = new HashSet<string>(wordDict);
        var maxWordLength = wordDict.Count == 0 ? 0 : wordDict.Max(word => word.Length);
        var dp = new bool[s.Length + 1];
        dp[0] = true;

        for (var end = 1; end <= s.Length; end++)
        {
            for (var start = Math.Max(0, end - maxWordLength); start < end; start++)
            {
                if (dp[start] && words.Contains(s.Substring(start, end - start)))
                {
                    dp[end] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }
}
