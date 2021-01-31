using System;
using UnityEngine;

/// <summary>
/// This class will be the PARENT (BASE CLASS) to all CHILDREN (DERIVED), which will really IMPLEMENT its Methods (via the OVERRIDE command), such as:   TICK()  // State Change.
/// </summary>
public abstract class BaseState
{

    protected GameObject myGameObject;
    protected Transform transform;

    public BaseState(GameObject gameObject)
    {
        this.myGameObject = gameObject;
        this.transform = this.myGameObject.transform;

    }

    
    public abstract Type Tick();

    
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

}
