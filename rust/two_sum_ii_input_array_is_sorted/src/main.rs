mod solution;

fn main() {
    // Example 1: numbers = [2,7,11,15], target = 9
    // Expected output: [1,2]
    let numbers1 = vec![2, 7, 11, 15];
    let target1 = 9;
    println!("Example 1:");
    println!("Input: numbers = {:?}, target = {}", numbers1, target1);
    let result1 = solution::Solution::two_sum(numbers1, target1);
    println!("Output: {:?}", result1);
    println!("Expected: [1, 2]");
    println!();

    // Example 2: numbers = [2,3,4], target = 6
    // Expected output: [1,3]
    let numbers2 = vec![2, 3, 4];
    let target2 = 6;
    println!("Example 2:");
    println!("Input: numbers = {:?}, target = {}", numbers2, target2);
    let result2 = solution::Solution::two_sum(numbers2, target2);
    println!("Output: {:?}", result2);
    println!("Expected: [1, 3]");
    println!();

    // Example 3: numbers = [-1,0], target = -1
    // Expected output: [1,2]
    let numbers3 = vec![-1, 0];
    let target3 = -1;
    println!("Example 3:");
    println!("Input: numbers = {:?}, target = {}", numbers3, target3);
    let result3 = solution::Solution::two_sum(numbers3, target3);
    println!("Output: {:?}", result3);
    println!("Expected: [1, 2]");
    println!();

    // Failing test case: numbers = [-5,-3,0,2,4,6,8], target = 5
    // Expected output: [2,7] (indices of -3 and 8)
    let numbers_fail = vec![-5, -3, 0, 2, 4, 6, 8];
    let target_fail = 5;
    println!("Failing test case:");
    println!("Input: numbers = {:?}, target = {}", numbers_fail, target_fail);
    let result_fail = solution::Solution::two_sum(numbers_fail, target_fail);
    println!("Output: {:?}", result_fail);
    println!("Expected: [2, 7]");
    println!();

    // Original test case
    let input = [1,2,3,4,5];
    let target = 3;
    println!("Original test:");
    println!("Input: numbers = {:?}, target = {}", input, target);
    let result = solution::Solution::two_sum(input.to_vec(), target);
    println!("Output: {:?}", result);
    println!("Expected: [1, 2]");
}
