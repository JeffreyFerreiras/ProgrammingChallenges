using System;

namespace IsPalindrom2
{
    class Program
    {
        /*
         * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

Note: For the purpose of this problem, we define empty string as valid palindrome.

Example 1:

Input: "A man, a plan, a canal: Panama"
Output: true
Example 2:

Input: "race a car"
Output: false
 

Constraints:

s consists only of printable ASCII characters.

         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsPalindrome(string s)
        {
            // remove spaces and non alphanumeric
            // to lower
            // check if same forwards and back
            if (string.IsNullOrWhiteSpace(s)) return true;

            var sb = new System.Text.StringBuilder();

            foreach (var c in s.ToLower())
            {
                if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
                {
                    sb.Append(c);
                }
            }

            s = sb.ToString();

            if (s.Length > 1)
            {
                for (int i = 0, j = s.Length - 1; i < j; i++, j--)
                {
                    if (s[i] != s[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsPalindrome2(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;

            int left = 0, right = s.Length - 1;
            s = s.ToLower();
            while (left < right)
            {
                char leftChar = s[left];
                char rightChar = s[right];

                bool leftIsAlpha = IsAlphaNumeric(leftChar);
                bool rightIsAlpha = IsAlphaNumeric(rightChar);

                if (leftIsAlpha && rightIsAlpha)
                {
                    if (leftChar != rightChar)
                        return false;
                    else
                    {
                        left++;
                        right--;
                    }
                }
                else
                {
                    if (!leftIsAlpha) left++;
                    if (!rightIsAlpha) right--;
                }
            }

            return true;

            bool IsAlphaNumeric(char c)
            {
                return c >= 'a' && c <= 'z' || c >= '0' && c <= '9';
            }
        }
    }
}
