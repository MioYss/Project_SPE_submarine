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
            Lancement_Event_1();    //cassage oxyg�ne
            event_1 = true;
        }
        if (dictio_Puzzle_Done["Puzzle_2"] == true && dictio_Puzzle_Done["Puzzle_3"] == true && event_2 == false)
        {
            Debug.Log("Alerte innondations ");
            Lancement_Event_2();
            event_2 = true;
        }
    }




    /// <summary>
    /// Fonction qui sera appeler dans le script des puzzles afin qu'ils modifient leur valeur bool�en li� a leur cl� dans le dico (� r��crire)
    /// </summary>
    /// <param name="puzzle"></param>
    /// <param name="boolStatue"></param>
    public void Changement_Dictionnaire_Puzzle(string puzzle, bool boolStatue)
    {
        dictio_Puzzle_Done[puzzle] = boolStatue;
        Debug.Log("Je confirme ! Mon dico a chang� !");
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
        Debug.Log("Alerte Coupure d'o� ");
    }
    public void Lancement_Event_2()
    {
        Debug.Log("bouuuuh le sous marin s'innonde");
    }


}
