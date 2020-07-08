using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsRandomSound : MonoBehaviour
{
    //random noise audio
    [SerializeField] private AudioClip[] randomSounds;
    private AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Creates random sound
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Delay());
            
        }
    }


    //play random sound
    private AudioClip ReturnSound(AudioClip[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    private void PlayRandomSound()
    {
        AudioClip temp = ReturnSound(randomSounds);
        source.PlayOneShot(temp, 1f);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
