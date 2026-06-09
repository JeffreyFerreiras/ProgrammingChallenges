namespace ContainsDuplicate
{
    public class Solution
    {
        public bool ContainsDuplicate_NetSort(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] == nums[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsDuplicate_SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int smallest = i;
                int unsorted = i + 1;

                while (unsorted < nums.Length)
                {
                    if (nums[smallest] > nums[unsorted])
                    {
                        smallest = unsorted;
                    }

                    unsorted++;
                }

                int temp = nums[smallest];
                nums[smallest] = nums[i];
                nums[i] = temp;

                if (i != 0 && nums[i - 1] == nums[i])
                {
                    return true;
                }
            }

            return nums[nums.Length - 2] == nums[nums.Length - 1];
        }

        public bool ContainsDuplicate_InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int j = i;
                int value = nums[i];

                while (j > 0 && nums[j - 1] >= value)
                {
                    if (nums[j - 1] == value)
                    {
                        return true;
                    }

                    nums[j] = nums[j - 1];
                    j--;
                }

                nums[j] = value;
            }

            return false;
        }

        public bool ContainsDuplicate_QuickSort(int[] nums)
        {
            bool hasDuplicate = false;
            QuickSort(nums, 0, nums.Length - 1);
            return hasDuplicate;

            void QuickSort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int partitionIndex = Partition(arr, low, high);
                    if (hasDuplicate)
                    {
                        return;
                    }

                    QuickSort(arr, low, partitionIndex - 1);
                    QuickSort(arr, partitionIndex, high);
                }
            }

            int Partition(int[] arr, int low, int high)
            {
                int pivot = arr[(low + high) / 2];

                while (low <= high)
                {
                    while (arr[low] < pivot)
                    {
                        low++;
                    }

                    while (arr[high] > pivot)
                    {
                        high--;
                    }

                    if (arr[low] == pivot || arr[high] == pivot)
                    {
                        hasDuplicate = true;
                        return -1;
                    }

                    if (low <= high)
                    {
                        int temp = arr[low];
                        arr[low] = arr[high];
                        arr[high] = temp;
                        low++;
                        high--;
                    }
                }

                return low;
            }
        }

        public bool ContainsDuplicate_HashSet(int[] nums)
        {
            var hashSet = new HashSet<int>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hashSet.Add(nums[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsDuplicate_HashSet2(int[] nums)
        {
            return new HashSet<int>(nums).Count != nums.Length;
        }
    }
}