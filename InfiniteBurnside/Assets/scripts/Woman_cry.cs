using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman_cry : MonoBehaviour
{
    [SerializeField] private AudioClip audioFile;
    [SerializeField] private GameObject temp;
    [SerializeField] private ProceduralStairs procedural;
    private AudioSource source;
    private bool hasPlayed = false;
   
    // Start is called before the first frame update
    void Start()
    {
        source = temp.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !hasPlayed && procedural.StairsNum == 2)
        {
            source.PlayOneShot(audioFile, 1f);
            hasPlayed = true;
        }
    }
}
