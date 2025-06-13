using System;
namespace TimeConversion
{
    class Program
    {
        /*
Given a time in AM/PM format, convert it to military (24-hour) time.

N
A single string containing a time in 12-hour clock format 

Output Format

Convert and print the given time in 24-hour format
        */

        static void Main(string[] args)
        {
            string time = Console.ReadLine();

            //SOLUTION - easy.

            if (DateTime.TryParse(time, out DateTime datetime))
                Console.Write(datetime.ToString("HH:mm:ss"));

            Console.Read();  
        }    
    }
}
