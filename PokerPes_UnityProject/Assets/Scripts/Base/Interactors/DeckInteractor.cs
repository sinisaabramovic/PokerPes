﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;
using System.Text;

public class DeckInteractor : IInteractor
{
    private readonly DataCollection dataCollection = new DataCollection();
    private List<Card> cards = new List<Card>();

    public IEnumerable<Card> Cards { get { return cards; } }

    public DeckInteractor()
    {
        cards = dataCollection.Data();
    }

    public List<Card> RandomizeData()
    {
        return Fisher_Yates_CardDeck_Shuffle();
    }

    private List<Card> Fisher_Yates_CardDeck_Shuffle()
    {

        System.Random _random = new System.Random();

        Card myCard;

        int n = cards.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            myCard = cards[r];
            cards[r] = cards[i];
            cards[i] = myCard;
        }

        return cards;
    }

    public Card popCard()
    {
        if (cards.Count() <= 0) return null;

        Card card = cards.Last();
        cards.Remove(card);

        return card;
    }

    public void pushCard(Card card)
    {
        throw new NotImplementedException();
    }

    public List<Card> popCards(int number)
    {
        if (cards.Count() < number && number > 0) return null;

        List<Card> throwableCards = new List<Card>();

        for (int i = 0; i < number; i++)
        {
            throwableCards.Add(popCard());
        }

        return throwableCards;
    }

    public void removeCard(Card card)
    {
        throw new NotImplementedException();
    }

    public void removeAllCards()
    {
        throw new NotImplementedException();
    }
}
