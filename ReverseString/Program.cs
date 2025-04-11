using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseString
{
    class Program
    {
        /*
        Reverse a string.
        */
        static void Main(string[] args)
        {
            var sw = new System.Diagnostics.Stopwatch();

            string toReverse = "Some string to reverse";

            sw.Start();
            string reversed = Reverse(toReverse);
            sw.Stop(); // 1700 tics slow
            ;

            var sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            string reversed2 = ReverseWithStack(toReverse);
            sw2.Stop(); // 3157 tics slowest
            ;

            var sw3 = new System.Diagnostics.Stopwatch();
            sw3.Start();
            string reversed3 = ReverseWithStringBuilder(toReverse, new StringBuilder());
            sw3.Stop(); //Second fastest. 836 tics
            ;

            var sw4 = new System.Diagnostics.Stopwatch();
            sw4.Start();
            string reversed4 = ReverseWithArry(toReverse);
            sw4.Stop(); //Fastest! 368 tics
            ;

            var sw5 = new System.Diagnostics.Stopwatch();
            sw4.Start();
            string reversed5 = ClassicReverse(toReverse);
            sw4.Stop(); //Fastest! 
            ;
        }

        private static string ClassicReverse(string s)
        {
            var sb = new StringBuilder(s.Length);
            
            for (int i = s.Length-1; i >= 0; i--){
                sb.Append(s[i]);
            }
            
            return sb.ToString();
        }

        private static string Reverse(string toReverse)
        {
            return Reverse(toReverse, string.Empty);
        }

        private static string Reverse(string toReverse, string s)
        {
            if(toReverse.Length == 0) return s;
            return Reverse(toReverse.Substring(0, toReverse.Length -1), s + toReverse.Substring(toReverse.Length-1));
        }

        private static string ReverseWithStringBuilder(string toReverse, StringBuilder sb)
        {
            if(toReverse.Length == 0) return sb.ToString();
            return ReverseWithStringBuilder(toReverse.Substring(0, toReverse.Length - 1), sb.Append(toReverse.Substring(toReverse.Length - 1)));
        }

        private static string ReverseWithStack(string strtoReverse)
        {
            var stack = new Stack<char>();
            foreach(var c in strtoReverse)
            {
                stack.Push(c);
            }
            return new string([.. stack]);
        }

        private static string ReverseWithArry(string toReverse)
        {
            char[] chararry = [.. toReverse];
            Array.Reverse(chararry);
            return new string(chararry);
        }
    }
}
