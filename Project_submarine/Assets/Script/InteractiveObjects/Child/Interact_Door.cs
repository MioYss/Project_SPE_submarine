using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Door : Interactable
{
    public override void Interact()
    {
        transform.eulerAngles = -Vector3.forward*90;
    }
}
