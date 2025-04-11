# Encode and Decode Strings

## Problem Description
Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.

## Examples
**Example 1:**
```
Input: ["Hello", "World"]
Output: Encoded string is sent over network, then decoded back to ["Hello", "World"]
```

**Example 2:**
```
Input: [""]
Output: Encoded string is sent over network, then decoded back to [""]
```

**Example 3:**
```
Input: []
Output: Encoded string is sent over network, then decoded back to []
```

## Constraints
- The string may contain any possible characters out of 256 valid ASCII characters.
- The algorithm should be stateless, meaning no state like a table can be used in encoding/decoding process.

## Solution Approach
This solution uses a delimiter approach to encode and decode strings:
- When encoding, joins the strings with a special delimiter character
- Handles empty strings by replacing them with a special character
- When decoding, splits the string by the delimiter and restores any empty strings
- Time Complexity: O(n) where n is the total length of all strings
- Space Complexity: O(n) for storing the encoded/decoded results