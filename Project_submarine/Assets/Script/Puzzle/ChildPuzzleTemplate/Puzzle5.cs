using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5 : PuzzleTemplate
{
    //Variables Tuiles
    public List<int> list_All_Tuiles;
    public List<int> list_Right_Answer;
    public int compteur_Right;



    void Start()
    {
        puzzle_Index = "Puzzle_5";
    }

    void Update()
    {
        
    }

    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
    }


    //Méthodes Tuiles
    public void update_List_All_Tuiles(int index, int rotation)
    {
        list_All_Tuiles[index] = rotation;
        verif_List_Right_Answer();
    }
    public bool verif_List_Right_Answer()
    {
        for (int i = 0; i < list_Right_Answer.Count; i++)
        {
            if (list_Right_Answer[i] == list_All_Tuiles[i])
            {
                compteur_Right++;
            }
        }
        if(compteur_Right == list_Right_Answer.Count)
        {
            return true;
        }
        return false;
    }

}
