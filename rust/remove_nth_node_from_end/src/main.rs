mod solution;

use solution::{remove_nth_from_end, ListNode};
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::time::Instant;

fn main() {
    println!("19. Remove Nth Node From End of List");
    println!("====================================================================");

    run_scenario(
        "Example: [1,2,3,4,5], n=2",
        || remove_nth_from_end(build_list(&[1, 2, 3, 4, 5]), 2),
        "[1,2,3,5]",
    );

    run_scenario(
        "Edge: remove only node",
        || remove_nth_from_end(build_list(&[10]), 1),
        "[]",
    );

    run_scenario(
        "Long: remove head when n equals length",
        || {
            let values: Vec<i32> = (1..=10).collect();
            remove_nth_from_end(build_list(&values), 10)
        },
        "[2,3,4,5,6,7,8,9,10]",
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
