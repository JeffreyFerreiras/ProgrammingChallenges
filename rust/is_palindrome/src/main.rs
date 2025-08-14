
mod solution;
use solution::Solution;

/// Valid Palindrome Challenge
/// 
/// This program solves the "Valid Palindrome" problem which requires:
/// 1. Converting all uppercase letters to lowercase
/// 2. Removing all non-alphanumeric characters  
/// 3. Checking if the resulting string reads the same forward and backward
/// 
/// Time Complexity: O(n) where n is the length of the string
/// Space Complexity: O(1) if we ignore the space used for the cleaned string
fn main() {
    // Test case 1: Valid palindrome with mixed case and punctuation
    let test1 = "A man, a plan, a canal: Panama".to_string();
    println!("Test 1: \"{}\"", test1);
    println!("Result: {}", Solution::is_palindrome(test1));
    println!();

    // Test case 2: Not a palindrome
    let test2 = "race a car".to_string();
    println!("Test 2: \"{}\"", test2);
    println!("Result: {}", Solution::is_palindrome(test2));
    println!();

    // Test case 3: Empty string (should be true)
    let test3 = "".to_string();
    println!("Test 3: \"{}\"", test3);
    println!("Result: {}", Solution::is_palindrome(test3));
    println!();

    // Test case 4: Single character (should be true)
    let test4 = "a".to_string();
    println!("Test 4: \"{}\"", test4);
    println!("Result: {}", Solution::is_palindrome(test4));
}
