pub struct Solution;

impl Solution {
    pub fn search(nums: Vec<i32>, target: i32) -> i32 {
        if nums.len() == 0 {
            return -1;
        }

        if nums.len() == 1 {
            return if nums[0] == target { 0 } else { -1 };
        }

        let mut left = 0;
        let mut right = nums.len() - 1;

        while left <= right {
            let mid = left + (right - left) / 2;
            
            if nums[mid] == target {
                return mid as i32;
            } else if nums[mid] < target {
                if nums[mid] < nums[left] && target > nums[right] {
                    if mid == 0 {
                        return -1;
                    }
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            } else {
                if nums[mid] > nums[right] && target < nums[left] {
                    left = mid + 1;
                } else {
                    if mid == 0 {
                        return -1;
                    }
                    right = mid - 1;
                }
            }
        }

        -1
    }
}
