public class Solution_Memoization
{
    private Dictionary<int, int> memo = new();

    public int NumDecodings(string s)
    {
        return NumDecodings(s, 0); // 12
    }

    public int NumDecodings(string s, int index)
    {
        if (memo.ContainsKey(index))
        {
            return memo[index];
        }

        if (index == s.Length)
        {  // end of string is reached
            return 1;
        }

        if (s[index] == '0')
        {
            return 0;
        }

        if (index == s.Length - 1)
        {
            return 1;
        }

        int ans = NumDecodings(s, index + 1);

        if (int.Parse(s.Substring(index, 2)) <= 26)
        {
            ans += NumDecodings(s, index + 2);
        }

        memo[index] = ans;
        return ans;
    }
}
