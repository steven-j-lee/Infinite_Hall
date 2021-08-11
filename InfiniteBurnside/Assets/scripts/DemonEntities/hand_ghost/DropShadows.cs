using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropShadows : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject targetLocation;
    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    void Start()
    {
        StartCoroutine(EnableDrop());
    }
    
    
    private IEnumerator EnableDrop()
    {
        float t = 0f;
        while (t < speed)
        {
            gameObject.transform.position = Vector3.Lerp(startPos, targetLocation.transform.position,
                t/speed);
            t += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(7);
    }
}
