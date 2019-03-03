using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;
using System.Text;

public interface IHand  
{
    HandRank GetHandRank();
    string ToString();
    void Draw(Card card);
    void ClaimForCards(Action<int> claim, int numberOfCards = 1);
    void RemoveCardFromHand(Card card);
    void RemoveAllCardsFromHand();
    Card HighCard();

}
