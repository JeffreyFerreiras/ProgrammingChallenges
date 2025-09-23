use std::cmp::Reverse;
use std::collections::BinaryHeap;

/// Returns the k-th largest element in `nums` using a min-heap of size `k`.
///
/// Runs in O(n log k) time and O(k) additional space where `n` is the
/// length of the input slice. Returns `None` when `k` is zero or greater than
/// the number of available elements.
pub fn kth_largest(nums: &[i32], k: usize) -> Option<i32> {
    if k == 0 || k > nums.len() {
        return None;
    }

    let mut heap: BinaryHeap<Reverse<i32>> = BinaryHeap::with_capacity(k);

    for &num in nums {
        heap.push(Reverse(num));

        if heap.len() > k {
            heap.pop();
        }
    }

    heap.peek().map(|rev: &Reverse<i32>| rev.0)
}

pub fn kth_largest_sort(nums: &[i32], k: usize) -> Option<i32> {
    if k == 0 || k > nums.len() {
        return None;
    }

    let mut sorted: Vec<i32> = nums.to_vec();
    sorted.sort_unstable();

    Some(sorted[nums.len() - k])
}

pub fn kth_largest_sort_stable(nums: &[i32], k: usize) -> Option<i32> {
    if k == 0 || k > nums.len() {
        return None;
    }

    let mut sorted: Vec<i32> = nums.to_vec();
    sorted.sort();

    Some(sorted[nums.len() - k])
}