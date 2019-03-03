using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;
using System.Text;

public interface IInteractor  
{

    IEnumerable<Card> Cards { get; }
    List<Card> RandomizeData();
    Card popCard();
    void removeCard(Card card);
    void removeAllCards();
    List<Card> popCards(int number);
    void pushCard(Card card);

}
