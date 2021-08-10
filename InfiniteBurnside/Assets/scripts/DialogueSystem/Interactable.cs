using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private DialogueManager dialogueManager;
    

    public void ExecuteDialogue()
    {
       dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("NPC on player");
            ExecuteDialogue();
            if (gameObject.tag.Equals("d_to_disappear"))
            {
                StartCoroutine(Sleep(2f));
                gameObject.SetActive(false);
            }
        } 
    }

    private IEnumerator Sleep(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
