using System;
using System.Linq;

namespace SingleNumber
{
    class Program
    {
        // Find non-repeated number [2,2,1,1,3] ans: 3

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int SingleNumber(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums.First();
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == -1) continue;

                int j = i + 1;

                while (j < nums.Length - 1 && nums[j] != nums[i])
                {
                    j++;
                }

                if (nums[j] != nums[i])
                {
                    return nums[i];
                }

                nums[j] = -1;
            }

            return nums.Last();
        }
    }
}
