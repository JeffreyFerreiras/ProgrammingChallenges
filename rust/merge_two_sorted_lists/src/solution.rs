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

pub fn merge_two_lists(
    _list1: Option<Box<ListNode>>,
    _list2: Option<Box<ListNode>>,
) -> Option<Box<ListNode>> {
    todo!()
}
