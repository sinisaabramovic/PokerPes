using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotFaceState
{
    FaceDown = 0,
    FaceUp = 1,

}

public enum SlotPickState
{
    PickedForThrow = 0,
    PickedForStay = 1,
}

public interface ISlotHandler  
{
    SlotFaceState slotState { get; set; }
    SlotPickState slotPickState { get; set; }
    Transform transform { get; set; }
    Vector3 UpCard();
    Vector3 ResetSlot();

}
