namespace Palindrome
{
    class Program
    {
        /* Check if a string is a Palindrome */

        static void Main(string[] args)
        {
            //TEST CODE
            bool result1 = IsPalindrome("Malayalam");
            bool result2 = IsPalindrome("Racecar");
            bool result3 = IsPalindrome("Not a palindrome");
            bool result4 = IsPalindrome("");
            bool result5 = IsPalindrome(null);
            //END TEST CODE
        }

        static bool IsPalindrome(string phrase) //SOLUTION - O(n)
        {
            if(string.IsNullOrWhiteSpace(phrase)) return false;

            for(int i = 0; i < phrase.Length / 2; i++)
            {
                char left = (char)(phrase[i] | ' ');                        //OR | bitwise operator used to always compare lower case.
                char right = (char)(phrase[phrase.Length - 1 - i] | ' ');

                if(left != right) return false;
            }

            return true;
        }
    }
}
