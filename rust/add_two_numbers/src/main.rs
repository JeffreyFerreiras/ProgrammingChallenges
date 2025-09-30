mod solution;

use solution::{add_two_numbers, ListNode};
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::time::Instant;

fn main() {
    println!("2. Add Two Numbers");
    println!("====================================================================");

    run_scenario(
        "Example: [2,4,3] + [5,6,4]",
        || add_two_numbers(build_list(&[2, 4, 3]), build_list(&[5, 6, 4])),
        "[7,0,8]",
    );

    run_scenario(
        "Edge: zero plus zero",
        || add_two_numbers(build_list(&[0]), build_list(&[0])),
        "[0]",
    );

    run_scenario(
        "Long: cascading carry",
        || add_two_numbers(
            build_list(&[9, 9, 9, 9, 9, 9, 9]),
            build_list(&[9, 9, 9, 9]),
        ),
        "[8,9,9,9,0,0,0,1]",
    );
}

fn run_scenario<F>(name: &str, action: F, expected: &str)
where
    F: FnOnce() -> Option<Box<ListNode>> + std::panic::UnwindSafe,
{
    let start = Instant::now();
    let result = catch_unwind(AssertUnwindSafe(action));
    let elapsed_ms = start.elapsed().as_secs_f64() * 1000.0;

    match result {
        Ok(value) => {
            let output = format_list(value);
            println!("Scenario: {name}");
            println!("  Time: {elapsed_ms:.4} ms");
            println!("  Result: {output}");
            println!("  Expected: {expected}");
        }
        Err(_) => {
            println!("Scenario: {name}");
            println!("  Status: NOT IMPLEMENTED [{elapsed_ms:.4} ms]");
            println!("  Expected: {expected}");
        }
    }
}

fn build_list(values: &[i32]) -> Option<Box<ListNode>> {
    let mut head: Option<Box<ListNode>> = None;
    for &value in values.iter().rev() {
        let mut node = Box::new(ListNode::new(value));
        node.next = head;
        head = Some(node);
    }
    head
}

fn format_list(mut head: Option<Box<ListNode>>) -> String {
    let mut values = Vec::new();
    while let Some(node) = head {
        values.push(node.val);
        head = node.next;
    }

    if values.is_empty() {
        "[]".to_string()
    } else {
        format!("[{}]", values.iter().map(|v| v.to_string()).collect::<Vec<_>>().join(","))
    }
}
