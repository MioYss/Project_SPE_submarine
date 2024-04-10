using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : Interactable
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    public Placement_1 placement_var;
    public string feur = "feur";
    public override void Interact()
    {
        
        // Disable rigidbody and reset velocities
        Rb.isKinematic = true;
        
        // Set Slot as a parent
        transform.SetParent(character_manager.grabManager.slot);
        
        // Reset position and rotation
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;

        character_manager.grabManager.SetPickable (this);

        GetComponent<Rotation_Pick>().enabled = true;


        //permet de récupérer le pickable object dans les scripts placements
        placement_var.change_Current_Game_Object(this.gameObject);
    }

    public void Drop()
    {
        GetComponent<Rotation_Pick>().enabled = false;
        //transform.rotation = Quaternion.identity;
        transform.SetParent(null);
        Rb.isKinematic = false;
        Debug.Log("je passe par le drop");

        //permet de le retirer des scripts placements
        placement_var.null_Current_Game_Object();
    }

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }
}
