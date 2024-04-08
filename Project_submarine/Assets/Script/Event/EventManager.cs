using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EventManager : Manager
{
    
    private Dictionary<string, bool> dictio_Puzzle_Done = new Dictionary<string, bool> {
            {"Puzzle_1", false},
            {"Puzzle_2", false}
        };

    [SerializeField]
    private bool event_1, event_2;



    void Start()
    {
        
    }



    void Update()
    {
        if (dictio_Puzzle_Done["Puzzle_1"] == true && dictio_Puzzle_Done["Puzzle_2"] == true && event_1 == false)
        {
            Debug.Log("Alerte Coupure d'o² ");
            Lancement_Event_1();
            event_1 = true;
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


}
