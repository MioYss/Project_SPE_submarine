using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : PuzzleTemplate
{
    public bool puzzle_Done = false;

    void Start()
    {
        puzzle_Index = "Puzzle_3";
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    //Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);

    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
    }


     
}
