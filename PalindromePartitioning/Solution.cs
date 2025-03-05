public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        List<IList<string>> result = [];
        Par(new List<string>(s.Length), s);
        return result;

        void Par(List<string> parts, string val)
        {
            if (val == string.Empty)
            { // we are reducing the string val
                result.Add([.. parts]);
                return;
            }

            for (int i = 0; i < val.Length; i++)
            {
                string part = val[..(i + 1)]; // take chars till current index
                if (!IsPalim(part)) continue; // if not a palindrome, skip
                parts.Add(part); //add the confirmed palim to the list
                Par(parts, val[(i + 1)..]); // do the subproblem, from i to end
                parts.RemoveAt(parts.Count - 1); //remove the last tried part
                                                 // so we can fully try the next iteration
            }
        }

        static bool IsPalim(string s)
        {
            int low = 0, high = s.Length - 1;
            while (low < high)
            {
                if (s[low++] != s[high--]) return false; //increment indexes after use
            }
            return true; //it is!
        }
    }

    // Optimized method using dynamic programming
    public IList<IList<string>> PartitionOptimized(string s)
    {
        int n = s.Length;
        List<IList<string>> result = [];

        // isPalindrome[i][j] = true if substring s[i..j] is a palindrome
        bool[,] isPalindrome = new bool[n, n];

        // Precompute all palindromes in the string
        // Single characters are always palindromes
        for (int i = 0; i < n; i++)
            isPalindrome[i, i] = true;

        // Check palindromes of length 2
        for (int i = 0; i < n - 1; i++)
            isPalindrome[i, i + 1] = s[i] == s[i + 1];

        // Check palindromes of length 3 or more
        for (int len = 3; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                // A substring is a palindrome if first and last chars match,
                // and the inner substring is also a palindrome
                isPalindrome[i, j] = (s[i] == s[j]) && isPalindrome[i + 1, j - 1];
            }
        }

        // Use backtracking with our precomputed palindrome information
        BacktrackWithDP(s, 0, isPalindrome, [], result);
        return result;
    }

    private void BacktrackWithDP(string s, int start, bool[,] isPalindrome, List<string> current, List<IList<string>> result)
    {
        // If we've processed the entire string, we have a valid partition
        if (start >= s.Length)
        {
            result.Add([.. current]);
            return;
        }

        // Try all possible end positions for the current substring
        for (int end = start; end < s.Length; end++)
        {
            // If s[start..end] is a palindrome, add it to our current partition
            if (isPalindrome[start, end])
            {
                current.Add(s.Substring(start, end - start + 1));
                BacktrackWithDP(s, end + 1, isPalindrome, current, result);
                current.RemoveAt(current.Count - 1); // Backtrack
            }
        }
    }
}