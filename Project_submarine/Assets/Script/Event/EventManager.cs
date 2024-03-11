using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Manager
{
    public Dictionary<string, bool> dictio_Puzzle_Done = new Dictionary<string, bool> {
            {"Puzzle_1", false},
            {"Puzzle_2", false}
        };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dictio_Puzzle_Done["Puzzle_1"] == false)
        {
            Debug.Log("Le puzzle 1 n'est pas complété");
        }
    }
}
