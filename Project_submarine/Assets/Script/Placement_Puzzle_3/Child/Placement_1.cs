using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement_1 : MonoBehaviour
{
    [SerializeField] private Puzzle3 puzzle_3_Reference;
    private int index_Placement;

    public List<float> rotation_Current;
    
    public GameObject game_Object_Current;
    public Pickable game_Object_Current_Pickable;
    public Rotation_Pick component_Rotation_Pick;

    private bool is_In_Range;


    //Right answer :
    [SerializeField] private GameObject game_Object_Right_Answer;
    [SerializeField] private List<float> rotation_Right_Answer;      //élément [0] : rotation X; élément[1] : rotation y
    [SerializeField] private int aproximative_Answer;

    //Player answer :

    // Start is called before the first frame update
    void Start()
    {
        index_Placement = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(game_Object_Current != null)
        {
            rotation_Current = new List<float> (component_Rotation_Pick.Get_Rotation_Float());

            Debug.Log("x : " + rotation_Current[0] + "z : " + rotation_Current[1]);
        }
        

        if (Input.GetKeyDown(KeyCode.F) && is_In_Range == true && game_Object_Current != null)
        {
            Debug.Log(" je passe le premier IF");           

            if (game_Object_Right_Answer == game_Object_Current)
            {
                Debug.Log("je passe le deuxieme if");

                if( (rotation_Current[0] >= rotation_Right_Answer[0] - aproximative_Answer && rotation_Current[0] <= rotation_Right_Answer[0] + aproximative_Answer) 
                    &&  (rotation_Current[1] >= rotation_Right_Answer[1] - aproximative_Answer && rotation_Current[1] <= rotation_Right_Answer[1] + aproximative_Answer) )
                {
                    Debug.Log("Yipee, c'est la bonne rotation");

                    Debug.Log("Je lache l'objet");
                    game_Object_Current_Pickable.Drop();
                    null_Current_Game_Object();


                    puzzle_3_Reference.Set_Done_Placement(index_Placement);
                }
                else{ Debug.Log("ce n'est pas la bonne rotation !");}
            }
            else{ Debug.Log("ce n'est pas le bon objet !");}
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Joueur")
        {
            Debug.Log("le joueur touche placement");
            is_In_Range = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Joueur")
        {
            Debug.Log("le joueur touche plus placement");
            is_In_Range = false;
        }
    }

    public void change_Current_Game_Object(GameObject new_Game_Object)
    {
        game_Object_Current =  new_Game_Object;
        component_Rotation_Pick = game_Object_Current.GetComponent<Rotation_Pick>();
        game_Object_Current_Pickable = game_Object_Current.GetComponent<Pickable>();
        Debug.Log(game_Object_Current);
    }

    public void null_Current_Game_Object()
    {
        component_Rotation_Pick = null;
        game_Object_Current_Pickable = null;
        component_Rotation_Pick = null;
        game_Object_Current = null;
    }
}
