using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMap : MonoBehaviour
{
    [SerializeField] private GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M) && map.activeSelf == false)
        {
            map.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.M) && map.activeSelf)
        {
            map.SetActive(false);
        }
    }
}
