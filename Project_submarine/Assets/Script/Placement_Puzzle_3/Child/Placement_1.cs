using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement_1 : MonoBehaviour
{
    public Interactable object_1, object_2, object_3, object_4, object_5, object_6;

    //Elements pour voir si le joueur est dans la range du placement. On va prendre la position du joueur et celle du placement et on va trouver la distance qui les séparent. Si elle est inférieure, le is_In_Range sera à True
    public GameObject player;
    public float range_Max;
    public bool is_In_Range;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
