using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Disappear : MonoBehaviour
{

    [SerializeField] private GameObject soundTriggerToDelete;
    [SerializeField] private GameObject demon;
    [SerializeField] private GameObject light;
    private AudioSource piano;
    [SerializeField] private AudioClip audioFile;


    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        piano = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlaySound();
            StartCoroutine(Delay());
        }
    }

    private void PlaySound()
    {
        if (!hasPlayed)
        {
            piano.PlayOneShot(audioFile, 2f);
            hasPlayed = true;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(soundTriggerToDelete);
        Destroy(light);
        Destroy(demon);
        //Destroy(this.gameObject);
    }
}
