mod solution;

use solution::{has_cycle, ListNode};
use std::cell::RefCell;
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::rc::Rc;
use std::time::Instant;

fn main() {
    println!("141. Linked List Cycle");
    println!("====================================================================");

    run_scenario(
        "Example: cycle at index 1",
        || has_cycle(build_list_with_cycle(&[3, 2, 0, -4], Some(1))),
        true,
    );

    run_scenario(
        "Edge: no cycle single node",
        || has_cycle(build_list_with_cycle(&[1], None)),
        false,
    );

    run_scenario(
        "Long: 100 nodes cycle at index 50",
        || {
            let values: Vec<i32> = (1..=100).collect();
            has_cycle(build_list_with_cycle(&values, Some(50)))
        },
        true,
    );
}

fn run_scenario<F>(name: &str, action: F, expected: bool)
where
    F: FnOnce() -> bool + std::panic::UnwindSafe,
{
    let start = Instant::now();
    let result = catch_unwind(AssertUnwindSafe(action));
    let elapsed_ms = start.elapsed().as_secs_f64() * 1000.0;

    match result {
        Ok(value) => {
            println!("Scenario: {name}");
            println!("  Time: {elapsed_ms:.4} ms");
            println!("  Result: {value}");
            println!("  Expected: {expected}");
        }
        Err(_) => {
            println!("Scenario: {name}");
            println!("  Status: NOT IMPLEMENTED [{elapsed_ms:.4} ms]");
            println!("  Expected: {expected}");
        }
    }
}

type NodeRef = Rc<RefCell<ListNode>>;

fn build_list_with_cycle(values: &[i32], pos: Option<usize>) -> Option<NodeRef> {
    if values.is_empty() {
        return None;
    }

    let nodes: Vec<NodeRef> = values
        .iter()
        .map(|&value| Rc::new(RefCell::new(ListNode::new(value))))
        .collect();

    for index in 0..nodes.len().saturating_sub(1) {
        let next = nodes[index + 1].clone();
        nodes[index].borrow_mut().next = Some(next);
    }

    if let Some(target) = pos {
        if target < nodes.len() {
            if let Some(last) = nodes.last() {
                last.borrow_mut().next = Some(nodes[target].clone());
            }
        }
    }

    Some(nodes[0].clone())
}
