namespace FindDuplicate_SpaceEdition
{
    class Program
    {

        /*
         * Find a duplicate, Space Edition™.
         * We have a list of integers, where:
         * 1. The integers are in the range 1..n
         * 2. The list has a length of n + 1
         *
         * It follows that our list has at least one integer which appears at least twice.
         * But it may have several duplicates, and each duplicate may appear more than twice.
         * Write a function which finds an integer that appears more than once in our list.
         * (If there are multiple duplicates, you only need to find one of them.)
         * 
         * We're going to run this function on our new, super-hip Macbook Pro With Retina Display™.
         * Thing is, the damn thing came with the RAM soldered right to the motherboard, so we can't upgrade our RAM.
         * So we need to optimize for space!
         */

        static void Main(string[] args)
        {
            int[] arr = [9, 8, 7, 1, 6, 15, 8];
            int result = IndexOfRepeat(arr);

            Console.WriteLine(arr[result]);
        }

        private static int IndexOfRepeat(int[] arr)
        {
            int floor = 1;
            int ceiling = arr.Length - 1;

            while (floor < ceiling)                                                      
            {
                int mid = floor + (ceiling - floor) / 2;
                int lowerRangeFloor = floor;
                int lowerRangeCeiling = mid;
                int upperRangeFloor = mid + 1;
                int upperRangeCeiling = ceiling;

                int lowerRangeCount = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i >= lowerRangeFloor && i <= lowerRangeCeiling)
                    {
                        lowerRangeCount++;
                    }
                }

                int distinctPossibleIntegers = lowerRangeCeiling - lowerRangeFloor + 1;

                if(lowerRangeCount > distinctPossibleIntegers)
                {
                    floor = lowerRangeFloor;
                    ceiling = lowerRangeCeiling;
                }
                else
                {
                    floor = upperRangeFloor;
                    ceiling = upperRangeCeiling;
                }
            }

            return floor;
        }
    }
}
