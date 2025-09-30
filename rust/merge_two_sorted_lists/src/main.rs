mod solution;

use solution::{merge_two_lists, ListNode};
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::time::Instant;

fn main() {
    println!("21. Merge Two Sorted Lists");
    println!("====================================================================");

    run_scenario(
        "Example: [1,2,4] + [1,3,4]",
        || merge_two_lists(build_list(&[1, 2, 4]), build_list(&[1, 3, 4])),
        "[1,1,2,3,4,4]",
    );

    run_scenario(
        "Edge: both inputs null",
        || merge_two_lists(None, None),
        "[]",
    );

    run_scenario(
        "Long: evens vs odds",
        || merge_two_lists(
            build_list(&[0, 2, 4, 6, 8, 10]),
            build_list(&[1, 3, 5, 7, 9, 11]),
        ),
        "[0,1,2,3,4,5,6,7,8,9,10,11]",
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
