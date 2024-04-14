using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractValve : Interactable
{
    public bool on_Valve = false;
    public GameObject canvas_Puzzle_3;

    public InteractMouse interact_Mouse;

    void Start()
    {
        canvas_Puzzle_3.gameObject.SetActive(false);
    }
    private void Update()
    {
        interact_Mouse.CancelMouse();
        Exit_Valve();
    }

    public override void Interact()
    {
        if (on_Valve == false)
        {
            on_Valve = true;
            canvas_Puzzle_3.SetActive(true);
            interact_Mouse.Interact();
        }
    }

    public void Exit_Valve()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            on_Valve = false;
            canvas_Puzzle_3.SetActive(false);
        }
    }
}
