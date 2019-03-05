using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

public class SlotHandler : MonoBehaviour
{

    // Use this for initialization
    public int slotId;
    private SlotFaceState slotState = SlotFaceState.FaceDown;
    private SlotPickState slotPickState = SlotPickState.PickedForThrow;

    private void OnMouseDown()
    {
        if(slotState == SlotFaceState.FaceUp)
        {
            UpCard();
        }

    }

    public void UpCard()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 2.0f, transform.localPosition.z);
        SetSlotPickState(SlotPickState.PickedForStay);
    }

    public void ResetSlot()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 1.6f, transform.localPosition.z);
        //SetSlotPickState(SlotPickState.PickedForThrow);
    }

    public SlotFaceState GetSlotState()
    {
        return slotState;
    }

    public void SetSlotState(SlotFaceState slotState)
    {
        this.slotState = slotState;
    }

    public SlotPickState GetSlotPickState()
    {
        return slotPickState;
    }

    public void SetSlotPickState(SlotPickState slotPickState)
    {
        this.slotPickState = slotPickState;
    }

}
