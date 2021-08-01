using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEvent : MonoBehaviour
{
    [SerializeField] private List<GameObject> quests;
    [SerializeField] private GameObject worm;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject player;


    private void Start()
    {
       
    }

    void Update()
    {
        /*
        if (!ClearEvent(quests))
        {
            Debug.Log("not complete");
        }
        else if (ClearEvent(quests))
        {
            Debug.Log("Complete!");
        }
        */
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
           
        }
    }

    private bool ClearEvent(List<GameObject> quests)
    {
        foreach (var VARIABLE in quests)
        {
            if (VARIABLE.TryGetComponent(out CoffeeInteract ci))
            {
                if (!ci.signal)
                {
                    return false;
                }
            }
            else if (VARIABLE.TryGetComponent(out EventManager em))
            {
                if (!em.milkQuestIsComplete)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
