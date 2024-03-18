using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWater : Interactable
{
    public GameObject water ;
    private int level_water = 1;

    private void Start()
    {
        StartCoroutine(Water_up());
    }

    public override void Interact()
    {
        if (level_water == 0) 
        {
            return;
        }
        else
        {
            water.transform.position -= new Vector3(0, 0.1f, 0);
            level_water--;
            level_water = Mathf.Clamp(level_water, 0, 6);
            Debug.Log(level_water);
        }
    }
    private IEnumerator Water_up()
    {
        while (true) 
        {
            level_water = Mathf.Clamp(level_water, 0, 6);
            if (level_water <= 5)
            {

                water.transform.position += new Vector3(0, 0.1f, 0);
                level_water++;
                Debug.Log(level_water);
            }

            if (level_water <= 0)
            {
                yield return new WaitForSecondsRealtime(2);
            }

            yield return new WaitForSecondsRealtime(2);
        }

    }
}
