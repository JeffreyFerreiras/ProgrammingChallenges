using System;

namespace Google_Question_PreviousDigitCount
{
    class Program
    {
        //Write a program that outputs the count then digit of a given sequence of numbers starting with one.
        // Example -> 1 11 21 1211 111221 312211

        static void Main(string[] args)
        {
            bool pass = GetSequence(1) == "11";
            bool pass2 = GetSequence(21) == "1211";
            bool pass3 = GetSequence(1211) == "111221";
        }

        static string GetSequence(int n)
        {
            string input = n.ToString();
            string result = string.Empty;

            if(input.Length == 1)
            {
                return 1 + input;
            }

            char prev = input[0];

            int count = 1;

            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] != prev)
                {
                    result += count.ToString() + prev.ToString();
                    count=1;
                }
                else
                {
                    count++;
                }

                prev = input[i];             
            }

            return result + count.ToString() + prev.ToString();
        }
    }
}
