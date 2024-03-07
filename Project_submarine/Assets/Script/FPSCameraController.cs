using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] private bool confine_cursor = true;

    private CharacterManager character_manager;

    private void Start()
    {
        character_manager = GetComponent<CharacterManager>();

        if(confine_cursor )
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        character_manager.Camera_transform.Rotate(Input.GetAxis("Mouse Y"), 0, 0);
    }
}
