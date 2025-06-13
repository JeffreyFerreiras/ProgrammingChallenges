using System.Text;

namespace LongestPalindromicSubstring
{
    public class Solution_Recursive
    {
        // New overload that calls the internal method with an empty result
        public string LongestPalindrome(string s) {
            return LongestPalindrome(s, string.Empty);
        }

        public string LongestPalindrome(string s, string result) {
            StringBuilder sb = new();

            if(s.Length <= result.Length) {
                return result;
            }

            for(int i = 0; i < s.Length; i++) {
                sb.Append(s[i]);
                if(IsPalindrome(sb)) {
                    result = sb.ToString();
                }
            }

            if(s.Length > 1) {
                var palim = LongestPalindrome(s[1..], result);

                if(palim.Length > result.Length) {
                    result = palim;
                }
            }

            return result;
        }

        private bool IsPalindrome(StringBuilder sb) {
            for(int i = 0, j = sb.Length - 1; i < j; i++, j--) {
                if(sb[i] != sb[j]) {
                    return false;
                }
            }
            return true;
        }
    }
}
