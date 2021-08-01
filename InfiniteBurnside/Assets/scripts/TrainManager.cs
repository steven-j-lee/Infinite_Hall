using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    [SerializeField] private GameObject rightTrain;
    [SerializeField] private GameObject exitPosRight;
    [SerializeField] private GameObject originalPosRight;
    [SerializeField] private GameObject stationPos;

    [SerializeField] private AudioClip trainMoveSound;
    
    public float moveSpeed;
    public bool canBoard;

    private float startTime;
    private float toStationDist;
    private float toExitDist;
    private AudioSource audioSource;
    void Awake()
    {
        startTime = Time.time;
        toStationDist = Vector3.Distance(originalPosRight.transform.position, stationPos.transform.position);
        toExitDist = Vector3.Distance(stationPos.transform.position, exitPosRight.transform.position);
        canBoard = false;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(TrainScheduler(10f));

    }

    private void PlayMSound()
    {
        audioSource.PlayOneShot(trainMoveSound, 1f);
    }

    private IEnumerator TrainScheduler(float seconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            PlayMSound();
            yield return StopTrain(60f);
            PlayMSound();
            yield return ExitStation(30f);
            yield return new WaitForSeconds(seconds);
        }
    }

    private IEnumerator StopTrain(float seconds)
    {
        float t = 0f;
        Debug.Log("moving to station");
        while (t < moveSpeed)
        {
            t += Time.deltaTime;
            rightTrain.transform.position = Vector3.Lerp(originalPosRight.transform.position,
                stationPos.transform.position,  Mathf.SmoothStep(0f, 1f, t/moveSpeed));
            yield return null;
        }
        canBoard = true;
        yield return new WaitForSeconds(seconds);
    }

    private IEnumerator ExitStation(float seconds)
    {
        float t = 0f;
        canBoard = false;
        Debug.Log("leaving station");
        while (t < moveSpeed)
        {
            t += Time.deltaTime;
            rightTrain.transform.position = Vector3.Lerp(stationPos.transform.position,
                exitPosRight.transform.position, Mathf.SmoothStep(0f, 1f, t/moveSpeed));
            yield return null;
        }
        yield return new WaitForSeconds(seconds);
    }

}
