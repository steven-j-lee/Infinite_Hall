using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    private bool isChasing = false;
    [SerializeField] GameObject monster;
    [SerializeField] AudioClip scream;

    private AudioSource sound;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        sound = monster.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            monster.transform.position += transform.right * 10f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasPlayed)
            {
                sound.PlayOneShot(scream, 1f);
                hasPlayed = true;
            }
            isChasing = true;
        }
    }
}
