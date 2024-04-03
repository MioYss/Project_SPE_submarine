using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : PuzzleTemplate
{
    //variables pour le déplacement du curseur
    [SerializeField] private float[] array_Position_X;
    [SerializeField] private int index_Position;

    //Array de codes préfinis
    public List<int> right_Answer;
    public List<int> other_Answer_1;

    public List<int> proposition_Player;
    public List<bool> validity;

    void Start()
    {
        puzzle_Index = "Puzzle_2";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Incremente_Decremente(false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Incremente_Decremente(true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Moove_Cursor(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Moove_Cursor(false);
        }
    }
    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    //Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);

    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
    }

    private bool Verification_List_Player(List<int> list_Verif, List<bool> list_Valid)
    {
        for (int i = 0; i < 6; i++)
        {
            if(list_Verif[i] == proposition_Player[i])
            {
                list_Valid[i] = true;
            }
            list_Valid[i] = false;
        }
        if (list_Valid.TrueForAll(x => true))
        {
            return true;
        }
        return false;
    }


    private void Incremente_Decremente(bool bobole)
    {
        if(bobole == true)      //Si bobole est égale à true : on incrémente le int a l'index actuel
        {
            if (proposition_Player[index_Position] < 9)
            {
                proposition_Player[index_Position]++;
            }
            else { proposition_Player[index_Position] = 0; }
        }

        if (bobole == false)      //Si bobole est égale à false : on décrémente le int a l'index actuel
        {
            if (proposition_Player[index_Position] > 0)
            {
                proposition_Player[index_Position]--;
            }
            else { proposition_Player[index_Position] = 9; }
        }
    }

    private void Moove_Cursor(bool bobole)
    {
        if(bobole == true)      //Si bobole est égale à true : on déplace le curseur à droite
        {
            if(index_Position < 5)
            {
                index_Position++;
            }
            else { index_Position = 0; }
        }

        if(bobole == false)      //Si bobole est égale à false : on déplace le curseur à gauche
        {
            if(index_Position > 0)
            {
                index_Position--;
            }
            else { index_Position = 5; }
        }
    }

}
