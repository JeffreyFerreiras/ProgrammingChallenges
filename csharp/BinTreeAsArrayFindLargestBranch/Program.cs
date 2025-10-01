using System;

namespace BinTreeAsArrayFindLargestBranch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string Solution(long[] arr)
        {
            // Type your solution here

            const string Left = "Left";
            const string Right = "Right";
            bool isSkipStep = false;
            long sumLeft = 0, sumRight = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (isSkipStep)
                {
                    sumLeft += arr[i];
                }
                else
                {
                    sumRight += arr[i];
                }

                isSkipStep = !isSkipStep;
            }

            if (sumLeft > sumRight)
            {
                return Left;
            }
            else if (sumRight > sumLeft)
            {
                return Right;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
