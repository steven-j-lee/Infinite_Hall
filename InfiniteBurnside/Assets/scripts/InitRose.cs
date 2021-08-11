using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitRose : MonoBehaviour
{
    public Rose_Data roseData;

    public string name;

    public bool taken;

    void Awake()
    {
        name = roseData.name;
        taken = roseData.isTaken;
    }
    
    void Update()
    {
        
    }
}
