using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTube : Interactable
{
    public override void Interact()
    {
        transform.Rotate(0, 0, 90f);
    }
}
