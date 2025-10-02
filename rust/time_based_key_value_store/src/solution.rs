use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn create_time_map() -> TimeMap {
        TimeMap::new()
    }
}

pub struct TimeMap {
    store: std::collections::HashMap<String, Vec<(i32, String)>>,
}

impl TimeMap {
    pub fn new() -> Self {
        TimeMap {
            store: HashMap::new(),
        }
    }

    pub fn set(&mut self, key: String, value: String, timestamp: i32) {
        if self.store.contains_key(&key) {
            if let Some(last) = self.store
                    .get_mut(&key)
                    .and_then(|v| v.last_mut()) {
                if last.0 == timestamp {
                    last.1 = value;
                    return;
                }
            }
        }
        self.store
            .entry(key.to_string())
            .or_insert_with(Vec::new)
            .push((timestamp, value));
    }

    pub fn get(&self, key: String, timestamp: i32) -> String {
        let values = match self.store.get(&key) {
            Some(v) => v,
            None => return String::new(),
        };

        if values.is_empty() {
            return String::new();
        }

        let mut left = 0;
        let mut right = values.len() - 1;
        let mut target = -1 as i32;

        while left <= right {
            let mid = left + (right - left) / 2;

            if values[mid].0 < timestamp {
                left = mid + 1;
            } else if values[mid].0 > timestamp {
                right = if mid == 0 { break; } else { mid - 1 };
            } else {
                target = mid as i32;
                break;
            }
        }

        if target == -1 {
            if values[0].0 > timestamp {
                return String::new();
            } else {
                target = right as i32;
            }
        }
        
        for i in (0..=target as usize).rev() {
            let value = &values[i];

            if value.1 != String::new() {
                return value.1.clone();
            }
        }

        String::new()
    }
}
