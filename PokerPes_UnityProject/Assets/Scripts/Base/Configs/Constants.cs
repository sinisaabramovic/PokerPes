using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : IConstants  
{

    private static Constants sharedInstance = null;
    private static readonly object padlockInstance = new object();

    #region init
    private int totalNumberOfCardsInDeck = 52;
    private int maximumNumberOfCardsInHand = 5;
    private int maximumBetAmount = 5;
    private int minimumBetAmount = 1;
    private int resetScoreValue = 0;
    private int nullValue = 0;
    private int baseMultiplierValue = 1;
    #endregion
    public static Constants SharedInstance
    {
        get
        {
            lock (padlockInstance)
            {
                if (sharedInstance == null)
                {
                    sharedInstance = new Constants();
                }
            }
            return sharedInstance;
        }
    }

    public int TotalNumberOfCardsInDeck { get { return totalNumberOfCardsInDeck; } }  
    public int MaximumNumberOfCardsInHand { get { return maximumNumberOfCardsInHand; } }
    public int MaximumBetAmount { get { return maximumBetAmount; } }
    public int MinumumBetAmount { get { return minimumBetAmount; } }
    public int ResetScoreValue { get { return resetScoreValue; } }
    public int NullValue { get { return nullValue; } }
    public int BaseMultiplierValue { get { return baseMultiplierValue; } }

    private Constants() { }
}
