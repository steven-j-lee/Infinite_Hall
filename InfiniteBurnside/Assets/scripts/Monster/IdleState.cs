using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : startState
{
    // Start is called before the first frame update
    private Vector3? destination;
    private float limitDistance = 1f;
    private float turnRate = 2.5f;
    private readonly LayerMask _layerMask = LayerMask.NameToLayer("Walls");
    private float rayDist = 5f;
    private Quaternion targetAngle;
    private Vector3 direction;
    private MonsterBehaviour monster;

    private Quaternion initAngle = Quaternion.AngleAxis(-60, Vector3.up);
    private Quaternion angle = Quaternion.AngleAxis(5, Vector3.up);

    public IdleState(MonsterBehaviour monster): base(monster.gameObject)
    {
        this.monster = monster;
    }

    public override Type Tick()
    {
        //throw new NotImplementedException();
        var target = this.playerIsSeen();

        if(target != null)
        {
            this.monster.SetTarget(target);
            return typeof(ChaseState);
        }
        else
        {
            if (this.destination.HasValue == false || 
                Vector3.Distance(this.initTransform.position, this.destination.Value) <= this.limitDistance)
            {
                this.RandomizeNextDir();
            }
               
            this.initTransform.rotation = Quaternion.Slerp(this.initTransform.rotation, this.targetAngle, Time.deltaTime * this.turnRate);

            if (isBlockedInFront())
            {
                this.initTransform.rotation = Quaternion.Lerp(this.initTransform.rotation, this.targetAngle, 0.3f);
            }
            else
            {
                this.initTransform.Translate(Vector3.forward * Time.deltaTime * StateData.monsterSpeed);
            }
            while (isNoPath())
            {
                this.RandomizeNextDir();
            }
            return null;
        }
    }

    private Transform playerIsSeen()
    {
        RaycastHit hit;
        var tempAngle = this.initTransform.rotation * this.initAngle;
        var tempDirection = tempAngle * Vector3.forward;
        var tempPosition = this.initTransform.position;

        for(int i = 0; i < 30; i++)
        {
            if(Physics.Raycast(tempPosition, tempDirection, out hit, StateData.enemySight))
            {
                var enemy = hit.collider.GetComponent<MonsterBehaviour>();
                
                if((enemy != null))
                {
                    Debug.DrawRay(tempPosition, tempDirection * hit.distance, Color.green);
                    return enemy.transform;
                }
                else
                {
                    Debug.DrawRay(tempPosition, tempDirection * hit.distance, Color.white);
                }
            }
            else
            {
                Debug.DrawRay(tempPosition, tempDirection * StateData.enemySight, Color.white);
                Debug.Log("idling");
            }
            direction = this.angle * direction;
        }
        return null;
    }

    private void RandomizeNextDir()
    {
        Vector3 randomPos = (this.initTransform.position + (this.initTransform.forward * 4f)) +
            new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0f, UnityEngine.Random.Range(-4.5f, 4.5f));

        this.destination = new Vector3(randomPos.x, 1f, randomPos.z);
        this.direction = Vector3.Normalize(this.destination.Value - this.initTransform.position);
        this.direction = new Vector3(this.direction.x, 0f, this.direction.z);
        this.targetAngle = Quaternion.LookRotation(this.direction);
    }

    private bool isBlockedInFront()
    {
        Ray ray = new Ray(this.initTransform.position, this.initTransform.forward);
        return Physics.Raycast(ray, this.rayDist);
    }

    private bool isNoPath()
    {
        Ray ray = new Ray(this.initTransform.position, this.direction);
        return Physics.Raycast(ray, this.rayDist);
    }
    


}
