using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;

public interface IDeck 
{

    DeckInteractor Interactor { get; }
    IEnumerable<Card> Cards { get; }
    Card ThrowCard();
    List<Card> ThrowCards(int numberOfCards);
}
