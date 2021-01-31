using System;
using UnityEngine;

public class AttackState : BaseState
{
    //params
    private float _attackReadyTimer;
    private Monster currEnemy;

    public AttackState(Monster Monster) : base(Monster.gameObject)
    {
        this.currEnemy = Monster;

    }
    
    public override Type Tick()
    {
        if (this.currEnemy.Target == null)
        {
            //go back to going around
            return typeof(WanderState);

        }
        //else call function
        this.currEnemy.Attack();
        return null;
    }

}
