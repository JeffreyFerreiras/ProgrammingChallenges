
pub struct Solution;

impl Solution {
    pub fn two_sum(numbers: Vec<i32>, target: i32) -> Vec<i32> {
        let mut low = 0usize;
        let mut high = Self::find_high_index(&numbers, target);

        while low <= high {
            let sum = numbers[low] + numbers[high];

            if sum == target {
                return vec![(low as i32) + 1, (high as i32) + 1]
            } else if sum < target {
                low += 1;
            } else { // sum > target
                high -= 1;
            }
        }

        vec![-1, -1]
    }

    pub fn find_high_index(numbers: &Vec<i32>, target: i32) -> usize {
        // For two-sum, we want to find the rightmost position where 
        // numbers[i] + numbers[0] <= target, so we can start high pointer there
        // This avoids checking positions that would definitely be too large
        
        let mut low = 0;
        let mut high = numbers.len() - 1;
        
        // Find the rightmost index where numbers[i] <= (target - numbers[0])
        // This gives us a better starting position for the high pointer
        let max_allowed = target - numbers[0];
        
        while low <= high {
            let mid = low + (high - low) / 2;
            
            if numbers[mid] <= max_allowed {
                low = mid + 1;
            } else {
                if mid == 0 {
                    break;
                }
                high = mid - 1;
            }
        }
        
        // Return the last valid position, but ensure it's not the same as low pointer (0)
        let result = if high < numbers.len() && high > 0 { high } else { numbers.len() - 1 };
        result
    }
}