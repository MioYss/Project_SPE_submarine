using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : PuzzleTemplate
{
    [SerializeField]
    private int[] array_Right_Answer;

    [SerializeField] private List<int> list_Proposition;

    [SerializeField] private float[] array_Position_X;
    [SerializeField] private int index_Position;

    void Start()
    {
        puzzle_Index = "Puzzle_2";
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
