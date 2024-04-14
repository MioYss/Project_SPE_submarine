using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractValve : Interactable
{
    public bool on_Valve = false;
    public GameObject canvas_Puzzle_3;

    void Start()
    {
        canvas_Puzzle_3.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if (on_Valve == false)
        {
            on_Valve = true;
            canvas_Puzzle_3.SetActive(true);
        }
        else
        {
            on_Valve = false;
            canvas_Puzzle_3.SetActive(false);
        }
    }
}
