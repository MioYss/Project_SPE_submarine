using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuiles : MonoBehaviour
{
    [SerializeField] private int[] array_Rotation;
    [SerializeField] private int index_Rotation;
    [SerializeField] private Puzzle5 puzzle_5_Object;
    [SerializeField] private int index_In_List;

    private Vector3 vector_Rotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tuile_Rotate()
    {
        if(index_Rotation == 3)
        {
            index_Rotation = 0;
            vector_Rotation.z = array_Rotation[index_Rotation];
            this.gameObject.transform.localRotation = Quaternion.Euler(vector_Rotation);
            puzzle_5_Object.update_List_All_Tuiles(index_In_List, array_Rotation[index_Rotation]);
        }
        else
        {
            index_Rotation++;
            vector_Rotation.z = array_Rotation[index_Rotation];
            this.gameObject.transform.localRotation = Quaternion.Euler(vector_Rotation);
            puzzle_5_Object.update_List_All_Tuiles(index_In_List, array_Rotation[index_Rotation]);
        }

    }

    public void random_Rotate()
    {
        Debug.Log("Je rotate");
        index_Rotation = UnityEngine.Random.Range(0, 4);
        vector_Rotation.z = array_Rotation[2];
        this.gameObject.transform.localRotation = Quaternion.Euler(vector_Rotation);
        puzzle_5_Object.update_List_All_Tuiles(index_In_List, array_Rotation[2]);
    }
}

