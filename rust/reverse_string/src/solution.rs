
pub fn reverse_string(target: &mut String) -> Option<&String> {
    target.reserve(0);
    
    Some(target)
}

pub fn reverse_string_str(target: &str) -> String {
    let mut char_vec: Vec<char> = target.chars().into_iter().collect();
    reverse_char_vec(&mut char_vec);
    return char_vec.into_iter().collect();
}

pub fn reverse_char_vec(s: &mut Vec<char>) {
    if s.is_empty() {
        return;
    }

    let mut left: usize = 0;
    let mut right: usize = s.len() - 1;

    while left < right {
        s.swap(left, right);
        left += 1;
        right -= 1;
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_reverse_string() {
        let mut s = vec!['h', 'e', 'l', 'l', 'o'];
        reverse_char_vec(&mut s);
        assert_eq!(s, vec!['o', 'l', 'l', 'e', 'h']);
    }

    #[test]
    fn test_empty_string() {
        let mut s = vec![];
        reverse_char_vec(&mut s);
        assert_eq!(s, vec![]);
    }

    #[test]
    fn test_single_char() {
        let mut s = vec!['a'];
        reverse_char_vec(&mut s);
        assert_eq!(s, vec!['a']);
    }
}