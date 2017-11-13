using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressedString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compress("aaccccddddsssa"));
        }

        static string Compress(string value)
        {
            var result = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                int count = 1;

                while(i + count < value.Length && value[i + count-1] == value[i + count])
                {
                    count++;
                }

                i = i + count-1;

                result.Append(count.ToString() + value[i]);
            }

            return result.Length < value.Length ? result.ToString() : value;
        }
    }
}
