using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonLight : Interactable
{
    public Light light_set;
    private bool canPush =true;

    private void Start()
    {
        light_set.enabled = false;
    }
    public override void Interact()
    {
        if(canPush)
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
