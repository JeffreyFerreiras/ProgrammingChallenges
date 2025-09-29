pub struct Solution;

impl Solution {
    pub fn search_matrix(matrix: Vec<Vec<i32>>, target: i32) -> bool {
        let mut low = 0;
        let mut high = matrix.len() - 1;
        let mut mid = 0;
        
        while low < high {
            mid = (low + high) / 2;
            if matrix[mid][0] > target {
                high = mid - 1;
            } else if matrix[mid][0] < target {
                low = mid + 1;
            } else {
                return true;
            }
        }

        Self::search(matrix[mid].clone(), target)
    }

    fn search(nums: Vec<i32>, target: i32) -> bool {
        let mut low = 0;
        let mut high = nums.len() - 1;

        while low < high {
            let mid = (low + high) / 2;
            if nums[mid] > target {
                high = mid - 1;
            } else if nums[mid] < target {
                low = mid + 1;
            } else {
                return true;
            }
        }
        
        false
    }
}
