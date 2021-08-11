using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropDemon : MonoBehaviour
{
    public float speed;
    public bool isSeen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject player;

    private Vector3 targetLocation;
    private bool hasPlayed;
    private void Awake()
    {
        hasPlayed = false;
        isSeen = false;
        targetLocation = target.transform.position;
    }
    void Update()
    {
        if (isSeen)
        {
            StartCoroutine(Routine());
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator Routine()
    {
        playTrack(audioClip, 3f);
        player.GetComponentInChildren<CameraController>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        Drop();
        yield return Sleep(2f);
        yield return null;
    }

    private void Drop()
    {
        Vector3 startPos = gameObject.transform.position;
        float t = 0f;
        while (t < speed)
        {
            gameObject.transform.position = Vector3.Lerp(startPos, targetLocation,
                t/speed);
            t += Time.deltaTime;
        }

        isSeen = true;
    }

    private void playTrack(AudioClip audioClip, float volume)
    {
        if (!hasPlayed)
        {
            audioSource.PlayOneShot(audioClip, volume);
            audioSource.loop = false;
            hasPlayed = true;
        }
    }

    private IEnumerator Sleep(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    
}
