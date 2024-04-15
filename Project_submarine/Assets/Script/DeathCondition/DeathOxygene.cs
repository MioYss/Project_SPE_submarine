using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathOxygene : MonoBehaviour
{
    int Oxygene_timer = 0;
    int Death_counter = 0;


    public Transform respawn_point ;
    public GameObject player;

    private void Start()
    {
    }

    private IEnumerator OxygeneStart()
    {
        while (true) {
            for(Oxygene_timer = 0; Oxygene_timer < 180; Oxygene_timer++)
            {
                // if(Check condition victoire puzzle) -> sortir du for
                // else
                Death_counter++;
                Debug.Log("death++");
                if (Death_counter == 180)
                {
                    Death_counter = 0;
                    StartCoroutine(Respawn());
                    break;
                }
                else 
                {
                yield return new WaitForSecondsRealtime(1);
                Debug.Log("attendu 1s");
                }
            }
        }
    }

    private IEnumerator Respawn()
    {
        Death_counter = 0;
        yield return new WaitForSecondsRealtime(1);
        player.transform.position = respawn_point.position;
        Debug.Log("respawn");
    }

    public void OxygenePop()
    {
        StartCoroutine(OxygeneStart());
        Debug.Log("start co");
    }

    public void OxygeneStop()
    {
        StopAllCoroutines();
    }
}
