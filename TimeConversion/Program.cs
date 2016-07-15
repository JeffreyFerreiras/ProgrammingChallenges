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
        /**
Given a time in AM/PM format, convert it to military (-hour) time.

Note: Midnight is  on a -hour clock, and  on a -hour clock. Noon is  on a -hour clock, and  on a -hour clock.

Input Format


A single string containing a time in -hour clock format (i.e.:  or ), where .

Output Format

Convert and print the given time in -hour format, where .
        */

        static void Main(string[] args)
        {
            string time = Console.ReadLine();

            //SOLUTION

            var datetime = new DateTime();
            if(DateTime.TryParse(time, out datetime))
                Console.Write(datetime.ToString("HH:mm:ss"));
            Console.Read();  
        }    
    }
}
