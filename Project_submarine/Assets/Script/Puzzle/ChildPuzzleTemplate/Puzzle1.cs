using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle1 : PuzzleTemplate
{
    //Variables : 
    [SerializeField]
    private bool[] array_Right_Answer;
    private List<bool> list_Proposition;
    private List<TextMeshProUGUI> liste_Button_Text;


    void Start()
    {
        puzzle_Index = "puzzle_1";

        for (int i = 0; i < 5; i++)
        {
            list_Proposition.Add(false);
        }
        
    }

    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
        Debug.Log("Je change le dico attention !");
    }


    private void Check_Up_Solution()
    {
        if (array_Right_Answer[0] == list_Proposition[0] && array_Right_Answer[1] == list_Proposition[1] && array_Right_Answer[2] == list_Proposition[2] && array_Right_Answer[3] == list_Proposition[3] && array_Right_Answer[4] == list_Proposition[4])
        {
            Debug.Log("Puzzle validé ! ");
            puzzle_Done = true;
            Set_Puzzle_Done();
        }
    }


    public void button_Clicked(int index)
    {
        if (list_Proposition[index] == true) 
        { 
            list_Proposition[index] = false;
            liste_Button_Text[index].text = "0";
        } 
        else 
        { 
            list_Proposition[index] = true;
            liste_Button_Text[index].text = "1";
        }
        Check_Up_Solution();
    }

}
