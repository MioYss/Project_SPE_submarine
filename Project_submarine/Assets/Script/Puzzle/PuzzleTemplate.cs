using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTemplate : MonoBehaviour
{
    [SerializeField]
    private Interactable interactable_Object1;

    public string puzzle_Index;

    public bool puzzle_Done = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPuzzleDone()
    {
        //Va mettre la valeur booléenne de sa clé au dictionnaire à True
        puzzle_Done=true;
    }


}
