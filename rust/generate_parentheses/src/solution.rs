pub struct Solution;

impl Solution {
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