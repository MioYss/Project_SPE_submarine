using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class Mouvement : MonoBehaviour
{
    public float speed, height_jump;

    private CharacterManager character_manager;

    private CharacterController controller;
 
    void Start()
    {
        character_manager = GetComponent<CharacterManager>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        var forward = transform.forward;
        var right = transform.right;

        float fwd_speed = speed * Input.GetAxisRaw("Vertical");
        float lateral_speed = speed * Input.GetAxisRaw("Horizontal");

        controller.SimpleMove((forward * fwd_speed) + (right * lateral_speed));

        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
}
