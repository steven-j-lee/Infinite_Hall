using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI dialogueText;
    public bool isGoing;
    [SerializeField] private GameObject dialogueBox;
    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        npcName.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentenes)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Debug.Log("End");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            NextSentence();
        }
    }
}
