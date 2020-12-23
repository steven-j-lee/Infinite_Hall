using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    [SerializeField] private GameObject textToBeShown;

   
    // Start is called before the first frame update
    void Start()
    {
        //set text to be set at the middle of the screen
        textToBeShown.GetComponent<RectTransform>().position = new Vector3(Screen.width / 2, (Screen.height / 4), 0 );
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("is colliding with player");
            textToBeShown.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textToBeShown.SetActive(false);
    } 
}
