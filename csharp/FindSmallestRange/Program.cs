namespace FindSmallestRange
{
    /*

    You have k lists of sorted integers. Find the smallest range that includes at least one number from each of the k lists.

    For example,
    List 1: [4, 10, 15, 24, 26]
    List 2: [0, 9, 12, 20]
    List 3: [5, 18, 22, 30]

    The smallest range here would be [20, 24] as it contains 24 from list 1, 20 from list 2, and 22 from list 3.

    */

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> sample = [4, 10, 15, 24, 26];
            List<int> sample2 = [0, 9, 12, 20];
            List<int> sample3 = [5, 18, 22, 30];

            int[] range = SmallestRange(sample, sample2, sample3);
        }

        private static int[] SmallestRange(List<int> sample, List<int> sample2, List<int> sample3)
        {
            int first = sample.Count - 1, second = sample2.Count - 1, third = sample3.Count - 1;

            int[] rangeSet = [sample[first], sample2[second], sample3[third]];
            int[] result = [rangeSet.Min(), rangeSet.Max()];
            int minRange = result[1] - sample2[0];

            while (first >= 0 && second >= 0 && third >= 0)
            {
                rangeSet[0] = sample[first];
                rangeSet[1] = sample2[second];
                rangeSet[2] = sample3[third];

                int min = rangeSet.Min();
                int max = rangeSet.Max();

                if (minRange > (max - min))
                {
                    minRange = (max - min);

                    result[0] = min;
                    result[1] = max;
                }

                int maxIndex = Array.IndexOf(rangeSet, max);

                if (maxIndex == 0)
                {
                    first--;
                }
                else if (maxIndex == 1)
                {
                    second--;
                }
                else
                {
                    third--;
                }
            }

            return result;
        }
    }
}