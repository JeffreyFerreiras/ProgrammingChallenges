using System.Collections.Generic;

namespace RansomNote
{
    class Program
    {
        /* The words in his note are case-sensitive and he must use whole words available in the magazine,
         * meaning he cannot use substrings or concatenation to create the words he needs.
         * 
         * Given the words in the magazine and the words in the ransom note,
         * print Yes if he can replicate his ransom note exactly using whole words from the magazine; otherwise, print No.
         */


        static void Main(string[] args)
        {
            string[] magazine = "two times three is not four".Split(' ');
            string[] ransom = "two times two is four".Split(' ');

            string canReplicate = CanReplicateRansom(magazine, ransom);

            magazine = "give me one grand today night".Split(' ');
            ransom = "give one grand today".Split(' ');

            string canReplicate2 = CanReplicateRansom(magazine, ransom);
        }

        private static string CanReplicateRansom(string[] magazine, string[] ransom) //Uses extra space but is much faster...
        {
            var dict = new Dictionary<string, int>();

            AppendToDict(dict, magazine);

            foreach(var word in ransom)
            {
                if(dict.ContainsKey(word))
                {
                    if(dict[word] == 0)
                    {
                        return "No";
                    }

                    dict[word]--;
                }
            }

            return "Yes";
        }

        private static void AppendToDict(Dictionary<string, int> allWords, string[] words)
        {
            for(int i = 0; i < words.Length; i++)
            {
                if(allWords.ContainsKey(words[i]))
                {
                    allWords[words[i]]++;
                }
                else
                {
                    allWords.Add(words[i], 1);
                }
            }
        }

        //Brute force solution.
        private static string CanReplicateRansomBruteForce(string[] magazine, string[] ransom)
        {
            int ransomWordCount = ransom.Length;

            foreach(string word in ransom)
            {
                for(int i = 0; i < magazine.Length; i++)
                {
                    if(magazine[i] == word)
                    {
                        magazine[i] = null;
                        ransomWordCount--;

                        if(ransomWordCount == 0)
                        {
                            return "Yes";
                        }

                        break;
                    }
                }
            }

            return "No";
        }
    }
}
