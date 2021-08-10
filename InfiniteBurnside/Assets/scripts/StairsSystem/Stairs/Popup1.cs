using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Popup1 : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    [SerializeField] private GameObject stairsNumber;

    public int stairNum;
    public int randomNum;
    private bool hasPlayed;
    
    void Start()
    {
        randomNum = Random.Range(1, 10);
        hasPlayed = false;
        int number;
        int.TryParse(stairsNumber.GetComponent<TextMeshPro>().text.ToString(), out number);
        stairNum = number;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && randomNum == stairNum)
        {
            PlaySound();
            StartCoroutine(Delay());
        }
    }
    
    private void PlaySound()
    {
        if (!hasPlayed)
        {
            gameObject.SetActive(true);
            source.PlayOneShot(clip, 2f);
            hasPlayed = true;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
