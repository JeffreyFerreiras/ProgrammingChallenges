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

            string str = "Some string to reverse";
            sw.Start();
            string reversed = Reverse(str);
            sw.Stop(); // 1700 tics
            ;

            var sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            string reversed2 = ReverseWithStack(str);
            sw2.Stop(); // 3157 tics
            ;

            var sw3 = new System.Diagnostics.Stopwatch();
            sw3.Start();
            string reversed3 = ReverseWithStringBuilder(str, new StringBuilder());
            sw3.Stop(); //Second fastest. 836 tics
            ;

            var sw4 = new System.Diagnostics.Stopwatch();
            sw4.Start();
            string reversed4 = ReverseWithArry(str);
            sw4.Stop(); //Fastest! 368 tics
            ;
        }

        private static string Reverse(string str)
        {
            return Reverse(str, string.Empty);
        }
        private static string Reverse(string str, string s)
        {
            if(str.Length == 0) return s;
            return Reverse(str.Substring(0, str.Length -1), s + str.Substring(str.Length-1));
        }

        private static string ReverseWithStringBuilder(string str, StringBuilder sb)
        {
            if(str.Length == 0) return sb.ToString();
            return ReverseWithStringBuilder(str.Substring(0, str.Length - 1), sb.Append(str.Substring(str.Length - 1)));
        }
        private static string ReverseWithStack(string str)
        {
            var stack = new Stack<char>();
            foreach(var c in str)
            {
                stack.Push(c);
            }
            return new string(stack.ToArray());
        }
        private static string ReverseWithArry(string str)
        {
            char[] chararry = str.ToCharArray();
            Array.Reverse(chararry);
            return new string(chararry);
        }
    }
}
