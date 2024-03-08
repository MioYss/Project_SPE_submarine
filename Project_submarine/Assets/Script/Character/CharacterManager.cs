using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Transform camera_transform;

    public Transform Camera_transform { get => camera_transform; private set => camera_transform = value; }
}
