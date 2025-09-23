use std::cmp::Reverse;
use std::collections::BinaryHeap;

/// Returns the k-th largest element in `nums` using a min-heap of size `k`.
///
/// Runs in O(n log k) time and O(k) additional space where `n` is the
/// length of the input slice. Returns `None` when `k` is zero or greater than
/// the number of available elements.
pub fn kth_largest(nums: &[i32], k: usize) -> Option<i32> {
    
}git config --global user.name "Jeffrey Ferreiras"
git config --global user.email "jeffrey.e.ferreiras@gmail.com"

#[cfg(test)]
mod tests {
    use super::kth_largest;

    #[test]
    fn finds_kth_largest_in_unsorted_array() {
        let nums = vec![3, 2, 1, 5, 6, 4];
        assert_eq!(kth_largest(&nums, 2), Some(5));
    }

    #[test]
    fn handles_k_equal_to_one() {
        let nums = vec![3, 2, 1];
        assert_eq!(kth_largest(&nums, 1), Some(3));
    }

    #[test]
    fn returns_none_when_k_is_zero() {
        let nums = vec![3, 1, 2];
        assert_eq!(kth_largest(&nums, 0), None);
    }

    #[test]
    fn returns_none_when_k_exceeds_length() {
        let nums = vec![2, 4, 6];
        assert_eq!(kth_largest(&nums, 4), None);
    }
}
