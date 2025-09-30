use std::cell::RefCell;
use std::rc::Rc;

#[derive(Debug)]
pub struct ListNode {
    pub val: i32,
    pub next: Option<Rc<RefCell<ListNode>>>,
}

impl ListNode {
    #[must_use]
    pub fn new(val: i32) -> Self {
        Self { val, next: None }
    }
}

pub fn has_cycle(_head: Option<Rc<RefCell<ListNode>>>) -> bool {
    todo!()
}
