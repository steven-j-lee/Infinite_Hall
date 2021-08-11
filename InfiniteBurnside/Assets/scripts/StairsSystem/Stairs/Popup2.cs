using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Popup2 : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    [SerializeField] private GameObject stairsNumber;

    [SerializeField] private GameObject lerpTarget;
    
    public int stairNum;
    public int randomNum;
    private bool hasPlayed;
    private bool isGoing;
    void Start()
    {
        isGoing = false;
        randomNum = Random.Range(1, 10);
        hasPlayed = false;
        int number;
        int.TryParse(stairsNumber.GetComponent<TextMeshPro>().text.ToString(), out number);
        stairNum = number;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && stairNum == randomNum)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerStatsInit>().playerData.health -= 300;
            PlaySound();
            isGoing = true;
        }
    }

    private void MoveToTarget()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,
            lerpTarget.transform.position, Time.deltaTime*1.5f);
        StartCoroutine(Delay());
    }
    private void PlaySound()
    {
        if (!hasPlayed)
        {
            source.PlayOneShot(clip, 2f);
            hasPlayed = true;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        isGoing = false;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isGoing)
        {
            MoveToTarget();
        }
    }
    
}
