using System;
using System.Linq;

namespace PangramAlphabetChallenge
{
    /*Programming Challenge Description:
 The sentence "A quick brown fox jumps over the lazy dog" contains every single letter in the English alphabet. Such sentences are called pangrams. You are to write a program which takes a sentence and outputs all the letters it is missing which prevent it from being a pangram. You should ignore the case of the letters in the input sentence, and your output should be all lowercase letters in alphabetical order. You should also ignore all non US-ASCII characters. In case the input sentence is already a pangram, output the string NULL.
 Input:
 Your program should read lines of text from standard input. Each line contains a sentence.
 Output:
 For each line of input, print to standard output all the letters it is missing, in lowercase, sorted in alphabetical order. If there are no missing letters, print the string NULL.*/
    class Program
    {
        static readonly char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static void Main(string[] args)
        {
            //TEST CODE
            string pangram = "The quick brown fox jumps over the lazy dog";
            string pangram2 = "The quick brown fox jumps over the lzy";

            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"{nameof(FindMissingLetters)}: {FindMissingLetters(pangram)}");
            Console.WriteLine($"{nameof(FindMissingLetters)}: {FindMissingLetters(pangram2)}");
            stopWatch.Stop();
            Console.WriteLine($"Ticks: {stopWatch.ElapsedTicks.ToString("N")}");
            Console.WriteLine();
            stopWatch.Reset();

            stopWatch.Start();
            Console.WriteLine($"{nameof(MissingLetters)}: {MissingLetters(pangram)}");
            Console.WriteLine($"{nameof(MissingLetters)}: {MissingLetters(pangram2)}");
            stopWatch.Stop();
            Console.WriteLine($"Ticks: {stopWatch.ElapsedTicks.ToString("N")}");
            Console.WriteLine();

            Console.ReadLine();
            //END TEST CODE
        }


        static string MissingLetters(string line) // SOLUTION - O(n)
        {
            if (line == null) return "NULL";

            int[] table = new int[26]; //represents english alphabet.
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    int letterIndex = char.ToLower(line[i]) - 'a';
                    table[letterIndex]++;
                }
            }

            string missing = string.Empty;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] < 1)
                    missing += Convert.ToChar(i + 'a');
            }

            return missing.Length == 0 ? "NULL" : missing;
        }

        static string FindMissingLetters(string line)
        {   //(OLD answer from years ago... noob answer here... haha noob.) 
            // SOLUTION - Brought out LINQ for an efficitent yet easy to understand solution.
            if (string.IsNullOrEmpty(line))
                throw new NotImplementedException("pangram input cannot be null");

            line = line.ToLower();
            var lettersInAphabet = alphabet.Where(c => line.Contains(c));
            string missingletters = new([.. alphabet.Except(lettersInAphabet)]);
            return lettersInAphabet.SequenceEqual(alphabet) ? "null" : missingletters;
        }
    }
}
