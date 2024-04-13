using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Pick : MonoBehaviour
{
    [SerializeField] private float min_rot_angle_object = -90, max_rot_angle_object = 90;
    [SerializeField] private float rotation_speed = 10f;

    private Pickable pickable;

    public Grab grab_var;

    private Vector3 lateral_rotation_object = Vector3.zero;

    [SerializeField] private List<float> list_Return;
    void Start()
    {
        pickable = this.GetComponent<Pickable>();
    }

    private void Update()
    {
        if(grab_var.is_Someone_In_Hand() == pickable )
        {
            if (Input.GetMouseButton(1)) Pitch();
            else Roll();
        }
        
    }

    private void Pitch()
    {
            lateral_rotation_object.x += Input.GetAxisRaw("Mouse ScrollWheel") * rotation_speed;
            lateral_rotation_object.x = Mathf.Clamp(lateral_rotation_object.x, min_rot_angle_object, max_rot_angle_object);

            transform.localRotation = Quaternion.Euler(lateral_rotation_object);
    }

    private void Roll()
    {
        lateral_rotation_object.z += Input.GetAxisRaw("Mouse ScrollWheel") * rotation_speed;
        lateral_rotation_object.z = Mathf.Clamp(lateral_rotation_object.z, min_rot_angle_object, max_rot_angle_object);

        transform.localRotation = Quaternion.Euler(lateral_rotation_object);
    }

    public List<float> Get_Rotation_Float()
    {
        list_Return.Clear();
        list_Return.Add(lateral_rotation_object.x);
        list_Return.Add(lateral_rotation_object.z);
        //Debug.Log(list_Return[0]);
        //Debug.Log(list_Return[1]);
        return list_Return;
}
}
