using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHandlerPresenter : ISlotHandler 
{
    private SlotFaceState _slotFaceState;
    private SlotPickState _slotPickState;
    private Transform _transform;

    public SlotFaceState slotState { get { return _slotFaceState; }  set { _slotFaceState = value; } }
    public SlotPickState slotPickState { get { return _slotPickState; } set { _slotPickState = value; } }
    public Transform transform { get { return _transform; }  set { _transform = value; } }

    public Vector3 ResetSlot()
    {
        _slotPickState = SlotPickState.PickedForThrow;
        return new Vector3(_transform.localPosition.x, -0.78f, _transform.localPosition.z);
    }

    public Vector3 UpCard()
    {
        _slotPickState = SlotPickState.PickedForStay;
        return new Vector3(_transform.localPosition.x, -0.2f, _transform.localPosition.z);
    }


}
