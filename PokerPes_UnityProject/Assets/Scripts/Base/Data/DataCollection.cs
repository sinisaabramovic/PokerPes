using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollection : IDataCollection
{
    private const string Path = "Cards";
    private GameObject[] prefabModels;

    public DataCollection()
    {
        prefabModels = Resources.LoadAll<GameObject>(Path);
        //Debug.Log("ALL SPRITES = " + prefabModels.Length);
    }

    public List<Card> Data()
    {
        List<Card> cards = new List<Card>();

        foreach(GameObject gameObject in prefabModels)
        {
            if(gameObject.GetComponent<PrefabModel>() != null)
            {
                cards.Add(new Card(gameObject.GetComponent<PrefabModel>().Value,
                                   gameObject.GetComponent<PrefabModel>().Suit,
                                   gameObject.GetComponent<PrefabModel>().GetSprite()));
            }
        }

        //cards.Add(new Card(CardValue.Two, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Three, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Four, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Five, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Six, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Seven, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Eight, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Nine, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Ten, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Jack, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Queen, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.King, CardSuit.Clubs));
        //cards.Add(new Card(CardValue.Ace, CardSuit.Clubs));
        //// Set of Diamonds
        //cards.Add(new Card(CardValue.Two, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Three, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Four, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Five, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Six, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Seven, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Eight, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Nine, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Ten, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Jack, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Queen, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.King, CardSuit.Diamonds));
        //cards.Add(new Card(CardValue.Ace, CardSuit.Diamonds));
        //// Set of Hearts
        //cards.Add(new Card(CardValue.Two, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Three, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Four, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Five, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Six, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Seven, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Eight, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Nine, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Ten, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Jack, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Queen, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.King, CardSuit.Hearts));
        //cards.Add(new Card(CardValue.Ace, CardSuit.Hearts));
        //// Set of Spades
        //cards.Add(new Card(CardValue.Two, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Three, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Four, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Five, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Six, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Seven, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Eight, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Nine, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Ten, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Jack, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Queen, CardSuit.Spades));
        //cards.Add(new Card(CardValue.King, CardSuit.Spades));
        //cards.Add(new Card(CardValue.Ace, CardSuit.Spades));

        return cards;
    }
}
