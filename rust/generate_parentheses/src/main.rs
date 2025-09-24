mod solution;

use solution::Solution;
use std::collections::HashSet;
use std::time::{Duration, Instant};

fn main() {
    let scenarios = [
        ("n = 3", 3),
        ("n = 1", 1),
        ("n = 2", 2),
    ];

    let methods: &[(&str, fn(i32) -> Vec<String>)] = &[
        ("Solution::generate_parenthesis_stack", Solution::generate_parenthesis_stack),
        ("Solution::generate_parenthesis", Solution::generate_parenthesis),
    ];

    for (label, n) in scenarios {        
        println!("=== Scenario: {} ===", label);
        for &(method_label, generator) in methods.iter() {
            run_method(method_label, generator, n);
            println!();
        }
        println!("------------------------------\n");
    }
}

fn run_method(method_label: &str, generator: fn(i32) -> Vec<String>, n: i32) {
    println!("Approach: {}", method_label);

    let start = Instant::now();
    let result = generator(n);
    let elapsed = start.elapsed();

    report_method(method_label, n, result, elapsed);
}

fn report_method(method_label: &str, n: i32, result: Vec<String>, elapsed: Duration) {
    for (i, combination) in result.iter().enumerate() {
        println!("  {}: {}", i + 1, combination);
    }
    println!("Total combinations: {}", result.len());
    println!(
        "Elapsed: {:.3} ms",
        elapsed.as_secs_f64() * 1000.0
    );

    let solved = validate_parenthesis_set(&result, n);

    if solved {
        println!(
            "Result: \u{2713} {} solved the challenge for n = {}",
            method_label, n
        );
    } else {
        println!(
            "Result: \u{2717} {} did not produce a valid solution set for n = {}",
            method_label, n
        );
    }
}

fn validate_parenthesis_set(result: &[String], n: i32) -> bool {
    if n < 0 {
        return false;
    }

    let expected_combinations = catalan_number(n as usize);
    let mut seen = HashSet::new();

    for combination in result {
        if combination.len() != (2 * n) as usize {
            return false;
        }

        let mut balance = 0;
        for ch in combination.chars() {
            match ch {
                '(' => balance += 1,
                ')' => {
                    if balance == 0 {
                        return false;
                    }
                    balance -= 1;
                }
                _ => return false,
            }
        }

        if balance != 0 {
            return false;
        }

        if !seen.insert(combination.clone()) {
            return false;
        }
    }

    seen.len() == expected_combinations
}

fn catalan_number(n: usize) -> usize {
    let mut catalan = vec![0usize; n + 1];
    catalan[0] = 1;

    for i in 1..=n {
        let mut total = 0usize;
        for j in 0..i {
            total += catalan[j] * catalan[i - 1 - j];
        }
        catalan[i] = total;
    }

    catalan[n]
}
