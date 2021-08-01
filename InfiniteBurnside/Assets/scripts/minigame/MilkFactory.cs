using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkFactory<T> : MonoBehaviour where T:MonoBehaviour
{
    [SerializeField] private T gameobjects;


    public T GetNewInstance()
    {
        return Instantiate(gameobjects);
    }

}
