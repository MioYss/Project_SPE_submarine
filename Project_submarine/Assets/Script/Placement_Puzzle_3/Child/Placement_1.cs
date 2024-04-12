using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement_1 : MonoBehaviour
{
    public List<float> rotation_Current;

    public Pickable pickable_Current;
    public GameObject game_Object_Current;
    public Rotation_Pick component_Rotation_Pick;

    //Elements pour voir si le joueur est dans la range du placement. On va prendre la position du joueur et celle du placement et on va trouver la distance qui les séparent. Si elle est inférieure, le is_In_Range sera à True
    public GameObject player;
    public float range_Max;
    public bool is_In_Range;


    //Right answer :
    [SerializeField] private Pickable pickable_Right_Answer;
    private List<float> rotation_Right_Answer;      //élément [0] : rotation X; élément[1] : rotation y

    //Player answer :

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(game_Object_Current != null)
        {
            rotation_Current = new List<float> (component_Rotation_Pick.Get_Rotation_Float());
            Debug.Log("x : " + rotation_Current[0] + "z : " + rotation_Current[1]);
        }
        

        if (Input.GetKeyDown(KeyCode.R) && is_In_Range == true && game_Object_Current != null)
        {
            if(pickable_Right_Answer == game_Object_Current)
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pieces")
        {
            Debug.Log("la piece touche placement");
            is_In_Range = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pieces")
        {
            Debug.Log("la piece touche plus placement");
            is_In_Range = false;
        }
    }

    /*public void change_Current_Pickable(Pickable new_Pickable)
    {
        pickable_Current = new_Pickable;
        Debug.Log(pickable_Current.feur);
    }*/

    public void change_Current_Game_Object(GameObject new_Game_Object)
    {
        game_Object_Current = new_Game_Object;
        Debug.Log(game_Object_Current);
        component_Rotation_Pick = game_Object_Current.GetComponent<Rotation_Pick>();
    }
    public void null_Current_Game_Object()
    {
        component_Rotation_Pick = null;
        pickable_Current = null ;
    }
}
