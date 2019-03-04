using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard 
{
    bool isEqual(Card card);
    Sprite GetSprite();
    string ToString();

}
