mod solution;

use solution::{copy_random_list, RandomNode};
use std::cell::RefCell;
use std::collections::HashMap;
use std::panic::{catch_unwind, AssertUnwindSafe};
use std::rc::Rc;
use std::time::Instant;

fn main() {
    println!("138. Copy List With Random Pointer");
    println!("====================================================================");

    run_scenario(
        "Example: five node reference graph",
        || {
            let head = build_random_list(&[
                (7, None),
                (13, Some(0)),
                (11, Some(4)),
                (10, Some(2)),
                (1, Some(0)),
            ]);
            let clone = copy_random_list(head);
            format_random_list(clone)
        },
        "[(7,null)->(13,0)->(11,4)->(10,2)->(1,0)]",
    );

    run_scenario(
        "Edge: single node self reference",
        || {
            let head = build_random_list(&[(1, Some(0))]);
            let clone = copy_random_list(head);
            format_random_list(clone)
        },
        "[(1,0)]",
    );

    run_scenario(
        "Long: alternating random links",
        || {
            let head = build_random_list(&[
                (1, Some(3)),
                (2, Some(0)),
                (3, None),
                (4, Some(2)),
                (5, Some(1)),
                (6, Some(4)),
            ]);
            let clone = copy_random_list(head);
            format_random_list(clone)
        },
        "[(1,3)->(2,0)->(3,null)->(4,2)->(5,1)->(6,4)]",
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

type NodeRef = Rc<RefCell<RandomNode>>;

fn build_random_list(spec: &[(i32, Option<usize>)]) -> Option<NodeRef> {
    if spec.is_empty() {
        return None;
    }

    let nodes: Vec<NodeRef> = spec
        .iter()
        .map(|(value, _)| Rc::new(RefCell::new(RandomNode::new(*value))))
        .collect();

    for (index, node_rc) in nodes.iter().enumerate() {
        let next = if index + 1 < nodes.len() {
            Some(nodes[index + 1].clone())
        } else {
            None
        };
        node_rc.borrow_mut().next = next;
        if let Some(target) = spec[index].1 {
            if target < nodes.len() {
                node_rc.borrow_mut().random = Some(nodes[target].clone());
            }
        }
    }

    Some(nodes[0].clone())
}

fn format_random_list(head: Option<NodeRef>) -> String {
    let Some(start) = head else {
        return "[]".to_string();
    };

    let mut order = Vec::new();
    let mut index_lookup: HashMap<*const RandomNode, usize> = HashMap::new();
    let mut current = Some(start.clone());
    while let Some(node_rc) = current {
        let ptr = Rc::as_ptr(&node_rc);
        index_lookup.insert(ptr, order.len());
        current = node_rc.borrow().next.clone();
        order.push(node_rc);
    }

    let mut parts = Vec::new();
    for node_rc in order {
        let node = node_rc.borrow();
        let random_str = node
            .random
            .as_ref()
            .and_then(|rc| index_lookup.get(&Rc::as_ptr(rc)).copied())
            .map_or("null".to_string(), |idx| idx.to_string());
        parts.push(format!("({},{})", node.val, random_str));
    }

    format!("[{}]", parts.join("->"))
}
