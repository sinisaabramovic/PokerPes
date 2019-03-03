using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class Score_Test {

    [Test]
    public void Score_TestSimplePasses() {
        // Use the Assert class to test conditions.

        //Deck deck = new Deck();
        Hand hand = new Hand();

        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));

        Score.SharedInstance.ResetScore();
        //Debug.Log(Score.SharedInstance.ToString());
        Assert.AreEqual(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()), Score.SharedInstance.GetScoreInfoForARank(HandRank.Pair));

    }

    [Test]
    public void ScoreTwoPairs()
    {
        // Use the Assert class to test conditions.

        //Deck deck = new Deck();
        Hand hand = new Hand();

        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));

        Score.SharedInstance.ResetScore();
        //Debug.Log(Score.SharedInstance.ToString());
        Assert.AreEqual(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()), Score.SharedInstance.GetScoreInfoForARank(HandRank.TwoPair));

    }

    [Test]
    public void ScoreThreeOfAKind()
    {
        // Use the Assert class to test conditions.

        //Deck deck = new Deck();
        Hand hand = new Hand();

        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Two, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));

        Score.SharedInstance.ResetScore();
        //Debug.Log(Score.SharedInstance.ToString());
        Assert.AreEqual(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()), Score.SharedInstance.GetScoreInfoForARank(HandRank.ThreeOfAKind));

    }

    [Test]
    public void ScoreFourOfAKind()
    {
        // Use the Assert class to test conditions.

        //Deck deck = new Deck();
        Hand hand = new Hand();

        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Two, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Diamonds));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));

        Score.SharedInstance.ResetScore();
        //Debug.Log(Score.SharedInstance.ToString());
        Assert.AreEqual(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()), Score.SharedInstance.GetScoreInfoForARank(HandRank.FourOfAKind));

    }

    [Test]
    public void ScoreStraight()
    {
        // Use the Assert class to test conditions.

        //Deck deck = new Deck();
        Hand hand = new Hand();

        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Diamonds));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

        Score.SharedInstance.ResetScore();
        //Debug.Log(Score.SharedInstance.ToString());
        Assert.AreEqual(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()), Score.SharedInstance.GetScoreInfoForARank(HandRank.Straight));

    }

    [Test]
    public void ScoreMultipleSessions()
    {

        Hand hand = new Hand();
        Score.SharedInstance.ResetScore();

        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Diamonds));
        hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

        Score.SharedInstance.SetMultiplierForBetAmmount(2);

        Score.SharedInstance.SetScore(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()));
        int score_1 = Score.SharedInstance.GetScoreInfoForARank(HandRank.Straight);
        Debug.Log(Score.SharedInstance.ToString());
        hand.RemoveAllCardsFromHand();

        hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
        hand.Draw(new Card(CardValue.Jack, CardSuit.Clubs));
        hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));

        Score.SharedInstance.SetMultiplierForBetAmmount(5);

        Score.SharedInstance.SetScore(Score.SharedInstance.GetScoreInfoForARank(hand.GetHandRank()));
        int score_2 = Score.SharedInstance.GetScoreInfoForARank(HandRank.TwoPair);
        Debug.Log(Score.SharedInstance.ToString());

        Assert.AreEqual(Score.SharedInstance.GetCurrentScore(), score_1 + score_2);

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator Score_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
