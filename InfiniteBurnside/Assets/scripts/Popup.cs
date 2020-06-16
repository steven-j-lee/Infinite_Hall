using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private GameObject jumpscare;
    [SerializeField] private AudioClip scareSound;
    [SerializeField] private GameObject player;
    private AudioSource sound;


    private bool hasTriggered = false;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        jumpscare.GetComponent<SpriteRenderer>().enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        jumpscare.GetComponent<SpriteRenderer>().enabled = true;
        PlaySound();
        StartCoroutine(Delay());
    }

    private void PlaySound()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            sound.PlayOneShot(scareSound, 5f);
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(jumpscare);
    }

}
