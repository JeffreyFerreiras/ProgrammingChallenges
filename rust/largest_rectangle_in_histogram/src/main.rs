mod solution;

use solution::Solution;
use std::time::Instant;

fn main() {
    let test_cases = vec![
        // Basic cases
        (vec![2, 1, 5, 6, 2, 3], 10),
        (vec![2, 4], 4),
        (vec![1], 1),
        (vec![1, 1], 2),
        
        // Edge cases
        (vec![0], 0),
        (vec![0, 0, 0], 0),
        (vec![1, 1, 1, 1], 4),
        (vec![5, 4, 3, 2, 1], 9), // Decreasing heights
        (vec![1, 2, 3, 4, 5], 9), // Increasing heights
        
        // Complex cases
        (vec![6, 2, 5, 4, 5, 1, 6], 12),
        (vec![3, 1, 3, 2, 2], 6),
        (vec![2, 1, 2], 3),
        (vec![4, 2, 0, 3, 2, 5], 6),
        
        // Single bar cases
        (vec![5], 5),
        (vec![10], 10),
        (vec![0], 0),
        
        // Two bar cases
        (vec![1, 2], 2),
        (vec![2, 1], 2),
        (vec![3, 3], 6),
        
        // Three bar cases
        (vec![1, 2, 3], 4), // 2*2 = 4
        (vec![3, 2, 1], 4), // 2*2 = 4
        (vec![2, 1, 2], 3), // 1*3 = 3
        (vec![1, 3, 2], 4), // 2*2 = 4
        
        // Large rectangles
        (vec![1, 1, 1, 1, 1, 1, 1, 1, 1, 1], 10), // All same height
        (vec![5, 5, 5, 5, 5], 25), // All same height
        
        // Stress test cases
        (vec![1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 25), // Increasing
        (vec![10, 9, 8, 7, 6, 5, 4, 3, 2, 1], 25), // Decreasing
        (vec![5, 1, 5, 1, 5, 1, 5], 7), // Alternating pattern
        
        // Complex patterns
        (vec![2, 1, 2, 1, 2, 1, 2], 7),
        (vec![3, 2, 1, 2, 3], 6),
        (vec![1, 3, 2, 1, 3, 2, 1], 6),
        
        // Edge case with zeros
        (vec![0, 1, 2, 3, 4, 5], 9), // 3*3 = 9
        (vec![5, 4, 3, 2, 1, 0], 9), // 3*3 = 9
        (vec![1, 0, 1, 0, 1], 1), // Single bar
        
        // Large values
        (vec![1000, 1000, 1000], 3000),
        (vec![10000, 1, 10000], 10000),
        
        // Complex nested pattern
        (vec![1, 2, 3, 4, 3, 2, 1], 9), // Peak in middle
        (vec![4, 3, 2, 1, 2, 3, 4], 9), // Valley in middle
    ];

    println!("Running Largest Rectangle in Histogram tests...\n");

    let mut passed = 0;
    let mut failed = 0;

    for (i, (heights, expected)) in test_cases.iter().enumerate() {
        println!("Test case {}: {:?}", i + 1, heights);
        
        let start = Instant::now();
        let result = Solution::largest_rectangle_area(heights.clone());
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
    println!("Performance test: Large histogram");
    let large_heights: Vec<i32> = (1..=10000).collect();
    let start = Instant::now();
    let result = Solution::largest_rectangle_area(large_heights);
    let elapsed = start.elapsed();
    println!("  Large histogram (10000 bars): {}", result);
    println!("  Time: {:.3} ms", elapsed.as_secs_f64() * 1000.0);
    println!();

    // Stress test with random-like pattern
    println!("Stress test: Random-like pattern");
    let stress_heights: Vec<i32> = (0..1000)
        .map(|i| (i % 10) + 1)
        .collect();
    let start = Instant::now();
    let result = Solution::largest_rectangle_area(stress_heights);
    let elapsed = start.elapsed();
    println!("  Stress test (1000 bars): {}", result);
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
