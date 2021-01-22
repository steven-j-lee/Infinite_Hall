using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SM_Enemy : MonoBehaviour
{
    private Dictionary<Type, startState> stateDictionary;
    public startState CurrentState
        {
            get;
            private set;
        }
    public event Action<startState> OnStateChanged;


    private void SwitchState(Type nextState)
    {
        this.CurrentState = this.stateDictionary[nextState];
        OnStateChanged?.Invoke(this.CurrentState);
    }

    public void SetState(Dictionary<Type, startState> dictionary)
    {
        this.stateDictionary = dictionary;
    }

    // Update is called once per frame
    void Update()
    {
       if(CurrentState == null)
        {
            //get first value in the dictionary
            this.CurrentState = this.stateDictionary.Values.First();
            var nextState = this.CurrentState?.Tick();

            if((nextState != null) && (nextState != this.CurrentState?.GetType()))
            {
                this.SwitchState(nextState);
            }
        }
    }



}
