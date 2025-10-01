using System.Linq;

namespace FindMissingNumbers
{
    class Program
    {
        /*
         * You are given an array with all the numbers from one to N
         * Appearing exactly once, except for one number that is missing
         * How can you find the missing number in O(n) and O(1) space.
         * 
         * Follow-Up: what if there are two numbers missing?
         * 
         */
        static void Main(string[] args)
        {
            Case1();
            Case2();//no placeholders

        }

        private static void Case2()
        {
            int[] numbers = [1, 2, 4, 5];
            int len = 5;
            int result = FindMissingNumber(numbers, len);
            bool passed = result == 3;

            int[] numbers2 = [1, 2, 4];
            int[] result2 = FindTwoMissingNumbers(numbers2, len);
        }

        private static int[] FindTwoMissingNumbers(int[] numbers, int len)
        {
            int incrementor = numbers[0];
            int[] result = new int[2];

            if (numbers[0] != 1)
            {
                result[0] = 1;
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int expected = incrementor + 1;

                if (current != expected)
                {
                    AssignMissingNumber(result, expected);
                }

                if (result.All(x => x > 0))
                {
                    return result;
                }

                incrementor = expected;
            }

            if (numbers.Length < len) //the trailing number is missing.
            {
                AssignMissingNumber(result, numbers.Last() + 1);
            }

            return result;
        }



        private static int FindMissingNumber(int[] numbers, int len)
        {
            int sum = numbers.Sum();
            int expectedTotal = ((len * (len + 1)) / 2);

            return expectedTotal - sum;
        }

        private static void Case1()
        {
            int[] numbers = [1, 2, 0, 4, 5];
            int result = FindMissingNumber(numbers);
            bool passed = result == 3;


            int[] numbers2 = [1, 2, 0, 4, 0];
            int[] result2 = FindTwoMissingNumbers(numbers2);
        }

        private static int FindMissingNumber(int[] numbers)
        {
            int sum = numbers.Sum();
            int expectedTotal = ((numbers.Length * (numbers.Length + 1)) / 2);

            return expectedTotal - sum;
        }

        private static int[] FindTwoMissingNumbers(int[] numbers)
        {
            int incrementor = numbers[0];
            int[] result = new int[2];

            if (numbers[0] != 1)
            {
                result[0] = 1;
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int expected = incrementor + 1;

                if (current != expected)
                {
                    AssignMissingNumber(result, expected);
                }

                if (result.All(x => x > 0))
                {
                    break;
                }

                incrementor++;
            }

            return result;


        }

        private static void AssignMissingNumber(int[] result, int expected)
        {
            if (result[0] == 0)
            {
                result[0] = expected;
            }
            else
            {
                result[1] = expected;
            }
        }
    }
}
