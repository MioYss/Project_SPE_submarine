using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField]
    public Transform slot;
    // Reference to the currently held item.
    private Pickable pickedItem;

    public Rotation_Pick rotation_pick;

    public void SetPickable( Pickable newPïckable)
    {
        pickedItem = newPïckable;
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

    public Pickable is_Someone_In_Hand()
    {
        if(pickedItem != null)
        {
            return pickedItem;
        }
        return pickedItem;
    }
}
