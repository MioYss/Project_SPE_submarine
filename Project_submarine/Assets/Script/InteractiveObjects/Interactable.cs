using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    private CharacterManager character_manager;

    private void Start()
    {
        character_manager = GetComponent<CharacterManager>();
    }

    public virtual void Interact()
    {

    }
}
