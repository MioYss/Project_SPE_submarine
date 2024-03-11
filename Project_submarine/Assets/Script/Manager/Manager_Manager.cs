using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager_Manager : MonoBehaviour
{
    private static Manager_Manager instance;

    [SerializeField]
    private List<Manager> managers;

    public void Awake()
    {
        if (Manager_Manager.instance == null)
        {
            Manager_Manager.instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        managers = new List<Manager>();
        managers = GetComponents<Manager>().ToList();
        DontDestroyOnLoad(gameObject);
    }


    public static T GetManager<T>() where T : Manager
    {
        foreach (var manager in instance.managers)
        {
            if (manager.GetType() == typeof(T))
            {
                return (T)manager;
            }
        }
        return null;
    }
}
