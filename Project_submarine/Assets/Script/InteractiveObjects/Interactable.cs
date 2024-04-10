using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    protected CharacterManager character_manager;

    private void Start()
    {
        character_manager = FindObjectOfType<CharacterManager>();
    }

    public virtual void Interact()
    {

    }
}
