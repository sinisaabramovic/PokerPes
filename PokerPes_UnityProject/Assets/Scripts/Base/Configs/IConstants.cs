using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConstants  
{
    int TotalNumberOfCardsInDeck
    {
        get;      
    }

    int MaximumNumberOfCardsInHand
    {
        get;
    }

    int MaximumBetAmount
    {
        get;
    }

    int MinumumBetAmount
    {
        get;
    }

    int ResetScoreValue
    {
        get;
    }

    int NullValue
    {
        get;
    }

    int BaseMultiplierValue
    {
        get;
    }
}
