using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class startState
{
    protected GameObject initGameobject;
    protected Transform initTransform;


    //constructor
    public startState(GameObject gameobject)
    {
        this.initGameobject = gameobject;
        this.initTransform = this.initGameobject.transform;

    }

    //abstract method
    public abstract Type Tick();



}
