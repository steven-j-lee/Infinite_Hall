using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject closedDoor;

    public bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyUp(KeyCode.E) && closedDoor.activeSelf)
            {
                isTriggered = false;
                openDoor.SetActive(true);
                closedDoor.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.E) && openDoor.activeSelf)
            {
                isTriggered = false;
                openDoor.SetActive(false);
                closedDoor.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isTriggered = true;
        }
    }
}
