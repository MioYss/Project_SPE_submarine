using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle5 : PuzzleTemplate
{
    //Variables Tuiles
    public List<int> list_All_Tuiles;
    public List<int> list_Right_Answer;
    public int compteur_Right;
    public InteractValve valve;

    //Variables code/symboles
    public InteractConsolePuzzle5 on_Console ;
    public List<int> proposition_Player_Numbers;
    [SerializeField] private List<int> list_Right_Answer_Numbers;
    private int index_Position;

    public bool makeRotate = false;


    //UI
    public List<TextMeshProUGUI> list_Text;
    public TextMeshProUGUI cursor_UI;

    void Start()
    {
        puzzle_Index = "Puzzle_5";
    }

    void Update()
    {
        if(on_Console.on_Console == true)
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


    //Méthodes Tuiles
    public void update_List_All_Tuiles(int index, int rotation)
    {
        list_All_Tuiles[index] = rotation;
        if(verif_List_Right_Answer() == true)
        {
            Debug.Log("Le codes est bon");
            valve.canvas_Puzzle_3.SetActive(false);
            valve.on_Valve = false;

            //manque juste a baisser le niveau de l'eau
        }
        else
        {
            Debug.Log("Code pas bon");
        }
    }
    public bool verif_List_Right_Answer()
    {
        //PARDON
        if (list_Right_Answer[0] == list_All_Tuiles[0] && list_Right_Answer[1] == list_All_Tuiles[1] &&
            /*list_Right_Answer[4] == list_All_Tuiles[4] &&*/ list_Right_Answer[5] == list_All_Tuiles[5] && list_Right_Answer[6] == list_All_Tuiles[6] && list_Right_Answer[7] == list_All_Tuiles[7] &&
            list_Right_Answer[8] == list_All_Tuiles[8] && list_Right_Answer[9] == list_All_Tuiles[9] && list_Right_Answer[10] == list_All_Tuiles[10] /*&& list_Right_Answer[11] == list_All_Tuiles[11]*/ &&
                                                          list_Right_Answer[13] == list_All_Tuiles[13] && /*list_Right_Answer[14] == list_All_Tuiles[14] &&*/ list_Right_Answer[15] == list_All_Tuiles[15])
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    private bool Verification_List_Player()
    {
        int var_Temporary = 0;
        for (int i = 0; i < 4; i++)
        {
            if (list_Right_Answer_Numbers[i] == proposition_Player_Numbers[i])
            {
                var_Temporary++;
            }
        }

        if (var_Temporary == 4)
        {
            return true;
        }
        return false;
    }


    private void Incremente_Decremente(bool bobole)
    {
        if (bobole == true)      //Si bobole est égale à true : on incrémente le int a l'index actuel
        {
            if (proposition_Player_Numbers[index_Position] < 9)
            {
                proposition_Player_Numbers[index_Position]++;
                list_Text[index_Position].text = proposition_Player_Numbers[index_Position].ToString();
            }
            else { proposition_Player_Numbers[index_Position] = 0; list_Text[index_Position].text = proposition_Player_Numbers[index_Position].ToString(); }
        }

        if (bobole == false)      //Si bobole est égale à false : on décrémente le int a l'index actuel
        {
            if (proposition_Player_Numbers[index_Position] > 0)
            {
                proposition_Player_Numbers[index_Position]--;
                list_Text[index_Position].text = proposition_Player_Numbers[index_Position].ToString();
            }
            else { proposition_Player_Numbers[index_Position] = 9; list_Text[index_Position].text = proposition_Player_Numbers[index_Position].ToString(); }
        }

        if (Verification_List_Player() == true)
        {
            puzzle_Done = true;
            Debug.Log("Code Symbole bon");
            Set_Puzzle_Done();
        }
        if (Verification_List_Player() == false)
        {
            Debug.Log("Code Symbole pas bon");
        }

    }

    private void Moove_Cursor(bool bobole)
    {
        if (bobole == true)      //Si bobole est égale à true : on déplace le curseur à droite
        {
            if (index_Position < 5)
            {
                index_Position++;
                cursor_UI.gameObject.transform.position = list_Text[index_Position].gameObject.transform.position;
            }
            else { index_Position = 0; cursor_UI.gameObject.transform.position = list_Text[index_Position].gameObject.transform.position; }
        }

        if (bobole == false)      //Si bobole est égale à false : on déplace le curseur à gauche
        {
            if (index_Position > 0)
            {
                index_Position--;
                cursor_UI.gameObject.transform.position = list_Text[index_Position].gameObject.transform.position;
            }
            else { index_Position = 5; cursor_UI.gameObject.transform.position = list_Text[index_Position].gameObject.transform.position; }
        }
    }



}
