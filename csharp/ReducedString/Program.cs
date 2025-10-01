using System;
using System.Text;

namespace ReducedString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "aaabccddd";
            string result = GetReducedString(input, string.Empty);

            Console.Write(result.Length > 0 ? result : "Empty String");
            Console.ReadLine();
        }
        static string GetReducedString(string reduced, string original)
        {
            if (original == reduced)
                return original;

            string input = String.Copy(reduced);
            StringBuilder sb = new();

            while (input.Length >= 1)
            {
                if (input.Length == 1 || input[0] != input[1])
                {
                    sb.Append(input[0]);
                    input = input.Substring(1);
                }
                else
                    input = input.Substring(2);
            }
            return GetReducedString(sb.ToString(), reduced);
        }
    }
}
