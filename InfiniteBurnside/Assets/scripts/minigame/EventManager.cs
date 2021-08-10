using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject minigame;
    [SerializeField] private GameObject ship;

    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject npcNext;

    [SerializeField] private GameObject uiManager;

    public bool milkQuestIsComplete;
    void Start()
    {
        milkQuestIsComplete = false;
    }


    void Update()
    {
        if (ship.GetComponent<ShipMovement>().lives <= 0)
        {
            minigame.SetActive(false);
            player.SetActive(true);
            uiManager.SetActive(true);
            ship.GetComponent<ShipMovement>().lives = 3;
            ship.GetComponent<ShipMovement>().score = 0;
        }

        //Win condition
        else if (ship.GetComponent<ShipMovement>().score >= 1500)
        {
            minigame.SetActive(false);
            player.SetActive(true);
            npc.SetActive(false);
            npcNext.SetActive(true);
            uiManager.SetActive(true);
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            milkQuestIsComplete = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("I am pressing P");
            player.SetActive(false);
            uiManager.SetActive(false);
            minigame.SetActive(true);

        }
    }

}
