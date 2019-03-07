using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public enum ManagerState
{
    CanDraw = 0,
    CantDraw = 1,
}

public class GameManager : MonoBehaviour, IGameManager 
{

    public ManagerState managerState = ManagerState.CantDraw;
    public TextMesh textMesh;
    public List<SlotHandlerView> slots;

    private float timeWaitToDraw = 1.5f;
    private List<int> indexHandler = new List<int>();
    private Hand hand = new Hand();
    private bool firstRun = true;

    private int callCounter = 0;

    #region MonoBehave methods

    private void Start()
    {
        InitializeCards();
        StartCoroutine(CallDrawCardsWithDelay(timeWaitToDraw));
    }
    #endregion

    #region Public Methods

    public void DrawCards()
    {
        InitializeCards();
        DisplayCardsForPlay();

        StartCoroutine(CallForDrawWithDelay(2.0f));      
    }

    #endregion

    #region Private methods

    private IEnumerator CallForDrawWithDelay(float delay)
    {
        DisplayTexts(hand.GetHandRank().ToString());
        managerState = ManagerState.CantDraw;

        yield return new WaitForSeconds(delay);

        callCounter++;

        if (callCounter >= 2)
        {
            StartCoroutine(CallDrawCardsWithDelay(timeWaitToDraw));
        }
    }


    IEnumerator CallDrawCardsWithDelay(float delay)
    {
        DisplayTexts("DEALING!!!!");
        DisplayCardsBeforePlay();

        yield return new WaitForSeconds(delay);

        callCounter = 0;
        ResetStates();
    }

    private void ResetStates()
    {
        InitializeCards();
        DisplayCardsForPlay();
        callCounter++;
        managerState = ManagerState.CanDraw;
        DisplayTexts("HOLD CARDS");
    }

    private void InitializeCards()
    {
        Deck deck = new Deck();

        RemoveCardsFromHand();

        deck.Interactor.RandomizeData();

        hand.ClaimForCards((count) => { CollectCardsToHand(count, deck);  }, indexHandler.Count());
    }

    private void CollectCardsToHand(int count, Deck deck)
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
        foreach (int i in indexHandler)
        {
            hand.SwapCardAtIndex(cards[cardIndex], i);
            cardIndex++;
        }
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

    private void DisplayCardsForPlay()
    {
        for (int i = 0; i < 5; i++)
        {
            slots[i].SetSlotState(SlotFaceState.FaceUp);
            slots[i].ResetSlot();
            slots[i].GetComponent<SpriteRenderer>().sprite = hand.HandInteractor.Cards.ToList()[i].GetSprite();
        }
    }

    private void DisplayCardsBeforePlay()
    {
    
        for (int i = 0; i < 5; i++)
        {
            slots[i].SetSlotState(SlotFaceState.FaceDown);
            slots[i].GetComponent<SpriteRenderer>().sprite = slots[i].defaultBackSprite;
        }             
    }

    private void DisplayTexts(string text)
    {
        textMesh.text = text;
    }

    #endregion
}
