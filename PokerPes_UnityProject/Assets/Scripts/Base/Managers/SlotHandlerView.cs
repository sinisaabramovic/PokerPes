using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandlerView : MonoBehaviour
{

    // Use this for initialization
    public int slotId;
    private SlotHandlerPresenter slotHandlerPresenter;

    private void Awake()
    {
        slotHandlerPresenter = new SlotHandlerPresenter();
        slotHandlerPresenter.transform = this.transform;
    }

    private void OnMouseDown()
    {
        if(slotHandlerPresenter.slotState == SlotFaceState.FaceUp)
        {
            //UpCard();
            if (slotHandlerPresenter.slotPickState == SlotPickState.PickedForThrow)
            {
                this.transform.position = slotHandlerPresenter.UpCard();
                return;
            }

            this.transform.position = slotHandlerPresenter.ResetSlot();
        }

    }
     
    public void SetSlotState(SlotFaceState slotFaceState)
    {
        slotHandlerPresenter.slotState = slotFaceState;
    }

    public void ResetSlot()
    {
        this.transform.position = slotHandlerPresenter.ResetSlot();
    }

    public SlotPickState GetSlotPickState()
    {
        return slotHandlerPresenter.slotPickState;
    }
}
