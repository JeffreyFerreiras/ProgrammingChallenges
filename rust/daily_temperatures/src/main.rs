mod solution;

use solution::{daily_temperatures, daily_temperatures_fast};
use std::time::Instant;

fn main() {
    let test_cases = vec![
        (vec![73, 74, 75, 71, 69, 72, 76, 73], vec![1, 1, 4, 2, 1, 1, 0, 0], "Test Case 1"),
        (vec![30, 40, 50, 60], vec![1, 1, 1, 0], "Test Case 2"),
        (vec![30, 60, 90], vec![1, 1, 0], "Test Case 3"),
        (vec![89, 62, 70, 58, 47, 47, 46, 76, 100, 70], vec![8, 1, 5, 4, 3, 2, 1, 1, 0, 0], "Test Case 4"),
        (vec![30], vec![0], "Test Case 5 (Edge)"),
    ];

    let methods = vec![
        ("daily_temperatures", daily_temperatures as fn(Vec<i32>) -> Vec<i32>),
        ("daily_temperatures_fast", daily_temperatures_fast as fn(Vec<i32>) -> Vec<i32>),
    ];

    for (method_name, method_fn) in &methods {
        println!("=== Testing {} ===", method_name);
        let mut all_passed = true;
        let mut total_time = 0.0;
        
        for (temperatures, expected, test_name) in test_cases.iter() {
            let start = Instant::now();
            let result = method_fn(temperatures.clone());
            let duration = start.elapsed();
            let time_ms = duration.as_secs_f64() * 1000.0;
            total_time += time_ms;
            
            let passed = result == *expected;
            all_passed &= passed;
            
            println!("{}: {} ({:.4} ms)", test_name, if passed { "✓" } else { "✗" }, time_ms);
            println!("Input: {:?}", temperatures);
            println!("Output: {:?}", result);
            println!("Expected: {:?}", expected);
            println!();
        }
        
        println!("Summary for {}: {}/5 tests passed {} (Total: {:.4} ms)", 
                method_name, 
                test_cases.iter().filter(|(temps, exp, _)| method_fn(temps.clone()) == *exp).count(),
                if all_passed { "✓" } else { "✗" },
                total_time);
        println!();
    }
}