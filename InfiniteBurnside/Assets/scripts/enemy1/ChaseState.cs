using System;
using UnityEngine;

public class ChaseState : BaseState
{
    private Monster enemy;
    public ChaseState(Monster Monster) : base(Monster.gameObject)
    {
        this.enemy = Monster;
    }



    public override Type Action()
    {
        if (this.enemy.Target.Equals(null))
        {
            return typeof(WanderState);
        }
        var distance = Vector3.Distance(this.transform.position, this.enemy.Target.transform.position);
        if (distance <= MonsterState.AttackRange)
        {
            //if we are in range change state to attack
            return typeof(AttackState);
        }
        //get lookat from ray
        this.transform.LookAt(this.enemy.Target);
        this.transform.Translate(Vector3.forward * Time.deltaTime * MonsterState.currentSpeed);

        return null;
    } 
}