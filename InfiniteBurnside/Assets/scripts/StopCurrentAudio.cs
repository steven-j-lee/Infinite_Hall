using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCurrentAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].clip = null;
            }
        }
    }
}
