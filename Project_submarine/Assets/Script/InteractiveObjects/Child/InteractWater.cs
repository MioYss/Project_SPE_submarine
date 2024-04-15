 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWater : Interactable
{
    public GameObject water ;
    private int level_water = 1;

    public bool LancerEau;
    public bool EnleverEau;

    private void Start()
    {

    }

    private void Update()
    {
        if(LancerEau == true)
        {
            StartCoroutine(Water_Up());
            LancerEau = false;
        }
        if(EnleverEau == true)
        {
            StartCoroutine(Water_Down());
            EnleverEau = false;
        }
    }

    public void Put_Water_Down()
    {
        StartCoroutine(Water_Down());
    }
    /*public override void Interact()
    {
        if (level_water == 0) 
        {
            return;
        }
        else
        {
            StartCoroutine(Water_Down());
        }
    }*/
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
                //Debug.Log(level_water);
            }

            if (level_water >= 0)
            {
                yield return new WaitForSecondsRealtime(5);
            }

            yield return new WaitForSecondsRealtime(2);
        }

    }

    private IEnumerator Water_Down()
    {
        var newpos = water.transform.position + new Vector3(0, -1f, 0);
        while ((newpos - water.transform.position).magnitude > 0.01f)
        {
            water.transform.position = Vector3.Slerp(water.transform.position, newpos, 0.01f);
            yield return new WaitForEndOfFrame();
        }
        water.transform.position = newpos;
        level_water = 0;
        level_water = Mathf.Clamp(level_water, 0, 6);
        //Debug.Log(level_water);
        yield return new WaitForEndOfFrame();
    }

    public void Water_Pop()
    {
        StartCoroutine(Water_Up());

    }
    public void Water_Stop()
    {
        StopCoroutine(Water_Up());
        StopCoroutine(Water_Down());
    }
}
