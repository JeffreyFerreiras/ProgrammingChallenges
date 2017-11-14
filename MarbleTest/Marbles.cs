using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace QuickTest
{
    class Marbles
    {
        private static readonly Random _random = new Random();

        public const int RED_MARBLE = 1;
        public const int BLUE_MARBLE = 2;
        public const int GREEN_MARBLE = 3;
        public const int ORANGE_MARBLE = 4;

        static void Main(string[] args)
        {
            int red, green, blue, orange;

            red = PromptInt("Ratio red marbles?");
            green = PromptInt("Ratio green marbles?");
            blue = PromptInt("Ratio blue marbles?");
            orange = PromptInt("Ratio orange marbles?");

            int[] results = Solve(red, green, blue, orange, 1000);

            WriteOutStats(results);
        }

        private static int PromptInt(string message)
        {
            int ret = -1;

            while (true)
            {
                Console.WriteLine(message);
                string str = Console.ReadLine();
                if (Int32.TryParse(str, out ret))
                    break;
                else Console.WriteLine("{0} is valid", str);
            }

            return ret;
        }

        private static int[] Solve(int red, int green, int blue, int orange, int count)
        {
            //TODO: Return an array of integers of length [count]
            //each element in the array should contain a value from 1-4
            //the value represents a marble color (see constants above)
            //using the passed in values, you need to infer the probability of each colored marble.
            //You should then *randomly* generate [count] number of marbles based on that probability

            //(i.e) if you were passed values 10,5,5,1 for red, green, blue and orange parameters respectively
            //You should have approximately 10 red marbles for every 5 green and for every five blue marbles, and
            //there should be 10 red marbles for approximately every orange marble you get

            Contract.Ensures(Contract.Result<int[]>().Length == count);

            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                var bucket = BuildMarbleBucket(red, green, blue, orange);
                int index = _random.Next(0, bucket.Count());

                result[i] = bucket[index];
            }

            return result;
        }

        private static List<int> BuildMarbleBucket(int red, int green, int blue, int orange)
        {
            Contract.Requires(IsValidMarbleAmount(red, green, blue, orange));

            var marbleBucket = new List<int>();

            marbleBucket.AddRange(Enumerable.Repeat(RED_MARBLE, red));
            marbleBucket.AddRange(Enumerable.Repeat(GREEN_MARBLE, green));
            marbleBucket.AddRange(Enumerable.Repeat(BLUE_MARBLE, blue));
            marbleBucket.AddRange(Enumerable.Repeat(ORANGE_MARBLE, orange));

            return marbleBucket;
        }

        private static bool IsValidMarbleAmount(params int[] amounts)
        {
            foreach (var amount in amounts)
            {
                if(amount < 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void WriteOutStats(int[] results)
        {
            //TODO: output the total number of red, green, blue and orange marbles based on the array of results passed to you.
            //This array is the same array you generated in the Solve function above.

            Console.WriteLine("\nStat Results:");

            Console.WriteLine($"Red:    {results.Count(x => x == RED_MARBLE)}");
            Console.WriteLine($"Green:  {results.Count(x => x == GREEN_MARBLE)}");
            Console.WriteLine($"Blue:   {results.Count(x => x == BLUE_MARBLE)}");
            Console.WriteLine($"Orange: {results.Count(x => x == ORANGE_MARBLE)}");

            Console.ReadLine();
        }
    }
}
