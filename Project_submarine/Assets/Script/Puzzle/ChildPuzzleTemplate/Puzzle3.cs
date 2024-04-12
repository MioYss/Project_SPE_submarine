using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : PuzzleTemplate
{
    //public bool puzzle_Done = false;

    [SerializeField] private List<bool> list_Placement_Player;

    void Start()
    {
        puzzle_Index = "Puzzle_3";

        for(int i = 0; i < 5; i++)
        {
            list_Placement_Player.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (list_Placement_Player[0]== true && list_Placement_Player[1] == true && list_Placement_Player[2] == true && list_Placement_Player[3] == true && list_Placement_Player[4] == true && list_Placement_Player[5] == true)
        {
            puzzle_Done = true;
            Set_Puzzle_Done();
        }
    }
    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
    }

    public void Set_Done_Placement( int index)
    {
        list_Placement_Player[index] = true; 
    }
     
}
