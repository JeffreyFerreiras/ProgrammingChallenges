public class Solution_Memoization
{
    // Dictionary to store computed results for subproblems (memoization)
    private Dictionary<int, int> memo = [];

    public int NumDecodings(string s)
    {
        // Start decoding from index 0
        return NumDecodings(s, 0); // 12
    }

    public int NumDecodings(string s, int index)
    {
        // If result already computed for this index, return it
        if (memo.ContainsKey(index))
        {
            return memo[index];
        }

        // If the end of the string is reached, this path is valid
        if (index == s.Length)
        {
            return 1;
        }

        // '0' cannot be decoded by itself; hence, invalid path
        if (s[index] == '0')
        {
            return 0;
        }

        // If only one character is left, it forms a valid decoding on its own
        if (index == s.Length - 1)
        {
            return 1;
        }

        // Decode assuming the current digit is a valid single-digit number
        int ans = NumDecodings(s, index + 1);

        // Check if the two-digit number formed is <= 26 to be a valid decoding
        if (int.Parse(s.Substring(index, 2)) <= 26)
        {
            // Add the decoding ways assuming the next two digits form a valid number
            ans += NumDecodings(s, index + 2);
        }

        // Cache the computed result for the current index
        memo[index] = ans;
        return ans;
    }
}
