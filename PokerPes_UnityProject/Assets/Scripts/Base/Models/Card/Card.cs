using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Card : ICard 
{
    // only expose getter to ensure immutability
    public CardValue Value { get; }
    public CardSuit Suit { get; }

    public Card(CardValue value, CardSuit suit)
    {
        Value = value;
        Suit = suit;
    }

    public bool isEqual(Card card)
    {
        return Value == card.Value && Suit == card.Suit;
    }

    public override string ToString() => $"{Value} of {Suit}";

}
