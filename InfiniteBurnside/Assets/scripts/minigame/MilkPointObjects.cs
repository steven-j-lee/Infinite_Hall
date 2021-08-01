using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MilkPointObjects : MonoBehaviour
{
    public float speed;
    public float offset;
    [SerializeReference] private bool isColliding;
    private GameObject player;
    void Start()
    {
        isColliding = false;
    }


    void FixedUpdate()
    {
        if (isColliding)
        {
            player = GameObject.FindWithTag("playerShip");
            int replaceScore = player.GetComponent<ShipMovement>().score;
            player.GetComponent<ShipMovement>().score += 50;
            
            Destroy(gameObject);
        }
        gameObject.transform.position -= new Vector3(0, 0, speed * offset);
        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerShip"))
        {
            isColliding = true;
        }
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
