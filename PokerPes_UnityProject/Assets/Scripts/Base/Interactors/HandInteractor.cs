using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;
using System.Text;

public class HandInteractor : IInteractor
{
    private readonly List<Card> cards = new List<Card>();

    public IEnumerable<Card> Cards { get { return cards; } }

    public Card popCard()
    {
        throw new NotImplementedException();
    }

    public List<Card> popCards(int number)
    {
        throw new NotImplementedException();
    }

    public void pushCard(Card card)
    {
        cards.Add(card);
    }

    public List<Card> RandomizeData()
    {
        throw new NotImplementedException();
    }

    public void removeAllCards()
    {
        cards.Clear();
    }

    public void removeCard(Card card)
    {
        cards.Remove(card);
    }
}
