using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEvent : MonoBehaviour
{
    [SerializeField] private List<GameObject> quests;
    [SerializeField] private GameObject worm;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lightParent;

    [SerializeReference] private Component[] lightsList;
    private bool poHasPlayed;
    public bool isChase;
    [SerializeField] private AudioClip downSound;

    [SerializeField] private GameObject npcManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip amb2;
    [SerializeField] private GameObject exit;
    

    private void Start()
    {
        poHasPlayed = false;
        lightsList = lightParent.GetComponentsInChildren<Light>();
    }

    void Update()
    {


        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
                   if (!ClearEvent(quests))
                   {
                       
                   }
                   else if (ClearEvent(quests))
                   { 
                       npcManager.SetActive(false);
                      ChangeLightColors();
                      playSound(downSound);
                      player.GetComponent<Movement>().enabled = false;
                      audioSource.clip = amb2;
                      audioSource.Play();
                      player.GetComponent<Movement>().enabled = true;
                      isChase = true;
                      exit.SetActive(true);
                      worm.SetActive(true);
                   }
        }
    }

    private bool ClearEvent(List<GameObject> quests)
    {
        foreach (var VARIABLE in quests)
        {
            if (VARIABLE.TryGetComponent(out CoffeeInteract ci))
            {
                if (!ci.signal)
                {
                    return false;
                }
            }
            else if (VARIABLE.TryGetComponent(out EventManager em))
            {
                if (!em.milkQuestIsComplete)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void ChangeLightColors()
    {
        foreach (Light light in lightsList)
        {
            light.color = Color.red;
        }
    }

    private void playSound(AudioClip clip)
    {
        if (!poHasPlayed)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip, 5f);
            poHasPlayed = true;
        }
    }

    private IEnumerator Sleep(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    
}
