using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField]
    public Transform slot;
    // Reference to the currently held item.
    private Pickable pickedItem;

    public void SetPickable( Pickable newP�ckable)
    {
        pickedItem = newP�ckable;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(pickedItem != null)
            {
                DropItem();
            }
        }
    }
    private void DropItem()
    {
        pickedItem.Drop();
        pickedItem = null;
    }
}