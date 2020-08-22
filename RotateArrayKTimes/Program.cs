using System;

namespace RotateArrayKTimes
{
    class Program
    {
        /*
        Given an array, rotate the array to the right by k steps, where k is non-negative.

Follow up:

Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
Could you do it in-place with O(1) extra space? 

         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public void Rotate(int[] nums, int k)
        {
            int r = k % nums.Length;

            Array.Reverse(nums, 0, nums.Length);
            Array.Reverse(nums, r, (nums.Length - r));
            Array.Reverse(nums, 0, r);
        }
    }
}
