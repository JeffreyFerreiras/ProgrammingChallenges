mod solution;

use solution::daily_temperatures;

fn main() {
    // Test case 1
    let temperatures1 = vec![73, 74, 75, 71, 69, 72, 76, 73];
    let expected1 = vec![1, 1, 4, 2, 1, 1, 0, 0];
    let result1 = daily_temperatures(temperatures1.clone());
    let pass1 = result1 == expected1;
    println!("Test Case 1: {}", if pass1 { "✓" } else { "✗" });
    println!("Input: {:?}", temperatures1);
    println!("Output: {:?}", result1);
    println!("Expected: {:?}", expected1);
    println!();

    // Test case 2
    let temperatures2 = vec![30, 40, 50, 60];
    let expected2 = vec![1, 1, 1, 0];
    let result2 = daily_temperatures(temperatures2.clone());
    let pass2 = result2 == expected2;
    println!("Test Case 2: {}", if pass2 { "✓" } else { "✗" });
    println!("Input: {:?}", temperatures2);
    println!("Output: {:?}", result2);
    println!("Expected: {:?}", expected2);
    println!();

    // Test case 3
    let temperatures3 = vec![30, 60, 90];
    let expected3 = vec![1, 1, 0];
    let result3 = daily_temperatures(temperatures3.clone());
    let pass3 = result3 == expected3;
    println!("Test Case 3: {}", if pass3 { "✓" } else { "✗" });
    println!("Input: {:?}", temperatures3);
    println!("Output: {:?}", result3);
    println!("Expected: {:?}", expected3);
    println!();

    // Additional test cases
    let temperatures4 = vec![89, 62, 70, 58, 47, 47, 46, 76, 100, 70];
    let expected4 = vec![8, 1, 5, 4, 3, 2, 1, 1, 0, 0];
    let result4 = daily_temperatures(temperatures4.clone());
    let pass4 = result4 == expected4;
    println!("Test Case 4: {}", if pass4 { "✓" } else { "✗" });
    println!("Input: {:?}", temperatures4);
    println!("Output: {:?}", result4);
    println!("Expected: {:?}", expected4);
    println!();

    // Edge case: single element
    let temperatures5 = vec![30];
    let expected5 = vec![0];
    let result5 = daily_temperatures(temperatures5.clone());
    let pass5 = result5 == expected5;
    println!("Test Case 5 (Edge): {}", if pass5 { "✓" } else { "✗" });
    println!("Input: {:?}", temperatures5);
    println!("Output: {:?}", result5);
    println!("Expected: {:?}", expected5);
    println!();

    // Summary
    let all_tests = vec![pass1, pass2, pass3, pass4, pass5];
    let passed = all_tests.iter().filter(|&&x| x).count();
    let total = all_tests.len();
    println!("Summary: {}/{} tests passed {}", passed, total, if passed == total { "✓" } else { "✗" });
}