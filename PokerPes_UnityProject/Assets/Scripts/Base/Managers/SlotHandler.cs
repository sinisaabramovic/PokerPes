using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotState
{
    FaceDown = 0,
    FaceUp = 1
}

public class SlotHandler : MonoBehaviour
{

    // Use this for initialization
    public int slotId;
    private SlotState slotState = SlotState.FaceDown;

    private void OnMouseDown()
    {
        if(slotState == SlotState.FaceUp)
        {
            UpCard();
        }

    }

    public void UpCard()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 2.0f, transform.localPosition.z);
    }

    public void ResetSlot()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 1.6f, transform.localPosition.z);
    }

    public SlotState GetSlotState()
    {
        return slotState;
    }

    public void SetSlotState(SlotState slotState)
    {
        this.slotState = slotState;
    }

}
