# Shuffle Deck of Cards

## Problem Description
Implement a deck of playing cards and a shuffling algorithm that randomly reorders the cards.

## Implementation Details
This project implements:
1. A `Card` class representing a playing card with a face (suit) and value
2. A `Deck` class containing a collection of 52 standard playing cards
3. A shuffling algorithm that randomly reorders the cards in the deck

## Features
- **Card Class**: Represents a playing card with a face (Hearts, Clubs, Diamonds, Spades) and value (Ace through King)
- **Deck Class**: Creates and manages a standard deck of 52 playing cards
- **Shuffle Method**: Implements a random shuffling algorithm
- **Thread-Safe Random**: Uses a synchronized random number generator for thread safety

## Solution Approach
The solution uses these key techniques:
- Object-oriented design to model cards and deck
- Enums to represent card faces and values
- Random number generation for shuffling
- Multiple shuffle passes (recursion) to ensure thorough randomization
- Fisher-Yates style swap implementation
- Time Complexity: O(n) where n is the number of cards in the deck
- Space Complexity: O(1) for the shuffling operation as it's done in-place