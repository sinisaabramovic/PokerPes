using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHandler : MonoBehaviour
{

    // Use this for initialization
    public int slotId;

    private void OnMouseDown()
    {
        Debug.Log("CLICK ON " + slotId);
        transform.localPosition = new Vector3(transform.localPosition.x, 2.0f, transform.localPosition.z);
    }
     
}
