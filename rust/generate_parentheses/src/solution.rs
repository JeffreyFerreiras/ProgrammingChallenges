pub struct Solution;

impl Solution {
    pub fn generate_parenthesis_stack(n: i32) -> Vec<String> {
        if n < 0 {
            return Vec::new();
        }
    
        let mut result: Vec<String> = Vec::new();
        let mut stack: Vec<(String, i32, i32)> = Vec::new();
        stack.push((String::new(), 0, 0));
    
        while let Some((current, open_count, close_count)) = stack.pop() {
            if current.len() as i32 == n * 2 {
                result.push(current);
                continue;
            }
    
            if close_count < open_count {
                let mut next = current.clone();
                next.push(')');
                stack.push((next, open_count, close_count + 1));
            }
    
            if open_count < n {
                let mut next = current;
                next.push('(');
                stack.push((next, open_count + 1, close_count));
            }
        }
    
        result
    }
    
    pub fn generate_parenthesis(n: i32) -> Vec<String> {
        let mut result: Vec<String> = Vec::new();
        let mut current = String::new();
        Self::backtrack(&mut result, &mut current, 0, 0, n);
        result
    }
    
    fn backtrack(
        result: &mut Vec<String>,
        current: &mut String,
        open: i32,
        close: i32,
        max: i32,
    ) {
        if current.len() as i32 == max * 2 {
            result.push(current.clone());
            return;
        }
        
        if open < max {
            current.push('(');
            Self::backtrack(result, current, open + 1, close, max);
            current.pop();
        }
        
        if close < open {
            current.push(')');
            Self::backtrack(result, current, open, close + 1, max);
            current.pop();
        }
    }
}