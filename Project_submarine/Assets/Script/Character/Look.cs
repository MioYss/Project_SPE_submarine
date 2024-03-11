using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private LayerMask layer_mask;

    private CharacterManager character_manager;

    private Interactable interact;

    public float Ray_distance;

    Ray ray;

    private void Start()
    {
        character_manager = GetComponent<CharacterManager>();
        ray = new Ray(character_manager.Camera_transform.position,character_manager.Camera_transform.forward);
    }

    private void Update(){
        if(Physics.Raycast(character_manager.Camera_transform.position, character_manager.Camera_transform.forward, out var hit, Ray_distance, layer_mask)){
            // executer le code
            Debug.DrawLine(hit.point, hit.point + hit.normal.normalized, Color.red);
            Debug.Log(hit.transform.name);

            interact = hit.transform.GetComponent<Interactable>();

            OnRaycast();
        }
    }

    public void OnRaycast()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact.Interact();
        }

    }
}
