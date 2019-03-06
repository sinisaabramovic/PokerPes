using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IGameManager 
{
    List<int> indexHandler = new List<int>();
    Hand hand = new Hand();

    //public Text scoreText;
    public TextMesh textMesh;

    public List<SlotHandlerView> slots;
    private bool firstRun = true;
    
    public void DrawCards()
    {
        Debug.Log("CALLED!");
        InitializeCards();
        DisplayCards();
        //scoreText.text = hand.GetHandRank().ToString();
        textMesh.text = hand.GetHandRank().ToString();
    }

    public void ResetStates()
    {
        InitializeCards();
        DisplayCards();
        //scoreText.text = "DRAW";
        textMesh.text = "DRAW";
    }

    private void Start()
    {
        InitializeCards();
    }

    private void InitializeCards()
    {
        Deck deck = new Deck();

        RemoveCardsFromHand();

        deck.Interactor.RandomizeData();

        hand.ClaimForCards((count) =>
        {
            List<Card> cards = new List<Card>();
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
                hand.SwapCardAtIndex(cards[cardIndex], i);
                cardIndex++;
            }
            
        }, indexHandler.Count());
    }


    private void RemoveCardsFromHand()
    {
        indexHandler.Clear();

        for (int i = 0; i < 5; i++)
        {
            if (slots[i].GetSlotPickState() == SlotPickState.PickedForThrow)
            {
                indexHandler.Add(i);
            }
        }
    }

    private void DisplayCards()
    {
        for (int i = 0; i < 5; i++)
        {
            slots[i].SetSlotState(SlotFaceState.FaceUp);
            slots[i].ResetSlot();
            slots[i].GetComponent<SpriteRenderer>().sprite = hand.HandInteractor.Cards.ToList()[i].GetSprite();
        }
    }
}
