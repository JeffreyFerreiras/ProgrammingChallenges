namespace Google_Question_PreviousDigitCount
{
    class Program
    {
        //Write a program that outputs the count then digit of a given sequence of numbers starting with one.
        // Example -> 1 11 21 1211 111221 312211

        static void Main(string[] args)
        {
            //bool pass = GetSequence(1) == "11";
            //bool pass2 = GetSequence(21) == "1211";
            //bool pass3 = GetSequence(1211) == "111221";

            bool pass1 = GetSequence_4_2020(1) == "11";
            bool pass22 = GetSequence_4_2020(21) == "1211";
            bool pass32 = GetSequence_4_2020(1211) == "111221";
        }

        static string GetSequence_4_2020(int n)
        {
            string sequence = n.ToString();

            if (sequence.Length == 1)
            {
                return "1" + n;
            }

            string ans = string.Empty;
            char c = sequence[0];
            int count = 1;

            for (int i = 1; i < sequence.Length; i++)
            {
                if(c == sequence[i])
                {
                    count++;
                }
                else
                {
                    ans += $"{count}{c}";
                    count = 1;
                    c = sequence[i];
                }
            }

            ans += $"{count}{c}";

            return ans;
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
