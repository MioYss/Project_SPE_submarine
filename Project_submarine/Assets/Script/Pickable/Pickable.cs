using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : Interactable
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    public Placement placement_var_1, placement_var_2, placement_var_3, placement_var_4, placement_var_5, placement_var_6;
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
        placement_var_1.change_Current_Game_Object(this.gameObject);
        placement_var_2.change_Current_Game_Object(this.gameObject);
        placement_var_3.change_Current_Game_Object(this.gameObject);
        placement_var_4.change_Current_Game_Object(this.gameObject);
        placement_var_5.change_Current_Game_Object(this.gameObject);
        placement_var_6.change_Current_Game_Object(this.gameObject);
    }

    public void Drop()
    {
        GetComponent<Rotation_Pick>().enabled = false;
        //transform.rotation = Quaternion.identity;
        transform.SetParent(null);
        Rb.isKinematic = false;
        Debug.Log("je passe par le drop");

        //permet de le retirer des scripts placements
        placement_var_1.null_Current_Game_Object();
        placement_var_2.null_Current_Game_Object();
        placement_var_3.null_Current_Game_Object();
        placement_var_4.null_Current_Game_Object();
        placement_var_5.null_Current_Game_Object();
        placement_var_6.null_Current_Game_Object();
    }

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }
}
