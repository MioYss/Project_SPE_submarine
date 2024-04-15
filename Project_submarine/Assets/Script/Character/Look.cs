using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private LayerMask layer_mask;

    private CharacterManager character_manager;

    private Interactable interact;

    public float ray_distance = 10;

    Ray ray;

    private void Start()
    {
        character_manager = GetComponent<CharacterManager>();
    }

    private void Update(){
        Debug.DrawLine(character_manager.Camera_transform.position, character_manager.Camera_transform.position+character_manager.Camera_transform.forward*ray_distance, Color.red);
        if(Physics.Raycast(character_manager.Camera_transform.position, character_manager.Camera_transform.forward, out var hit, ray_distance, layer_mask)){
            // executer le code
            Debug.Log(hit.transform.name);

            interact = hit.transform.GetComponent<Interactable>();

            On_Raycast();
        }
    }

    public void On_Raycast()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact.Interact();
        }

    }
}
