namespace AddOne
{
    class Solution
    {
        public int[] AddOne(int[] sample)
        {
            return AddOne(sample, sample.Length - 1);
        }

        private int[] AddOne(int[] arr, int index)
        {
            if (index < 0)
            {
                return PrependOne(arr);
            }

            arr[index] += 1;

            if (arr[index] >= 10)
            {
                arr[index] %= 10;
                return AddOne(arr, index - 1);
            }

            return arr;
        }

        private int[] PrependOne(int[] arr)
        {
            var newArray = new int[arr.Length + 1];
            newArray[0] = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i + 1] = arr[i];
            }

            return newArray;
        }
    }
}