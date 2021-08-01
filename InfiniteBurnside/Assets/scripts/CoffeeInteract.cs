using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeInteract : MonoBehaviour
{
    private bool isPicked;
    public bool signal;
    void Start()
    {
        isPicked = false;
        signal = false;
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("near coffee");
            signal = true;
        }
    }
}
