using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
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

            var datetime = new DateTime();
            if(DateTime.TryParse(time, out datetime))
                Console.Write(datetime.ToString("HH:mm:ss"));
            Console.Read();  
        }    
    }
}
