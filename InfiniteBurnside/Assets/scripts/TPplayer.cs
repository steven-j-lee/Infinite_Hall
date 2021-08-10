using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class TPplayer : MonoBehaviour
{
    [SerializeField] private GameObject inside;
    [SerializeField] private GameObject outside;
    [SerializeField] private GameObject player;

    public bool isEnabledIn;
    public bool isEnabledOut;
    [SerializeReference] private float distance;
    private Vector3 frontDist;

    private void Start()
    {
        isEnabledIn = false;
        isEnabledOut = false;
        frontDist = new Vector3(inside.transform.position.x, 
            inside.transform.position.y,
            inside.transform.position.z);
    }

    private void Update()
    {
        distance = Vector3.Distance(frontDist, new Vector3(player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z));
        Math.Abs(distance);
        if (Input.GetKeyUp(KeyCode.E) && isEnabledOut && distance <= 7f )
        {
            Debug.Log("o");
            player.transform.position = inside.transform.position;
            isEnabledOut = false;
        }
        else if (Input.GetKeyUp(KeyCode.E) && isEnabledIn && distance <= 7f)
        {
            Debug.Log("u");
            player.transform.position = outside.transform.position;
            isEnabledIn = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag.Equals("out") && other.CompareTag("Player"))
        {
            Debug.Log("out");
            isEnabledOut = true;
        }
        else if (gameObject.tag.Equals("in") && other.CompareTag("Player"))
        {
            Debug.Log("in");
            isEnabledIn = true;
        }
        else
        {
            isEnabledIn = false; 
            isEnabledOut = false;
        }
    }
}
