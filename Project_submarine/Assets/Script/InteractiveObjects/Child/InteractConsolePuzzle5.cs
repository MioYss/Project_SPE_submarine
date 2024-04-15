using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractConsolePuzzle5 : Interactable
{
    public bool on_Console = false;
    public GameObject canvas_Puzzle_5;

    public Camera camera_Main;
    public Camera camera_Focus_Console;
    public GameObject fps_Controller;


    void Start()
    {
        camera_Focus_Console.GetComponent<Camera>().enabled = false;
        canvas_Puzzle_5.gameObject.SetActive(false);

    }

    public override void Interact()
    {
        if (on_Console == false)
        {
            on_Console = true;
            canvas_Puzzle_5.gameObject.SetActive(true);
            camera_Focus_Console.GetComponent<Camera>().enabled = true;
            camera_Main.GetComponent<Camera>().enabled = false;
            fps_Controller.GetComponent<Mouvement>().enabled = false;


        }
        else
        {
            on_Console = false;
            canvas_Puzzle_5.gameObject.SetActive(false);
            camera_Focus_Console.enabled = false;
            camera_Main.enabled = true;
            fps_Controller.GetComponent<Mouvement>().enabled = true;


        }
    }
}
