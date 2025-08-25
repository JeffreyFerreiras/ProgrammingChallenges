mod solution;

fn main() {
    // Scenario 1
    let nums1 = vec![-1, 0, 1, 2, -1, -4];
    let expected1 = vec![vec![-1, -1, 2], vec![-1, 0, 1]];
    let mut result1 = solution::Solution::three_sum(nums1.clone());
    result1.sort();
    let mut expected1_sorted = expected1.clone();
    expected1_sorted.sort();
    println!("Input: {:?}", nums1);
    println!("Expected Output: {:?}", expected1_sorted);
    println!("Output: {:?}", result1);
    if result1 == expected1_sorted {
        println!("Result: ✓");
    } else {
        println!("Result: ✗");
    }

    // Scenario 2
    let nums2 = vec![0, 0, 0];
    let expected2 = vec![vec![0, 0, 0]];
    let mut result2 = solution::Solution::three_sum(nums2.clone());
    result2.sort();
    let mut expected2_sorted = expected2.clone();
    expected2_sorted.sort();
    println!("\nInput: {:?}", nums2);
    println!("Expected Output: {:?}", expected2_sorted);
    println!("Output: {:?}", result2);
    if result2 == expected2_sorted {
        println!("Result: ✓");
    } else {
        println!("Result: ✗");
    }

    // Scenario 3
    let nums3 = vec![];
    let expected3: Vec<Vec<i32>> = vec![];
    let mut result3 = solution::Solution::three_sum(nums3.clone());
    result3.sort();
    let mut expected3_sorted = expected3.clone();
    expected3_sorted.sort();
    println!("\nInput: {:?}", nums3);
    println!("Expected Output: {:?}", expected3_sorted);
    println!("Output: {:?}", result3);
    if result3 == expected3_sorted {
        println!("Result: ✓");
    } else {
        println!("Result: ✗");
    }

    // Scenario 4
    let nums4 = vec![1, 2, -2, -1];
    let expected4: Vec<Vec<i32>> = vec![];
    let mut result4 = solution::Solution::three_sum(nums4.clone());
    result4.sort();
    let mut expected4_sorted = expected4.clone();
    expected4_sorted.sort();
    println!("\nInput: {:?}", nums4);
    println!("Expected Output: {:?}", expected4_sorted);
    println!("Output: {:?}", result4);
    if result4 == expected4_sorted {
        println!("Result: ✓");
    } else {
        println!("Result: ✗");
    }
}
