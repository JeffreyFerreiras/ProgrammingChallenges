namespace QuickTest
{
    class Marbles
    {
        private static readonly Random mRandom = new Random();
        private static readonly object mLock = new object();
        private static int[] marbleValues = { RED_MARBLE, GREEN_MARBLE, BLUE_MARBLE, ORANGE_MARBLE };

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

        public static int PromptInt(string message)
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
            // TOOD: Return an array of integers of length [count]
            // each element in the array should contain a value from 1 to 4
            // the value represents a marble color (see constants above)
            // using the passed in values, you need to infer the probablility of each colored marble.
            // You should then *randomly* generate [count] number of marbles based on that probability

            // (i.e. if you were passed the values 10, 5, 5, 1 for the red, green, blue and orange parameters respectively
            // you should have approximately 10 red marbles for every 5 green and for every five blue marbles, and
            // there should 10 red marbles for approximately every orange marble you get)

            var marbleBucket = GetRandomMarbleTable(GetProbabilityTable(red, green, blue, orange));

            var result = new int[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = marbleBucket[GetRandom(0, marbleBucket.Length)];
            }

            return result;
        }

        private static float[] GetProbabilityTable(int red, int green, int blue, int orange)
        {
            float totalRatio = (red + green + blue + orange);
            float redProbability = red / totalRatio;
            float greenProbability = green / totalRatio;
            float blueProbability = blue / totalRatio;
            float orangeProbability = orange / totalRatio;

            return new float[] { redProbability, greenProbability, blueProbability, orangeProbability };
        }

        static int GetRandom(int min, int max)
        {
            lock (mLock)
            {
                return mRandom.Next(min, max);
            }
        }

        static int[] GetRandomMarbleTable(float[] probabilities)
        {
            const int size = 100; //Control the precision here, if you need another level of precision then the number can be rased X^2 every time, but remaining a constant in the code.
            var table = new int[size];

            int pos = 0;

            for (int i = 0; i < marbleValues.Length; i++)
            {
                int count = (int)Math.Round(size * probabilities[i]);
                AddMarbles(table, marbleValues[i], pos, count);
                pos += count;
            }
            
            return table;
        }

        static void AddMarbles(int [] marbles, int marbleValue, int start, int end)
        {
            for (int i = start; i < (start + end); i++)
            {
                marbles[i] = marbleValue;
            }
        }
        
        private static void WriteOutStats(int[] results)
        {
            // TODO: output the total number of red, green, blue and orange marbles based on the array of results passed into you.
            // This array is the same array you generated in the Solve function above.

            Console.WriteLine("\nResults:");

            int redTotal=0;
            int greenTotal=0;
            int blueTotal=0;
            int orangeTotal=0;

            for (int i = 0; i < results.Length; i++)
            {
                switch (results[i])
                {
                    case RED_MARBLE:
                        redTotal++;
                        break;
                    case GREEN_MARBLE:
                        greenTotal++;
                        break;
                    case BLUE_MARBLE:
                        blueTotal++;
                        break;
                    case ORANGE_MARBLE:
                        orangeTotal++;
                        break;
                    default:
                        continue;
                }
            }

            Console.WriteLine($"Red:{redTotal}");
            Console.WriteLine($"Green:{greenTotal}");
            Console.WriteLine($"Blue:{blueTotal}");
            Console.WriteLine($"Orange:{orangeTotal}");

            Console.ReadLine();
        }
    }
}
