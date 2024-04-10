using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWater : Interactable
{
    public GameObject water ;
    private int level_water = 1;

    private void Start()
    {
        StartCoroutine(Water_Up());
    }

    public override void Interact()
    {
        if (level_water == 0) 
        {
            return;
        }
        else
        {
            StartCoroutine(Water_Down());
        }
    }
    private IEnumerator Water_Up()
    {
        while (true) 
        {
            level_water = Mathf.Clamp(level_water, 0, 6);
            if (level_water <= 5)
            {
                var newpos = water.transform.position + new Vector3(0, 0.1f, 0);
                while ((newpos - water.transform.position).magnitude > 0.01f)
                {
                    water.transform.position = Vector3.Slerp(water.transform.position, newpos, 0.01f);
                    yield return new WaitForEndOfFrame();
                }
                water.transform.position = newpos;

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

    private IEnumerator Water_Down()
    {
        var newpos = water.transform.position + new Vector3(0, -0.1f, 0);
        while ((newpos - water.transform.position).magnitude > 0.01f)
        {
            water.transform.position = Vector3.Slerp(water.transform.position, newpos, 0.01f);
            yield return new WaitForEndOfFrame();
        }
        water.transform.position = newpos;
        level_water--;
        level_water = Mathf.Clamp(level_water, 0, 6);
        Debug.Log(level_water);
        yield return new WaitForEndOfFrame();
    }
}
