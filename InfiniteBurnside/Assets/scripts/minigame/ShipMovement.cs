using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;
    public int score;
    public int lives;

    private void Start()
    {
        lives = 3;
    }


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(0, inputY * speed, inputX * speed);
        

            playerMovement *= Time.deltaTime;
            gameObject.transform.Translate(playerMovement);
    }
    

}
