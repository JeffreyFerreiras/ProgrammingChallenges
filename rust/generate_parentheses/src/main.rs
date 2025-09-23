mod solution;

use solution::Solution;
use std::time::Instant;

fn main() {
    // Test case 1: n = 3
    println!("Generate Parentheses for n = 3:");
    let start = Instant::now();
    let result1 = Solution::generate_parenthesis(3);
    let elapsed = start.elapsed();
    for (i, combination) in result1.iter().enumerate() {
        println!("  {}: {}", i + 1, combination);
    }
    println!("Total combinations: {}", result1.len());
    println!("Elapsed: {:.3} ms\n", elapsed.as_secs_f64() * 1000.0);

    // Test case 2: n = 1
    println!("Generate Parentheses for n = 1:");
    let start = Instant::now();
    let result2 = Solution::generate_parenthesis(1);
    let elapsed = start.elapsed();
    for (i, combination) in result2.iter().enumerate() {
        println!("  {}: {}", i + 1, combination);
    }
    println!("Total combinations: {}", result2.len());
    println!("Elapsed: {:.3} ms\n", elapsed.as_secs_f64() * 1000.0);

    // Test case 3: n = 2
    println!("Generate Parentheses for n = 2:");
    let start = Instant::now();
    let result3 = Solution::generate_parenthesis(2);
    let elapsed = start.elapsed();
    for (i, combination) in result3.iter().enumerate() {
        println!("  {}: {}", i + 1, combination);
    }
    println!("Total combinations: {}", result3.len());
    println!("Elapsed: {:.3} ms", elapsed.as_secs_f64() * 1000.0);
}
