
pub struct Solution;

impl Solution {
    pub fn search(nums: Vec<i32>, target: i32) -> i32 {
        let mut low = 0;
        let mut high = nums.len() - 1;

        while low <= high {
            let mid = (low + high) / 2;
            if nums[mid] > target {
                high = mid - 1;
            } else if nums[mid] < target {
                low = mid + 1;
            } else {
                return mid.try_into().unwrap();
            }
        }

        -1i32
    }
}