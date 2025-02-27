namespace AddOne
{
    // Add one number to the array as if doing addition on paper

    class Program
    {
        static void Main(string[] args)
        {
            int[] expected;

            int[] sample = [1, 3, 2, 4];
            expected = [1, 3, 2, 5];
            int[] result = AddOne(sample);
            Console.WriteLine("Expected: {0}, Result: {1}", string.Join(",", expected), string.Join(",", result));


            int[] sample2 = [5, 4, 8, 9];
            int[] result2 = AddOne(sample2);

            int[] sample3 = [9, 8, 9, 9];
            int[] result3 = AddOne(sample3);

            int[] sample4 = [];
            int[] result4 = AddOne(sample4);

            int[] sample5 = [9, 9, 9, 9];
            int[] result5 = AddOne(sample5);
        }

        // 
        static int[] AddOne(int[] nums)
        {
            int carry = 1;
            var result = new Stack<int>();

            for(int i = nums.Length - 1; i > 0; i--)
            {
                int current = nums[i] + carry;
                if(current > 10)
                {
                    carry = current % 10;
                    result.Push(9);
                }else{
                    result.Push(current);
                }                
            }

            if(carry > 0)
            {
                result.Push(carry);
            }

            return [.. result];
        }

        static int[] AddOneX(int[] sample)
        {
            return AddOne(sample, sample.Length - 1);
        }

        static int[] AddOne(int[] arr, int index)
        {
            if(index < 0)
            {
                return PrependOne(arr);
            }

            arr[index] += 1;

            if(arr[index] >= 10)
            {
                arr[index] = arr[index] % 10;

                return AddOne(arr, index - 1);
            }

            return arr;
        }

        static int[] PrependOne(int[] arr)
        {
            var newArray = new int[arr.Length + 1];
            newArray[0] = 1;

            for(int i = 1; i < arr.Length; i++)
            {
                newArray[i] = arr[i];
            }

            return newArray;
        }
    }
}
