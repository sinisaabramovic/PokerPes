using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class DrawCardFromDeck_Test {

    [Test]
    public void DrawCardFromDeck_TestSimplePasses() {
        // Use the Assert class to test conditions.
        int numberOFClaimedCards = 5;
        Deck deck = new Deck();
        Hand hand = new Hand();

        WeakReference weakDeck = new WeakReference(deck, true);
        WeakReference weakHand = new WeakReference(hand, true);

        hand.ClaimForCards((count) => {
            // check is refrence alive
            if (!weakDeck.IsAlive || !weakHand.IsAlive) return;

            List<Card> cards = new List<Card>();
            cards = deck.ThrowCards(count);

            foreach(Card card in cards)
            {
                hand.Draw(card);
            }
            // TODO
            // This is wierd
            // for some reason GC doesnt collect this!?
            //hand = null;
        }, numberOFClaimedCards);

        GC.Collect();
        if (weakHand.IsAlive)
        {
            Debug.Log(hand.ToString());

            Assert.AreEqual(hand.HandInteractor.Cards.Count(), numberOFClaimedCards);
            return;
        }

        Assert.Fail("reference error!");
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DrawCardFromDeck_TestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
