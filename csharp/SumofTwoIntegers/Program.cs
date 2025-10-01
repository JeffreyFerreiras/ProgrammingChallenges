using System;

// Given two integers a and b, return the sum of the two integers without using the operators +and -.
// Example 1:

// Input: a = 1, b = 2
// Output: 3
// Example 2:

// Input: a = 2, b = 3
// Output: 5



// Constraints:

// -1000 <= a, b <= 1000

var result = GetSum(1, 2);
Console.WriteLine($"1 + 2 :" + result);

var result2 = GetSum(2, 3);
Console.WriteLine($"2 + 3 :" + result2);

static int GetSum(int a, int b)
{
    int result = 0,

    carry = a & b; // carry now contains common set bits of "a" and "b"

    if (Convert.ToBoolean(carry))
    {
        // Sum of bits of "a" and "b" where at least one 
        // of the bits is not set
        result = a ^ b;

        // carry is shifted by one so that adding it 
        // to "a" gives the required sum
        carry = carry << 1;

        result = GetSum(carry, result);
    }
    else
    {
        result = a ^ b; // XOR is the sum of two bits
    }

    return result;
}