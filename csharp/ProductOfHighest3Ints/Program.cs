namespace ProductOfHighest3Ints
{
    /*
     * Given a list of integers, find the highest product you can get from three of the integers.
     */

    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arrayOfInts = [1, 10, -5, 1, -100];

            int product = ProductOf3(arrayOfInts);
        }

        private static int ProductOf3(int[] arrayOfInts)
        {
            if (arrayOfInts.Length < 3)
            {
                throw new ArgumentException("Cannot have less than 3 numbers");
            }

            int highest = Math.Max(arrayOfInts[0], arrayOfInts[1]);
            int lowest = Math.Min(arrayOfInts[0], arrayOfInts[1]);

            int lowestProductOf2 = arrayOfInts[0] * arrayOfInts[1];
            int highestProductOf2 = arrayOfInts[0] * arrayOfInts[1];

            int highestProductOf3 = arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];

            for (int i = 2; i < arrayOfInts.Length; i++)
            {
                int current = arrayOfInts[i];

                highestProductOf3 = Math.Max(
                    Math.Max(highestProductOf3, current * highestProductOf2),
                    current * lowestProductOf2);

                highestProductOf2 = Math.Max(
                    Math.Max(highestProductOf2, current * highest),
                    current * lowest);

                lowestProductOf2 = Math.Min(
                    Math.Min(lowestProductOf2, current * highest),
                    current * lowest);

                highest = Math.Max(highest, current);
                lowest = Math.Min(lowest, current);
            }

            return highestProductOf3;
        }
    }
}