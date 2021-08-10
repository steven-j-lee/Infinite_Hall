using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveWorm : MonoBehaviour
{
    [SerializeField] private WormEvent wormEvent;
    [SerializeField] private GameObject targetLocation;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cutsceneCam;

    public float speed;
    public float seconds;
    private Vector3 startPos;
    [SerializeReference] private bool isDone;
    private void Awake()
    {
        isDone = false;
        startPos = gameObject.transform.position;
    }

    void Start()
    {
        if (wormEvent.isChase)
        {
            Debug.Log("monster on player");
            StartCoroutine(Cutscene(seconds));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StopAllCoroutines();
            SceneManager.LoadScene(0);
        }
    }


    private IEnumerator Cutscene(float seconds)
    {
        player.SetActive(false);
            cutsceneCam.SetActive(true);
            yield return Sleep(2f);
            cutsceneCam.SetActive(false);
            player.SetActive(true);
            yield return Sleep(2f);
            yield return EnableWormChase();
            yield return new WaitForSeconds(seconds);
        
    }

    private IEnumerator EnableWormChase()
    {
        float t = 0f;
        while (t < speed)
        {
            gameObject.transform.position = Vector3.Lerp(startPos, targetLocation.transform.position,
                t/speed);
            t += Time.deltaTime;
            yield return null;
        }
        isDone = true;
        yield return null;
    }

    private IEnumerator Sleep(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
