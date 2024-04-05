using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : Interactable
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    public override void Interact()
    {
        
        // Disable rigidbody and reset velocities
        Rb.isKinematic = true;
        //Rb.velocity = Vector3.zero;
        //Rb.angularVelocity = Vector3.zero;
        
        // Set Slot as a parent
        transform.SetParent(character_manager.grabManager.slot);
        
        // Reset position and rotation
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;

        character_manager.grabManager.SetPickable (this);
    }

    public void Drop()
    {

        transform.SetParent(null);
        Rb.isKinematic = false;
        Rb.AddForce(transform.forward * 0, ForceMode.VelocityChange);
        Debug.Log("je passe par le drop");
    }

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Debug.Log(Rb.velocity);
    }
}
