using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseManager : MonoBehaviour
{
    [SerializeField] private GameObject[] roses;
    [SerializeField] private GameObject finalRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allGathered())
        {
            finalRoom.SetActive(true);
        }

    }

    private bool allGathered()
    {
        for (int i = 0; i < roses.Length; i++)
        {
            if (!roses[i].GetComponent<InitRose>().taken)
            {
                return false;
            }
        }
        return true;
    }
}
