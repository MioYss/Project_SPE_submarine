using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private LayerMask layer_mask;

    private CharacterManager character_manager;

    private void Start()
    {
        character_manager = GetComponent<CharacterManager>();
    }

    private void Update(){
        if(Physics.Raycast(character_manager.Camera_transform.position, character_manager.Camera_transform.forward, out var hit, 10f, layer_mask)){
            // executer le code
            Debug.DrawLine(hit.point, hit.point + hit.normal.normalized, Color.red);
            Debug.Log(hit.transform.name);
        }
    }
}
