using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoHover : MonoBehaviour
{
    private float hoverSpeed = 3f;
    private float localMax = 0.4f;
    private Vector3 currentObjectPos;


    void Start()
    {
       currentObjectPos = transform.position;
    }
    
    void Update()
    { 
        float y = Mathf.Sin(Time.time * hoverSpeed) * localMax + currentObjectPos.y;
        transform.position = new Vector3(currentObjectPos.x+15, y - 2, currentObjectPos.z) * localMax;
        
    }
}
