using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;

public class Deck : IDeck
{

    private readonly DeckInteractor interactor;
    // to ensure imutability 

    public DeckInteractor Interactor { get { return interactor; } }

    public IEnumerable<Card> Cards { get { return interactor.Cards; } }

    public Deck()
    {
        interactor = new DeckInteractor();
        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        interactor.RandomizeData();
    }

    public Card ThrowCard()
    {
        return interactor.popCard();
    }

    public List<Card> ThrowCards(int numberOfCards)
    {   
        return interactor.popCards(numberOfCards);
    }

}
