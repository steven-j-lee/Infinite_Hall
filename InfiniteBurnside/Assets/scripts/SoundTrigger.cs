using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip audioFile;
    private AudioSource sound;
    [SerializeField] float volume = 0f;
    private bool hasPlayed = false;

    //lights
    [SerializeField] GameObject lights = null;


    //audio to be muted
    [SerializeField] private AudioClip audioFileToMute;
    [SerializeField] private GameObject bgmMute;
    private AudioSource soundToMute;


    // Start is called before the first frame update
    void Start()
    {
        //get audio clip from entity
        sound = GetComponent<AudioSource>();
        soundToMute = bgmMute.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            soundToMute.mute = true;
            //sound.PlayOneShot(audioFile, volume);
            hasPlayed = true;
            Destroy(lights);
        }

    }

}
