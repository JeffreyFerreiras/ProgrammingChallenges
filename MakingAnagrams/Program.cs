namespace MakingAnagrams
{
    /*
     * Given two strings, a and b, that may or may not be of the same length,
     * determine the minimum number of character deletions required to make a and b anagrams.
     * Any characters can be deleted from either of the strings.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string a = "imkhnpqnhlvaxlmrsskbyyrhwfvgteubrelgubvdmrdmesfxkpykprunzpustowmvhupkqsyjxmnptkcilmzcinbzjwvxshubeln";
            string b = "wfnfdassvfugqjfuruwrdumdmvxpbjcxorettxmpcivurcolxmeagsdundjronoehtyaskpwumqmpgzmtdmbvsykxhblxspgnpgfzydukvizbhlwmaajuytrhxeepvmcltjmroibjsdkbqjnqjwmhsfopjvehhiuctgthrxqjaclqnyjwxxfpdueorkvaspdnywupvmy";

            int deleteCount = GetExcludedCount(a, b);
            //expect 102
        }

        static int GetExcludedCount(string first, string second)
        {
            int[] matrixSource = GetCountMatrix(first);
            int[] matrixTarget = GetCountMatrix(second);

            int total = 0;

            for(int i = 0; i < matrixSource.Length; i++)
            {
                total += Math.Abs(matrixSource[i] - matrixTarget[i]);
            }

            return total;
        }

        private static int[] GetCountMatrix(string source)
        {
            int[] matrix = new int[26];

            for(int i = 0; i < source.Length; i++)
            {
                if(char.IsLetter(source[i]))
                {
                    matrix[source[i] - 97]++;
                }
            }

            return matrix;
        }
    }
}
