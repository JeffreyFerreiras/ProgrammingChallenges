pub struct Solution;

impl Solution {
    pub fn is_valid(s: String) -> bool {
        let mut stack = Vec::new();
        
        for val in s.chars() {
            if val == '(' || val == '[' || val == '{' {
                stack.push(val);
            } else if let Some(&last) = stack.last() {
                if (val == ')' && last == '(')
                    || (val == ']' && last == '[')
                    || (val == '}' && last == '{')
                {
                    stack.pop();
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        stack.is_empty()
    }
}
