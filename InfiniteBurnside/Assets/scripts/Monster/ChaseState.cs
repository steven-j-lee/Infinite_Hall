using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : startState
{
    private MonsterBehaviour monster;

    public ChaseState(MonsterBehaviour monster) : base(monster.gameObject)
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

        this.initTransform.LookAt(this.monster.Target);
        this.initTransform.Translate(Vector3.forward * Time.deltaTime * StateData.monsterSpeed);
        var tempDist = Vector3.Distance(this.initTransform.position, this.monster.Target.transform.position);

        if (tempDist <= StateData.range)
        {
            return typeof(AttackState);
        }
        return null;
    }
}
