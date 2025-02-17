# Decode Ways Coding Challenge

This challenge is focused on decoding a numeric message into possible letter combinations.

## Overview
- Given an encoded message containing digits, determine the total number of ways to decode it.
- The decoding follows a mapping where 'A' -> 1, 'B' -> 2, ..., 'Z' -> 26.
- Handle cases with leading zeros appropriately.

## Challenge Description
You have intercepted a secret message encoded as a string of numbers. The message is decoded via the following mapping:

- "1" -> 'A'
- "2" -> 'B'
- ...
- "26" -> 'Z'

However, while decoding the message, note that there are several ways to decode it because some codes are contained in other codes (e.g., "2" and "5" vs "25"). For example, "11106" can be decoded into:
- "AAJF" with the grouping (1, 1, 10, 6)
- "KJF" with the grouping (11, 10, 6)

Note: Groupings that produce codes with leading zero(s) (e.g., "06") are invalid. If the entire string cannot be decoded in any valid way, return 0. The answer fits in a 32-bit integer.

### Examples:
- Input: s = "12"  
  Output: 2  
  Explanation: "12" can be decoded as "AB" (1 2) or "L" (12).

- Input: s = "226"  
  Output: 3  
  Explanation: "226" can be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

- Input: s = "06"  
  Output: 0  
  Explanation: "06" cannot be mapped due to the leading zero.

## Instructions
- Implement your solution in `Program.cs` using a dynamic programming approach.
- Test your solution with various cases.