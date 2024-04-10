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
    private bool event_1, event_2;



    void Start()
    {
        
    }



    void Update()
    {
        if (dictio_Puzzle_Done["Puzzle_1"] == true && event_1 == false)
        {
            Debug.Log("Alerte Coupure d'o² ");
            Lancement_Event_1();
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


    public void Lancement_Event_1()
    {
        Debug.Log("bouuuuh l'oxygène est cassé");
    }
    public void Lancement_Event_2()
    {
        Debug.Log("bouuuuh le sous marin s'innonde");
    }


}
