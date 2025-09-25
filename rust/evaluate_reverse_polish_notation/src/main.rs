mod solution;

use solution::Solution;
use std::time::Instant;

fn main() {
    let test_cases = vec![
        // Basic cases
        (vec!["2", "1", "+", "3", "*"], 9),
        (vec!["4", "13", "5", "/", "+"], 6),
        (vec!["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"], 22),
        
        // Simple operations
        (vec!["2", "3", "+"], 5),
        (vec!["10", "5", "-"], 5),
        (vec!["4", "5", "*"], 20),
        (vec!["15", "3", "/"], 5),
        
        // Single number
        (vec!["42"], 42),
        (vec!["-42"], -42),
        
        // Negative numbers
        (vec!["-2", "3", "+"], 1),
        (vec!["2", "-3", "+"], -1),
        (vec!["-2", "-3", "+"], -5),
        (vec!["-2", "-3", "*"], 6),
        (vec!["-10", "2", "/"], -5),
        
        // Division truncation
        (vec!["13", "5", "/"], 2),
        (vec!["-13", "5", "/"], -2),
        (vec!["13", "-5", "/"], -2),
        (vec!["-13", "-5", "/"], 2),
        
        // Complex expressions
        (vec!["1", "2", "+", "3", "4", "+", "*"], 21), // (1+2) * (3+4) = 3 * 7 = 21
        (vec!["2", "3", "4", "*", "+"], 14), // 2 + (3 * 4) = 2 + 12 = 14
        (vec!["4", "2", "1", "3", "+", "*", "+"], 12), // 4 + (2 * (1 + 3)) = 4 + 8 = 12
        
        // Edge cases with zeros
        (vec!["0", "5", "+"], 5),
        (vec!["5", "0", "+"], 5),
        (vec!["0", "5", "*"], 0),
        (vec!["5", "0", "*"], 0),
        
        // Large numbers
        (vec!["1000", "2000", "+"], 3000),
        (vec!["1000", "2000", "*"], 2000000),
        (vec!["2000000", "1000", "/"], 2000),
        
        // Stress test - long expression
        (vec![
            "1", "2", "+", "3", "+", "4", "+", "5", "+", "6", "+", "7", "+", "8", "+", "9", "+", "10", "+"
        ], 55), // Sum of 1 to 10
        
        // Complex nested operations
        (vec!["1", "2", "+", "3", "4", "+", "*", "5", "6", "+", "+"], 30), // ((1+2)*(3+4)) + (5+6) = 21 + 11 = 32
    ];

    println!("Running Evaluate Reverse Polish Notation tests...\n");

    let mut passed = 0;
    let mut failed = 0;

    for (i, (tokens, expected)) in test_cases.iter().enumerate() {
        let tokens_str: Vec<String> = tokens.iter().map(|s| s.to_string()).collect();
        println!("Test case {}: {:?}", i + 1, tokens);
        
        let start = Instant::now();
        let result = Solution::eval_rpn(tokens_str);
        let elapsed = start.elapsed();
        
        let status = if result == *expected {
            passed += 1;
            "✓ PASS"
        } else {
            failed += 1;
            "✗ FAIL"
        };
        
        println!("  Expected: {}, Got: {}", expected, result);
        println!("  Status: {}", status);
        println!("  Time: {:.3} ms", elapsed.as_secs_f64() * 1000.0);
        println!();
    }

    // Performance test with large input
    println!("Performance test: Large expression");
    let large_tokens: Vec<String> = (1..=1000)
        .map(|i| i.to_string())
        .collect::<Vec<String>>()
        .into_iter()
        .chain(vec!["+".to_string(); 999])
        .collect();
    
    let start = Instant::now();
    let result = Solution::eval_rpn(large_tokens);
    let elapsed = start.elapsed();
    println!("  Large expression (1000 numbers, 999 additions): {}", result);
    println!("  Time: {:.3} ms", elapsed.as_secs_f64() * 1000.0);
    println!();

    println!("=== Test Results ===");
    println!("Total tests: {}", test_cases.len());
    println!("Passed: {}", passed);
    println!("Failed: {}", failed);
    
    if failed == 0 {
        println!("🎉 All tests passed!");
    } else {
        println!("❌ {} test(s) failed", failed);
    }
}
