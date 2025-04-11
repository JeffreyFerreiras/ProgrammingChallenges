# Time Conversion

## Problem Description
Given a time in AM/PM format, convert it to military (24-hour) time.

Note: 
- 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
- 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.

## Examples
**Example 1:**
```
Input: 07:05:45PM
Output: 19:05:45
```

**Example 2:**
```
Input: 12:01:00PM
Output: 12:01:00
```

**Example 3:**
```
Input: 12:01:00AM
Output: 00:01:00
```

## Solution Approach
The solution uses C#'s built-in DateTime parsing capabilities:
- Parse the input string into a DateTime object using DateTime.TryParse
- Format the resulting DateTime to 24-hour format using the "HH:mm:ss" format string
- Time Complexity: O(1) since the operation doesn't depend on input size
- Space Complexity: O(1) since we use constant extra space