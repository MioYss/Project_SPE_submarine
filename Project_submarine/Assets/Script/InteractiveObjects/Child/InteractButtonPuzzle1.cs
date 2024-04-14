using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonPuzzle1 : Interactable
{
    [SerializeField] int index;
    public Puzzle1 game_Object_Puzzle_1;

    public Light light_set;
    private bool canPush = true;

    // Start is called before the first frame update
    void Start()
    {
        light_set.GetComponent<Light>().enabled = false;
    }

    public override void Interact()
    {
        game_Object_Puzzle_1.button_Clicked(index);
        if (canPush)
        {
            canPush = false;
            StartCoroutine(Switch());
            if (light_set.enabled == false)
            {
                light_set.GetComponent<Light>().enabled = true;
            }
            else
            {
                light_set.GetComponent<Light>().enabled = false;
            }
        }
    }

    private IEnumerator Switch()
    {
        yield return new WaitForSecondsRealtime(1);
        canPush = true;
    }
}
