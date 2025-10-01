namespace LongestPalindromicSubstring
{
    public class Solution
    {
        public string LongestPalindrome(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) return "";
            int startIndex = 0, endIndex = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                int oddLength = ExpandAroundCenter(inputString, i, i);
                int evenLength = ExpandAroundCenter(inputString, i, i + 1);
                int currentPalindromeLength = Math.Max(oddLength, evenLength);
                if (currentPalindromeLength > endIndex - startIndex)
                {
                    startIndex = i - (currentPalindromeLength - 1) / 2; // calculate start index
                    endIndex = i + currentPalindromeLength / 2; // calculate end index
                }
            }
            return inputString.Substring(startIndex, endIndex - startIndex + 1);
        }

        private int ExpandAroundCenter(string inputString, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 // leftIndex is within bounds
            && rightIndex < inputString.Length // rightIndex is within bounds
            && inputString[leftIndex] == inputString[rightIndex] // characters match
            )
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1; // return the length of the palindrome
        }
    }
}
