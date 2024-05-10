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
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            
            Rotate2(nums, 3);

            Console.WriteLine(string.Join(',', nums));
        }
        public void Rotate(int[] nums, int k)
        {
            int r = k % nums.Length;

            Array.Reverse(nums, 0, nums.Length);
            Array.Reverse(nums, r, (nums.Length - r));
            Array.Reverse(nums, 0, r);
        }

        public static void Rotate2(int [] nums, int k)
        {
            int shift = k % nums.Length; 
            int[] temp = new int [nums.Length - shift];

    
            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = nums[i];
            }

            for(int i = 0; i < shift; i++)
            {
                nums[i] = nums[i + (nums.Length - shift)];
            }

            for(int i = 0; i < temp.Length; i++)
            {
                nums[nums.Length - temp.Length + i] = temp[i];
            }
        }
    }
}
