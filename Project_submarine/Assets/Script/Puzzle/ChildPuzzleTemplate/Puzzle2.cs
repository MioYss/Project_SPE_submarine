using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public InteractiveConsolePuzzle2 console;

    //UI
    public List<TextMeshProUGUI> list_text;
    public TextMeshProUGUI index_UI;
    public TextMeshProUGUI text_Victoire;
    void Start()
    {
        puzzle_Index = "Puzzle_2";
    }

    // Update is called once per frame
    void Update()
    {
        if (console.on_Console == true)
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
    }

    //Va mettre la valeur booléenne de sa clé au dictionnaire à True avec la fonction
    public override void Set_Puzzle_Done()
    {
        Manager_Manager.GetManager<EventManager>().Changement_Dictionnaire_Puzzle(puzzle_Index, puzzle_Done);
    }

    private bool Verification_List_Player(List<int> list_Verif)
    {
        int var_Temporary = 0;
        for (int i = 0; i < 6; i++)
        {
            if(list_Verif[i] == proposition_Player[i])
            {
                var_Temporary++;
            }
        }

        if (var_Temporary == 6)
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
                list_text[index_Position].text = proposition_Player[index_Position].ToString() ;
            }
            else { proposition_Player[index_Position] = 0; list_text[index_Position].text = proposition_Player[index_Position].ToString(); }
        }

        if (bobole == false)      //Si bobole est égale à false : on décrémente le int a l'index actuel
        {
            if (proposition_Player[index_Position] > 0)
            {
                proposition_Player[index_Position]--;
                list_text[index_Position].text = proposition_Player[index_Position].ToString();
            }
            else { proposition_Player[index_Position] = 9; list_text[index_Position].text = proposition_Player[index_Position].ToString(); }
        }

        if(Verification_List_Player(right_Answer) == true)
        {
            puzzle_Done = true;
            text_Victoire.text = "C'est le bon code ! Replacez les pieces dans la machine a oxygène";
            Set_Puzzle_Done();
        }
        if(Verification_List_Player(right_Answer) == false)
        {
            Debug.Log("Code pas bon");
        }

    }

    private void Moove_Cursor(bool bobole)
    {
        if(bobole == true)      //Si bobole est égale à true : on déplace le curseur à droite
        {
            if(index_Position < 5)
            {
                index_Position++;
                index_UI.gameObject.transform.position = list_text[index_Position].gameObject.transform.position;
            }
            else { index_Position = 0; index_UI.gameObject.transform.position = list_text[index_Position].gameObject.transform.position; }
        }

        if(bobole == false)      //Si bobole est égale à false : on déplace le curseur à gauche
        {
            if(index_Position > 0)
            {
                index_Position--;
                index_UI.gameObject.transform.position = list_text[index_Position].gameObject.transform.position;
            }
            else { index_Position = 5; index_UI.gameObject.transform.position = list_text[index_Position].gameObject.transform.position; }
        }
    }

}
