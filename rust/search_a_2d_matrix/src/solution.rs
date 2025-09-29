pub struct Solution;

impl Solution {
    pub fn search_matrix(matrix: Vec<Vec<i32>>, target: i32) -> bool {
        if matrix.is_empty() || matrix[0].is_empty() {
            return false;
        }

        let mut low = 0i32;
        let mut high = (matrix.len() - 1) as i32;
        let mut mid = 0i32;
        
        while low <= high {
            mid = (low + high) / 2;
            if matrix[mid as usize][0] > target {
                if target >= matrix[mid as usize][0] 
                    && target <= matrix[mid as usize][matrix[mid as usize].len() - 1] {
                    break;
                }
                high = mid - 1;
            } else if matrix[mid as usize][matrix[mid as usize].len() - 1] < target {
                if target >= matrix[mid as usize][0] 
                    && target <= matrix[mid as usize][matrix[mid as usize].len() - 1] {
                    break;
                }
                low = (mid + 1) as i32;
            } else {
                break;
            }
        }

        Self::search(matrix[mid as usize].clone(), target)
    }

    fn search(nums: Vec<i32>, target: i32) -> bool {
        if nums.len() == 0 {
            return false;
        }

        let mut low = 0i32;
        let mut high = (nums.len() - 1) as i32;

        while low <= high {
            let mid = (low + high) / 2;
            if nums[mid as usize] > target {
                high = mid - 1;
            } else if nums[mid as usize] < target {
                low = mid + 1;
            } else {
                return true;
            }
        }
        
        false
    }
}
