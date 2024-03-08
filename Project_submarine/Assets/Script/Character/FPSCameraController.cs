using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] private bool confine_cursor = true;
    [SerializeField] private float min_rot_angle = -80, max_rot_angle = 80;

    private CharacterManager character_manager;

    private Vector3 lateral_rotation = Vector3.zero;

    private void Start()
    {
        character_manager = GetComponent<CharacterManager>();

        if(confine_cursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        lateral_rotation.x += Input.GetAxis("Mouse Y");
        lateral_rotation.x = Mathf.Clamp(lateral_rotation.x, min_rot_angle, max_rot_angle);

        character_manager.Camera_transform.localRotation = Quaternion.Euler(lateral_rotation);
    }
}
