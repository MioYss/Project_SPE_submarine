using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : PuzzleTemplate
{
    void Start()
    {
        puzzle_Index = "puzzle_1";
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle_Done && puzzle_Done_One_Time == false)
        {
            puzzle_Done_One_Time = true;
            Set_Puzzle_Done();
        }
    }

    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
        Debug.Log("Je change le dico attention !");
    }

    public override void Check_Up_Puzzle_Avancement()
    {

    }
}
