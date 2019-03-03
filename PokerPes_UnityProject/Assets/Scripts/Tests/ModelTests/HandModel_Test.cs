using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class HandModel_Test {

    [Test]
    public void HandModel_TestSimplePasses() {
        // Use the Assert class to test conditions.
        Hand hand = new Hand();
        Assert.False(hand.HandInteractor.Cards.Any());
    }

    [Test]
    public void HandModel_CanDrawAAcard()
    {
        Card card = new Card(CardValue.Ace, CardSuit.Spades);
        Hand hand = new Hand();

        hand.Draw(card);

        Card cardDump = new Card(CardValue.Eight, CardSuit.Spades);

        Assert.AreEqual(hand.HandInteractor.Cards.First(), card);
    }

    [Test]
    public void IsCardDuplicates()
    {
        Hand hand = new Hand();
        int expectedCount = 5;

        hand.Draw(new Card(CardValue.Seven, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Two, CardSuit.Clubs));
        // This a duplicates
        hand.Draw(new Card(CardValue.Two, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));

        Assert.AreEqual(hand.HandInteractor.Cards.Distinct().Count(), expectedCount);
    }

    [Test]
    public void CanGetHighCard()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Seven, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Two, CardSuit.Clubs));

        Assert.AreEqual(CardValue.King, hand.HighCard().Value);
    }

    [Test]
    public void CanScoreAFlush()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Seven, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

        Assert.AreEqual(HandRank.Flush, hand.GetHandRank());
    }

    [Test]
    public void CanScoreARoyalFlush()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Hearts));

        Assert.AreEqual(HandRank.RoyalFlush, hand.GetHandRank());
    }

    [Test]
    public void CanScorePair()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));

        Assert.AreEqual(HandRank.Pair, hand.GetHandRank());
    }

    [Test]
    public void CanScoreThree()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Hearts));

        Assert.AreEqual(HandRank.ThreeOfAKind, hand.GetHandRank());
    }

    [Test]
    public void CanScoreFour()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Diamonds));

        Assert.AreEqual(HandRank.FourOfAKind, hand.GetHandRank());
    }

    [Test]
    public void CanScoreFulHouse()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Diamonds));

        Assert.AreEqual(HandRank.FullHouse, hand.GetHandRank());
    }

    [Test]
    public void CanScoreTwoPairs()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Diamonds));

        Assert.AreEqual(HandRank.TwoPair, hand.GetHandRank());
    }

    [Test]
    public void CanScoreStraight()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Diamonds));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

        Assert.AreEqual(HandRank.Straight, hand.GetHandRank());
    }

    [Test]
    public void CanScoreStraightFlush()
    {
        Hand hand = new Hand();
        hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Eight, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Six, CardSuit.Spades));
        hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));

        Assert.AreEqual(HandRank.StraightFlush, hand.GetHandRank());
    }


    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator HandModel_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
