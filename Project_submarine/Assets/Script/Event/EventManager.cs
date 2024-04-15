using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EventManager : Manager
{
    private Dictionary<string, bool> dictio_Puzzle_Done = new Dictionary<string, bool> {
            {"Puzzle_1", false},
            {"Puzzle_2", false},
            {"Puzzle_3", false},
            {"Puzzle_4", false},
            {"Puzzle_5", false}
        };

    [SerializeField]
    private bool event_0, event_1, event_2;

    //Event 0 :
    public List<Light> list_Lights;

    //Event 1:
    public DeathOxygene game_Object_Oxygene;

    //Event 2:
    public InteractWater game_Object_Water;


    void Start()
    {
        for (int i = 0; i < list_Lights.Count; i++)
        {
            list_Lights[i].GetComponent<Light>().enabled = false;
        }
    }



    void Update()
    {
        if (dictio_Puzzle_Done["Puzzle_1"] == true && event_1 == false)
        {
            Lancement_Event_0();    //rallumer la lumiere
            Lancement_Event_1();    //cassage oxygène
            event_1 = true;
        }
        if (dictio_Puzzle_Done["Puzzle_2"] == true && dictio_Puzzle_Done["Puzzle_3"] == true && event_2 == false)
        {
            game_Object_Oxygene.OxygeneStop();  //arrête l'event de l'oxygène

            Debug.Log("Alerte innondations ");
            Lancement_Event_2();
            event_2 = true;
        }
        if (dictio_Puzzle_Done["Puzzle_5"] == true)
        {
            game_Object_Water.Water_Stop();     //arrête l'event de l'eau
        }
    }




    /// <summary>
    /// Fonction qui sera appeler dans le script des puzzles afin qu'ils modifient leur valeur booléen lié a leur clé dans le dico (à réécrire)
    /// </summary>
    /// <param name="puzzle"></param>
    /// <param name="boolStatue"></param>
    public void Changement_Dictionnaire_Puzzle(string puzzle, bool boolStatue)
    {
        dictio_Puzzle_Done[puzzle] = boolStatue;
        Debug.Log("Je confirme ! Mon dico a changé !");
        Debug.Log(dictio_Puzzle_Done[puzzle]);
    }

    public void Lancement_Event_0()
    {
        for(int i = 0; i < list_Lights.Count; i++)
        {
            list_Lights[i].GetComponent<Light>().enabled = true;
        }
    }
    public void Lancement_Event_1()
    {
        game_Object_Oxygene.OxygenePop();
        Debug.Log("Alerte Coupure d'o² ");
    }
    public void Lancement_Event_2()
    {
        game_Object_Water.Water_Pop();
        Debug.Log("bouuuuh le sous marin s'innonde");
    }


}
