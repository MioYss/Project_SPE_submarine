using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleTemplate : MonoBehaviour
{
    public string puzzle_Index;

    public bool puzzle_Done = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    //Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);

    public virtual void Set_Puzzle_Done()
    {

    }
    
    public virtual void Check_Up_Puzzle_Avancement()
    {
        
    }


}
