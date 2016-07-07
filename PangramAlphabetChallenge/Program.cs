using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static void Main(string[] args)
        {
            string pangram = "The quick brown fox jumps over the lazy dog";
            //string pangram = "The quick brown fox jumps over the lazy";

            Console.WriteLine(FindMissingLetters(pangram));
            Console.ReadLine();
        }
        static string FindMissingLetters(string line)
        {
            var lettersInAphabet = alphabet.Where(c => line.ToLower().Contains(c));
            var missingletters =  new string (alphabet.Except(lettersInAphabet).ToArray<char>());
            return lettersInAphabet.SequenceEqual(alphabet) ? "null" : missingletters;
        }
    }
}
