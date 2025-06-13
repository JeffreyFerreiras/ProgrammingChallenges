namespace CheckPermutations
{
    /*
    QuickSort algorithm implementation for sorting characters.
    */
    public static class QuickSort
    {
        public static string QuickSorter(this string str)
        {
            char[] sorterArry = [.. str];

            QuickSorter(sorterArry, 0, sorterArry.Length - 1);

            return new string(sorterArry);
        }
        private static void QuickSorter(char[] array, int left, int right)
        {
            int pivot = GetPivotPoint(array, left, right);

            if(left < pivot -1)
                QuickSorter(array, left, pivot - 1);

            if(pivot < right)
                QuickSorter(array, pivot, right);
        }

        private static int GetPivotPoint(char[] array, int left, int right)              
        {
            char pivot = array[(left + right) / 2];

            while(left <= right)
            {
                while(array[left] < pivot)
                    left++;
                while(array[right] > pivot)
                    right--;      

                if(left <= right)
                {
                    //swap values
                    char temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;

                    left++;
                    right--;
                }
            }

            return left;
        }
    }
}
