using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWater : Interactable
{
    public GameObject water ;
    private int level_water = 0;
    private  int level_water_down = 0;
    public override void Interact()
    {
        if (level_water <= 5)
        {
            water.transform.position += new Vector3(0, 0.5f, 0);
            level_water++;
        }
        else
        {
            water.transform.position -= new Vector3(0, 0.5f, 0);
            level_water_down++;
                if (level_water_down == 5)
            {
                level_water = 0;
            }
        }
    }
}
