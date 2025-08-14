pub struct Solution;

impl Solution {
    pub fn is_palindrome(s: String) -> bool {
        
        let collection: Vec<char> = s
            .chars()
            .filter(|c| c.is_alphanumeric())
            .map(|f| f.to_lowercase().next().unwrap())
            .collect();
            
        let mut start_index : usize = 0;
        let mut end_index: usize = collection.len();

        while start_index < end_index {
            if collection[start_index] == collection[end_index - 1] {
                start_index += 1;
                end_index -= 1;
                continue;
            }
            return false;
        }

        true
    }
}