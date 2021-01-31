using System;
using UnityEngine;

public class ChaseState : BaseState
{
    private Monster enemt;
    
    public ChaseState(Monster Monster) : base(Monster.gameObject)
    {
        this.enemt = Monster;
    } //End Constructor


    public override Type Tick()
    {
        if (this.enemt.Target == null)
        {
            return typeof(WanderState);
        }
        //get lookat from ray
        this.transform.LookAt(this.enemt.Target);
        this.transform.Translate(Vector3.forward * Time.deltaTime * GameSettings.currentSpeed);

        
        var distance = Vector3.Distance(this.transform.position, this.enemt.Target.transform.position);
        
        if (distance <= GameSettings.AttackRange)
        {
            //if we are in range change state to attack
            return typeof(AttackState);
        }
        return null;
    } 
}