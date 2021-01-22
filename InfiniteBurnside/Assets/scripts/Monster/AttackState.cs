using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : startState
{
    private MonsterBehaviour monster;

    public AttackState(MonsterBehaviour monster) : base(monster.gameObject)
    {
        this.monster = monster;
    }

    public override Type Tick()
    {
        //throw new NotImplementedException();
        if(this.monster.Target == null)
        {
            return typeof(IdleState);
        }

        this.monster.changeScene();

        return null;
    }

}
