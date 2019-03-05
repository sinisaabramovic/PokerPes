using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IGameManager 
{
    List<int> indexHandler = new List<int>();
    Dictionary<int, Card> slotIndexHandler = new Dictionary<int, Card>();
    Hand hand = new Hand();

    public Text scoreText;

    public List<SpriteRenderer> slots;
    private bool firstRun = true;
    
    public void DrawCards()
    {
        InitializeCards();
        DisplayCards();
        scoreText.text = hand.GetHandRank().ToString();
        //InitializeCards();
    }

    public void ResetStates()
    {
        InitializeCards();
        DisplayCards();
        scoreText.text = "DRAW";
    }

    private void Awake()
    {
        InitializeCards();
    }

    private void InitializeCards()
    {
        Deck deck = new Deck();

        //hand.RemoveAllCardsFromHand();
        RemoveCardsFromHand();
        deck.Interactor.RandomizeData();

        hand.ClaimForCards((count) =>
        {
            List<Card> cards = new List<Card>();
            Debug.Log("CARDS TO REPLEACE = " + count);
            cards = deck.ThrowCards(count);

            if (firstRun)
            {
                foreach (Card card in cards)
                {
                    hand.Draw(card);
                }
                firstRun = false;
                return;
            }

            int cardIndex = 0;
            foreach(int i in indexHandler)
            {
                //Debug.Log("CALL FOR : " + i);
                hand.SwapCardAtIndex(cards[cardIndex], i);
                cardIndex++;
            }

            Debug.Log(hand.ToString());

        }, indexHandler.Count());
    }


    private void RemoveCardsFromHand()
    {
        indexHandler.Clear();

        for (int i = 0; i < 5; i++)
        {

            if (slots[i].GetComponent<SlotHandler>().GetSlotPickState() == SlotPickState.PickedForThrow)
            {
                indexHandler.Add(i);
            }
        }
    }

    private void DisplayCards()
    {
        for (int i = 0; i < 5; i++)
        {
            slots[i].GetComponent<SlotHandler>().SetSlotState(SlotFaceState.FaceUp);
            slots[i].GetComponent<SlotHandler>().ResetSlot();
            //slots[i].GetComponent<SlotHandler>().SetSlotPickState(SlotPickState.PickedForThrow);
            slots[i].sprite = hand.HandInteractor.Cards.ToList()[i].GetSprite();
        }
        Debug.Log(hand.ToString());
    }
}
