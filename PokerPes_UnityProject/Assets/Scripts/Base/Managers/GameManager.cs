using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour, IGameManager 
{
    
    Hand hand = new Hand();

    public List<SpriteRenderer> slots;

    private void Awake()
    {
        DrawGet();
    }

    private void DrawGet()
    {
        Deck deck = new Deck();

        hand.RemoveAllCardsFromHand();
        deck.Interactor.RandomizeData();

        hand.ClaimForCards((count) =>
        {
            List<Card> cards = new List<Card>();
            cards = deck.ThrowCards(count);

            foreach (Card card in cards)
            {
                hand.Draw(card);
            }
        }, 5);
    }

    public void DrawCards()
    {
        DrawGet();
        DisplayCards();
        Debug.Log("DRAW!");
    }

    private void DisplayCards()
    {
        for (int i = 0; i < 5; i++)
        {
            slots[i].GetComponent<SlotHandler>().SetSlotState(SlotState.FaceUp);
            slots[i].GetComponent<SlotHandler>().ResetSlot();
            slots[i].sprite = hand.HandInteractor.Cards.ToList()[i].GetSprite();
        }
    }
}
