using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableLastSceneLobby : MonoBehaviour
{
    public bool isStolen;
    [SerializeField] private GameObject[] eventsToSetActive;
    [SerializeField] private TextMeshProUGUI message;
    private void Awake()
    {
        isStolen = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStolen)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            message.enabled = true;
            for (int i = 0; i < eventsToSetActive.Length; i++)
            {
                eventsToSetActive[i].SetActive(true);
            }
        }
    }

    private IEnumerator delayMsg()
    {
        yield return new WaitForSeconds(3f);
        message.enabled = false;
        yield return null;
    }
}
