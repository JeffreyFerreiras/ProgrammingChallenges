mod solution;

use solution::Solution;
use std::time::Instant;

fn main() {
    let test_cases = [
        // Basic test cases
        ("", true),           // Empty string should be valid
        ("()", true),         // Simple valid pair
        ("(", false),         // Single opening bracket
        (")", false),         // Single closing bracket
        ("((", false),        // Multiple opening brackets
        ("))", false),        // Multiple closing brackets
        ("()()", true),       // Two valid pairs
        ("(]", false),        // Mismatched brackets
        ("([)]", false),      // Wrong order
        ("()[]{}", true),     // Mixed valid brackets
        ("((()))", true),     // Nested valid
        ("{[]}", true),       // Curly brackets valid
        ("[{()}]", true),     // Complex mixed valid
        ("([{])", false),     // Complex mixed invalid
        ("{[()]}", true),     // Deep nesting valid
        ("{[(])}", false),    // Deep nesting invalid
    ];

    println!("Running Valid Parentheses tests...\n");

    let mut passed = 0;
    let mut failed = 0;

    for (i, (input, expected)) in test_cases.iter().enumerate() {
        println!("Test case {}: \"{}\"", i + 1, input);

        let start = Instant::now();
        let result = Solution::is_valid(input.to_string());
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

    // Debug the failing case
    println!("=== Debugging Failing Cases ===");
    let debug_cases = [
        ("((", "Simple case - unmatched opening"),
        ("))", "Simple case - unmatched closing"),
        ("()(", "Simple case - wrong order"),
    ];

    for (i, (case, description)) in debug_cases.iter().enumerate() {
        println!("Debug case {}: {} - \"{}\"", i + 1, description, case);
        println!("  Length: {}", case.len());
        println!("  Characters: {:?}", case.chars().collect::<Vec<_>>());

        // Manual trace
        let mut stack = Vec::new();
        let mut trace = Vec::new();
        for (j, ch) in case.chars().enumerate() {
            match ch {
                '(' | '[' | '{' => {
                    stack.push(ch);
                    trace.push(format!("Step {}: Push '{}' -> Stack: {:?}", j+1, ch, stack));
                },
                ')' | ']' | '}' => {
                    if stack.is_empty() {
                        trace.push(format!("Step {}: '{}' with empty stack -> INVALID", j+1, ch));
                        break;
                    }
                    let top = stack.pop().unwrap();
                    if (ch == ')' && top != '(') ||
                       (ch == ']' && top != '[') ||
                       (ch == '}' && top != '{') {
                        trace.push(format!("Step {}: '{}' doesn't match '{}' -> INVALID", j+1, ch, top));
                        break;
                    } else {
                        trace.push(format!("Step {}: '{}' matches '{}' -> Stack: {:?}", j+1, ch, top, stack));
                    }
                },
                _ => {
                    trace.push(format!("Step {}: Invalid character '{}' -> INVALID", j+1, ch));
                    break;
                }
            }
        }

        println!("  Manual trace:");
        for step in trace {
            println!("    {}", step);
        }
        println!("  Final stack: {:?}", stack);
        println!("  Is empty: {}", stack.is_empty());
        println!();
    }

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
