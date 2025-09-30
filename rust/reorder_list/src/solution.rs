#[derive(Clone, Debug, PartialEq, Eq)]
pub struct ListNode {
    pub val: i32,
    pub next: Option<Box<ListNode>>,
}

impl ListNode {
    #[must_use]
    pub fn new(val: i32) -> Self {
        Self { val, next: None }
    }
}

pub fn reorder_list(_head: &mut Option<Box<ListNode>>) {
    todo!()
}
