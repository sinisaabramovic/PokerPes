using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Realtime.Messaging.Internal;
using System.Text;

public class Hand : IHand
{
    //private readonly List<Card> cards = new List<Card>();
    private HandInteractor handInteractor;
    public HandInteractor HandInteractor { get { return handInteractor; } }

    #region Public methods

    public Hand()
    {
        handInteractor = new HandInteractor();
    }

    public HandRank GetHandRank()
    {
        // return early
        if (HasRoyalFlush()) return HandRank.RoyalFlush;
        if (HasStraightFlush()) return HandRank.StraightFlush;
        if (HasFourOfAKind()) return HandRank.FourOfAKind;
        if (HasFullHouse()) return HandRank.FullHouse;
        if (HasFlush()) return HandRank.Flush;
        if (HasStraight()) return HandRank.Straight;
        if (HasThreeOfAKind()) return HandRank.ThreeOfAKind;
        if (HasTwoPairs()) return HandRank.TwoPair;
        if (HasPair()) return HandRank.Pair;

        return HandRank.HighCard;
    }

    public string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach(Card card in handInteractor.Cards.ToList())
        {
            sb.Append(" | " + card.ToString() + " | ");
        }

        return sb.ToString();
    }

    public void Draw(Card card)
    {
        if (isCardInList(card)) return;
        handInteractor.pushCard(card);
    }

    // higher order function 
    public void ClaimForCards(Action<int>claim, int numberOfCards = 1)
    {
        if (claim == null) return;
        claim(numberOfCards);
    }

    public void RemoveCardFromHand(Card card)
    {
        //if (cards.Count <= 0) return;
        //cards.Remove(card);
        if (handInteractor.Cards.Count() <= 0) return;
        handInteractor.removeCard(card);
    }

    public void RemoveAllCardsFromHand()
    {
        //cards.Clear();
        handInteractor.removeAllCards();
    }

    public Card HighCard()
    {
        return handInteractor.Cards.Aggregate((highCard, nextCard) => {
            return nextCard.Value > highCard.Value ? nextCard : highCard;
        });
    }

    #endregion

    #region state conditions methods
    private bool HasFlush()
    {
        return handInteractor.Cards.All((c) => {
            return handInteractor.Cards.First().Suit == c.Suit;
        });
    }

    private bool HasRoyalFlush()
    {
        return HasFlush() && handInteractor.Cards.All((c) => {
            return c.Value > CardValue.Nine;
        });
    }

    private bool HasPair()
    {
        return HasOfAKind(2);
    }

    private bool HasTwoPairs()
    {
       
        return GetTwoPairKindAndQuantites();
    }

    private bool HasThreeOfAKind()
    {
        return HasOfAKind(3);
    }

    private bool HasFourOfAKind()
    {
        return HasOfAKind(4);
    }

    private bool HasFullHouse()
    {
        return HasThreeOfAKind() && HasPair();
    }

    private bool HasOfAKind(int num)
    {
        return GetKindAndQuantites(handInteractor.Cards).Any(c => c.Value == num);
    }

    private bool HasStraightFlush()
    {
        return HasStraight() && HasFlush();
    }
    #endregion

    #region Compare methods
    private bool isCardInList(Card card)
    {
        foreach(Card cardModel in handInteractor.Cards)
        {
            if (cardModel.isEqual(card))
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerable<KeyValuePair<CardValue, int>> GetKindAndQuantites(IEnumerable<Card> cards)
    {
        var dict = new ConcurrentDictionary<CardValue, int>();

        foreach(var card in cards)
        {
            dict.AddOrUpdate(card.Value, 1, (cardValue, quantity) => ++quantity);
        }

        return dict;
    }

    private bool GetTwoPairKindAndQuantites()
    {

        return handInteractor.Cards.GroupBy(card => card.Value)
                      .Count(group => group.Count() >= 2) == 2;

    }

    private bool HasStraight()
    {
        return handInteractor.Cards.OrderBy(card => card.Value)
                .Zip(handInteractor.Cards.OrderBy(card => card.Value).Skip(1), (n, next) => n.Value + 1 == next.Value)
                .All(value => value /* true */ );
    }
    #endregion
}
