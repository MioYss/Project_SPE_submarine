using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : Interactable
{
    [SerializeField] private Puzzle3 puzzle_3_Reference;
    [SerializeField] private int index_Placement;

    public List<float> rotation_Current;
    
    public GameObject game_Object_Current;
    public Pickable game_Object_Current_Pickable;
    public Rotation_Pick component_Rotation_Pick;

    private bool is_In_Range;

    public GameObject placement;

    //Right answer :
    [SerializeField] private GameObject game_Object_Right_Answer;
    [SerializeField] private List<float> rotation_Right_Answer;      //élément [0] : rotation X; élément[1] : rotation y
    [SerializeField] private int aproximative_Answer;


    // Update is called once per frame
    void Update()
    {
        if(game_Object_Current != null)
        {
            rotation_Current = new List<float> (component_Rotation_Pick.Get_Rotation_Float());
            //Debug.Log("x : " + rotation_Current[0] + "z : " + rotation_Current[1]);
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.F) && is_In_Range == true && game_Object_Current != null)
        {
            if (game_Object_Right_Answer == game_Object_Current)
            {
                if( (rotation_Current[0] >= rotation_Right_Answer[0] - aproximative_Answer && rotation_Current[0] <= rotation_Right_Answer[0] + aproximative_Answer) 
                    &&  (rotation_Current[1] >= rotation_Right_Answer[1] - aproximative_Answer && rotation_Current[1] <= rotation_Right_Answer[1] + aproximative_Answer) )
                {
                    Debug.Log("Yipee, c'est la bonne rotation");
                    game_Object_Current_Pickable.Drop();
                    null_Current_Game_Object();


                    puzzle_3_Reference.Set_Done_Placement(index_Placement);
                }
                else{ Debug.Log("ce n'est pas la bonne rotation !");}
            }
            else{ Debug.Log("ce n'est pas le bon objet !");}
        }*/
    }

    public override void Interact()
    {
        if(game_Object_Current != null)
        {
            if (game_Object_Right_Answer == game_Object_Current)
            {
                if ((rotation_Current[0] >= rotation_Right_Answer[0] - aproximative_Answer && rotation_Current[0] <= rotation_Right_Answer[0] + aproximative_Answer)
                    && (rotation_Current[1] >= rotation_Right_Answer[1] - aproximative_Answer && rotation_Current[1] <= rotation_Right_Answer[1] + aproximative_Answer))
                {
                    Debug.Log("Yipee, c'est la bonne rotation");
                    game_Object_Current_Pickable.transform.position = placement.transform.position;
                    game_Object_Current_Pickable.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                    game_Object_Current_Pickable.Drop();
                    
                    null_Current_Game_Object();


                    puzzle_3_Reference.Set_Done_Placement(index_Placement);
                }
                else { Debug.Log("ce n'est pas la bonne rotation !"); }
            }
            else { Debug.Log("ce n'est pas le bon objet !"); }
        }
    }



    /*public void OnCollisionEnter(Collision collision)
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
    }*/

    public void change_Current_Game_Object(GameObject new_Game_Object)
    {
        game_Object_Current =  new_Game_Object;
        component_Rotation_Pick = game_Object_Current.GetComponent<Rotation_Pick>();
        game_Object_Current_Pickable = game_Object_Current.GetComponent<Pickable>();
    }

    public void null_Current_Game_Object()
    {
        component_Rotation_Pick = null;
        game_Object_Current_Pickable = null;
        component_Rotation_Pick = null;
        game_Object_Current = null;
    }
}
