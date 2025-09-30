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

pub fn add_two_numbers(
    _l1: Option<Box<ListNode>>,
    _l2: Option<Box<ListNode>>,
) -> Option<Box<ListNode>> {
    todo!()
}
