using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBehaviour : MonoBehaviour
{
    public Transform Target
    {
        get;
        private set;
    }
    public AudioSource audioSource;
    [SerializeField] private AudioClip scareSound;

    public SM_Enemy sM_Enemy => GetComponent<SM_Enemy>();

    public void Awake()
    {
        //load the enemy's state machine
        this.InitStateMachine();
    }


    public void InitStateMachine()
    {
        var states = new Dictionary<Type, startState>()
        {
            {
                typeof(IdleState), new IdleState(this)
            },
            {
                typeof(ChaseState), new ChaseState(this)
            },
            {
                typeof(AttackState), new AttackState(this)
            }
        };

        GetComponent<SM_Enemy>().SetState(states);  
    }


    public void SetTarget(Transform target)
    {
        this.Target = target;
    }

    public void changeScene()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(scareSound, 1f);
        SceneManager.LoadScene(2);
    }
}
