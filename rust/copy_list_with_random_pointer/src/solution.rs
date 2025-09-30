use std::cell::RefCell;
use std::rc::Rc;

#[derive(Debug)]
pub struct RandomNode {
    pub val: i32,
    pub next: Option<Rc<RefCell<RandomNode>>>,
    pub random: Option<Rc<RefCell<RandomNode>>>,
}

impl RandomNode {
    #[must_use]
    pub fn new(val: i32) -> Self {
        Self {
            val,
            next: None,
            random: None,
        }
    }
}

pub fn copy_random_list(
    _head: Option<Rc<RefCell<RandomNode>>>,
) -> Option<Rc<RefCell<RandomNode>>> {
    todo!()
}
