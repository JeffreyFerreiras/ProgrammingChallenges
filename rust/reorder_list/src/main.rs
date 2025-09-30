mod solution;

use solution::{reorder_list, ListNode};
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::time::Instant;

fn main() {
    println!("143. Reorder List");
    println!("====================================================================");

    run_scenario(
        "Example: [1,2,3,4]",
        || {
            let mut head = build_list(&[1, 2, 3, 4]);
            reorder_list(&mut head);
            format_list(&head)
        },
        "[1,4,2,3]",
    );

    run_scenario(
        "Edge: single node",
        || {
            let mut head = build_list(&[42]);
            reorder_list(&mut head);
            format_list(&head)
        },
        "[42]",
    );

    run_scenario(
        "Long: eight nodes",
        || {
            let values: Vec<i32> = (1..=8).collect();
            let mut head = build_list(&values);
            reorder_list(&mut head);
            format_list(&head)
        },
        "[1,8,2,7,3,6,4,5]",
    );
}

fn run_scenario<F>(name: &str, action: F, expected: &str)
where
    F: FnOnce() -> String + std::panic::UnwindSafe,
{
    let start = Instant::now();
    let result = catch_unwind(AssertUnwindSafe(action));
    let elapsed_ms = start.elapsed().as_secs_f64() * 1000.0;

    match result {
        Ok(output) => {
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

fn format_list(head: &Option<Box<ListNode>>) -> String {
    let mut values = Vec::new();
    let mut cursor = head.as_deref();
    while let Some(node) = cursor {
        values.push(node.val);
        cursor = node.next.as_deref();
    }

    if values.is_empty() {
        "[]".to_string()
    } else {
        format!("[{}]", values.iter().map(|v| v.to_string()).collect::<Vec<_>>().join(","))
    }
}
