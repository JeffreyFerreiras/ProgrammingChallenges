﻿using System;

namespace ShuffleDeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new();
            deck.Display();
            Console.WriteLine();
            deck.Shuffle();
            deck.Display();
            Console.ReadLine();


        }
    }
}
