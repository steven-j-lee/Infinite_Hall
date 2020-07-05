using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerButNotMute : MonoBehaviour
{
    [SerializeField] GameObject source;
    [SerializeField] ulong volume = 1;
    private AudioSource sourceAudio;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        sourceAudio = source.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!hasPlayed && other.tag == "Player")
        {
            sourceAudio.enabled = true;
            hasPlayed = true;
        }
    }
}
