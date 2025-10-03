namespace MedianOfTwoSortedArrays;

public class Solution
{
    // public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    // {
    //     if (nums1.Length == 0 && nums2.Length == 0)
    //         return 0.0;
    //     int totalLength = nums1.Length + nums2.Length;
    //     int medianIndexMax = totalLength / 2;
    //     int left = 0, right = 0;
    //     int medianIndex = 0;
    //     int[] medians = [int.MinValue, int.MinValue];

    //     while (medianIndex <= medianIndexMax && (left < nums1.Length || right < nums2.Length))
    //     {
    //         if (left < nums1.Length && right < nums2.Length)
    //         {
    //             if (nums1[left] <= nums2[right])
    //             {
    //                 medians[medianIndex % 2] = nums1[left];
    //                 left++;
    //             }
    //             else
    //             {
    //                 medians[medianIndex % 2] = nums2[right];
    //                 right++;
    //             }
    //         }
    //         else if (left < nums1.Length)
    //         {
    //             medians[medianIndex % 2] = nums1[left];
    //             left++;
    //         }
    //         else if (right < nums2.Length)
    //         {
    //             medians[medianIndex % 2] = nums2[right];
    //             right++;
    //         }

    //         medianIndex++;
    //     }

    //     return totalLength % 2 == 0 ? (medians[0] + medians[1]) / 2.0 : medians[medianIndexMax % 2];
    // }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int totalLength = nums1.Length + nums2.Length;
        int medianIndex = totalLength / 2;
        int left = 0, right = 0, prev = 0, curr = 0;

        for (int i = 0; i <= medianIndex; i++)
        {
            prev = curr;

            if (left < nums1.Length && (right >= nums2.Length || nums1[left] <= nums2[right]))
            {
                curr = nums1[left++];
            }
            else
            {
                curr = nums2[right++];
            }
        }

        return totalLength % 2 == 0 ? (prev + curr) / 2.0 : curr;
    }

    public double FindMedianSortedArrays_RealWorld(int[] nums1, int[] nums2)
    {
        return nums1.Concat(nums2).OrderBy(x => x).ToArray() is var merged && merged.Length > 0
            ? merged.Length % 2 == 0
                ? (merged[merged.Length / 2 - 1] + merged[merged.Length / 2]) / 2.0
                : merged[merged.Length / 2]
            : 0.0;
    }
}
