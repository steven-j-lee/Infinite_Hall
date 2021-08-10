﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEventManager : MonoBehaviour
{
    [SerializeField] private GameObject ghostHands;

    public float timeCeil;
    public float timeFloor;
    [SerializeReference] private float dt;
    [SerializeReference] private float targetTime;
    void Start()
    {
        dt = 0;
        targetTime = Random.Range(timeFloor, timeCeil);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dt += Time.deltaTime;
        if (dt >= targetTime && !ghostHands.activeSelf)
        {
            ghostHands.SetActive(true);
            targetTime = Random.Range(timeFloor, timeCeil);
            dt = 0;
        }
        else
        {
            targetTime = Random.Range(timeFloor, timeCeil);
        }

        if (ghostHands.GetComponent<GhostHand>().SpaceCount >= 15 && ghostHands.activeSelf)
        {
            ghostHands.SetActive(false);
            ghostHands.GetComponent<GhostHand>().SpaceCount = 0;
        }
    }


}
