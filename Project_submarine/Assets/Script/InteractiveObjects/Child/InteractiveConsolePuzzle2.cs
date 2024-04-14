using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InteractiveConsolePuzzle2 : Interactable
{
    public bool on_Console = false ;
    public GameObject canvas_Puzzle_2;
    public GameObject CANVACHIANT;

    public Camera camera_Main;
    public Camera camera_Focus_Console;

    void Start()
    {
        camera_Focus_Console.GetComponent<Camera>().enabled = false;
        canvas_Puzzle_2.gameObject.SetActive(false);

        CANVACHIANT.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if (on_Console == false)
        {
            Debug.Log("affdzkomfrmljkrzfamlkgre");

            on_Console = true;
            canvas_Puzzle_2.gameObject.SetActive(true);
            camera_Focus_Console.GetComponent<Camera>().enabled = true;
            camera_Main.GetComponent<Camera>().enabled = false;

        }
        else
        {
            on_Console = false;
            canvas_Puzzle_2.gameObject.SetActive(false);
            camera_Focus_Console.enabled = false;
            camera_Main.enabled = true;

        }
    }


}
