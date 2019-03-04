using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabModel : MonoBehaviour {

    public CardValue Value;
    public CardSuit Suit;

    public Sprite GetSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
}
