using System;
using UnityEngine;

public class WanderState : BaseState
{
    
    private Vector3? destination;
    private float stoppingDistance = 1f;
    private float turnSpeed = 1f;
    private readonly LayerMask layerMask = LayerMask.NameToLayer("Walls");
    public float rayDistance = 4.5f;   
    private Quaternion desiredRotation;
    private Vector3 myDirection;
    private Monster stateMon;
    

    private Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    private Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);
    
    public WanderState(Monster monster) : base( monster.gameObject )
    {
        this.stateMon = monster;
    }


    public override Type Tick()
    {

        var chaseTarget = this.CheckForPlayer();
        
        //if we sense the player, chase
        if (chaseTarget != null)
        {
            this.stateMon.SetTarget(chaseTarget);
            return typeof(ChaseState);
        }
        else
        {

            if ((this.destination.HasValue == false) || 
            (Vector3.Distance(this.transform.position, this.destination.Value) <= this.stoppingDistance))
            {
                this.FindRandomDestination();

            }     
            
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.desiredRotation, 
                Time.deltaTime * this.turnSpeed);

            //check for walls
            if (IsForwardBlocked())
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.desiredRotation, 0.2f);
            }
            else
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * GameSettings.currentSpeed);
            }
            //Debug.DrawRay(this.transform.position, this.myDirection * this.rayDistance, this.stateMon._myTeamDebugRayColor);
            //try finding a new location
            while (IsPathBlocked())
            {
                this.FindRandomDestination();
            }
            return null;
        }
    }


    private bool IsForwardBlocked()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        return Physics.Raycast(ray, this.rayDistance);
    }

    //Check if our path is blocked
    private bool IsPathBlocked()
    {
        Ray ray = new Ray(this.transform.position, this.myDirection);
        return Physics.Raycast(ray, this.rayDistance);

    }


    //generate a new direction and rotate
    private void FindRandomDestination()
    {
        Vector3 testPosition = (this.transform.position + (this.transform.forward * 4f)) +
         new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0f, UnityEngine.Random.Range(-4.5f, 4.5f));
        this.destination = new Vector3(testPosition.x, 1f, testPosition.z);
        this.myDirection = Vector3.Normalize(this.destination.Value - this.transform.position);
        this.myDirection = new Vector3(this.myDirection.x, 0f, this.myDirection.z);
        this.desiredRotation = Quaternion.LookRotation(this.myDirection);

    }
    //check if we hit player
    private Transform CheckForPlayer()
    {
        RaycastHit hit;
        var angle = this.transform.rotation * this.startingAngle;
        var direction = angle * Vector3.forward;
        var pos = this.transform.position;

        for (var i = 0; i < 24; i++)
        {
            if (Physics.Raycast(pos, direction, out hit, GameSettings.AggroRadius))
            {
                //we find the player
                var Player = hit.collider.gameObject;
                if (Player.CompareTag("Player"))
                {
                    GameSettings.Instance.setSpeed(3f);
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    Debug.Log("I see player");
                    return Player.transform;
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.blue);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * GameSettings.AggroRadius, Color.white);
            }
            //change direction
            direction = this.stepAngle * direction;
        }
        //create a return if we don't find anything
        return null;
    }

}
