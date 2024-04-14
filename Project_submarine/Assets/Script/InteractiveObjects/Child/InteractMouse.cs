using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMouse : Interactable
{
    public GameObject fps_controller;
    public GameObject fps_controller02;
    public override void Interact()
    {
        fps_controller.GetComponent<FPSCameraController>().enabled = false;
        fps_controller.GetComponent<Mouvement>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        CancelMouse();
    }
    public void CancelMouse()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            fps_controller.GetComponent<FPSCameraController>().enabled = true;
            fps_controller.GetComponent<Mouvement>().enabled = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
