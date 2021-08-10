﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    
    public Transform Target { get; private set; }
    public StateMachine StateMachine => GetComponent<StateMachine>();
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    public bool isInContactWithPlayer;
    public bool isHittingWall;
    private void Awake()
    {
        this.InitializeStateMachine();
        isInContactWithPlayer = false;
        isHittingWall = false;
    }
    public void SetTarget( Transform target )
    {
        this.Target = target;

    }
    private void InitializeStateMachine()
    {

        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(WanderState), new WanderState( this ) },
            { typeof(ChaseState), new ChaseState( this ) },
            { typeof(AttackState), new AttackState( this ) }
        };

        GetComponent<StateMachine>().SetStates(states);

    }

    public void Attack()
    {
        if (isInContactWithPlayer)
        {
            SceneManager.LoadScene(2);   
        }
        else
        {
            isInContactWithPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("wall"))
        {
            isHittingWall = true;
        }
        
        if (other.CompareTag("Player"))
        {
            isInContactWithPlayer = true;
        }
        
    }
}
