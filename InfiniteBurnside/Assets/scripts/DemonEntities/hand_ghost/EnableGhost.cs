using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGhost : MonoBehaviour
{
    [SerializeField] private GameObject[] ghost;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            for (int i = 0; i < ghost.Length; i++)
            {
                ghost[i].SetActive(true);
            }
        }
    }
}
