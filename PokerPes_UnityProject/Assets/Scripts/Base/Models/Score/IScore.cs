using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore 
{
    int GetScoreInfoForARank(HandRank forRank);
    void SetScore(int value);
    int GetCurrentScore();
    void ResetScore();
    bool SetMultiplierForBetAmmount(int betAmmountValue);
    string ToString();
}
