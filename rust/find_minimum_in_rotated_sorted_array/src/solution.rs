pub struct Solution;

impl Solution {
    pub fn find_min(nums: Vec<i32>) -> i32 {
        let mut left = 0;
        let mut right = nums.len() - 1;

        while left <= right {
            let mid = (left + right) / 2;

            if nums[mid] < nums[right] {   
                right = mid;
            } else if nums[mid] > nums[left] {
                left = mid + 1;
            } else {
                break;
            }
        }

        nums[right]
    }
}
