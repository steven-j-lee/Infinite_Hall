using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    private bool isChasing = false;
    [SerializeField] GameObject monster;
    [SerializeField] AudioClip scream;

    private AudioSource sound;
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
            monster.transform.position -= transform.right * 8f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isChasing = true;
        sound.PlayOneShot(scream, 8f);
    }
}
