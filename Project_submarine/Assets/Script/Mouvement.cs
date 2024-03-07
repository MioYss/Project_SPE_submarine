using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float speed, rotate_speed, height_jump;

    private CharacterController controller;
 
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 forward = transform.forward;
        float cur_speed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * cur_speed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotate_speed, 0);

    }

}
