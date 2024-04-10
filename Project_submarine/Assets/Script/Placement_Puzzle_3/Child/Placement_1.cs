using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement_1 : MonoBehaviour
{
    public List<float> rotation_Current;

    public Pickable pickable_Current;

    //Elements pour voir si le joueur est dans la range du placement. On va prendre la position du joueur et celle du placement et on va trouver la distance qui les séparent. Si elle est inférieure, le is_In_Range sera à True
    public GameObject player;
    public float range_Max;
    public bool is_In_Range;

    //pour avoir l'objet pris en main
    //public Grab grab_Manager;

    //Right answer :
    private Pickable pickable_Right_Answer;
    private List<float> rotation_Right_Answer;      //élément [0] : rotation X; élément[1] : rotation y

    //Player answer :

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && is_In_Range == true && pickable_Current != null)
        {
            if(pickable_Right_Answer == pickable_Current)
            {
                Debug.Log("Yipee, c'est la bonne pièce");
                if(rotation_Right_Answer[0] == rotation_Current[0] && rotation_Right_Answer[1] == rotation_Current[1])
                {
                    Debug.Log("Yipee, c'est la bonne rotation");
                }
                else
                {
                    Debug.Log("ce n'est pas la bonne rotation !");
                }
            }
            else
            {
                Debug.Log("ce n'est pas le bon objet !");
            }
        }
    }





    public void change_Current_Pickable(Pickable new_Pickable)
    {
        pickable_Current = new_Pickable;
        Debug.Log(pickable_Current.feur);
    }
    public void null_Current_Pickable()
    {
        pickable_Current = null ;
    }
}
