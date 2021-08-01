using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class ProceduralStairs : MonoBehaviour
{
    [SerializeField] private GameObject stairsPrefab;
    [SerializeField] private GameObject lastStairs;
    public GameObject[] list = new GameObject[1];

    public static System.Action OnTriggerNewStairs;

    public int StairsNum { get; private set; }

    private void Awake()
    {
        this.StairsNum = 0;
    }

    private void Update()
    {
        if (this.StairsNum == 15)
        {
            Application.Quit();
        }
    }

    void Start()
    {
        OnTriggerNewStairs += CreateNewStairs;
    }

    private void CreateNewStairs()
    {
        float yRot = lastStairs.transform.rotation.eulerAngles.y > 10 ? 0 : 180;
        Quaternion rot = Quaternion.Euler(new Vector3(0, yRot, 0));
        Vector3 pos = lastStairs.transform.position;
        pos.y -= 11.52f;
        pos.z = pos.z > 1 ? 0 : 13.52f;

        if (this.StairsNum % 2 == 0)
        {
            pos.x = pos.x > 1 ? 0 : 13.84f;
        }
        else
        {
            pos.x = pos.x > 1 ? 0 : 0.43f;
        }

        GameObject newStairs = Instantiate(stairsPrefab, pos, rot);
        SetUpNewStairs(newStairs);
        lastStairs = newStairs;
    }

    private void SetUpNewStairs(GameObject newStairs)
    {
        this.StairsNum++;
        newStairs.GetComponentInChildren<TextMeshPro>().text = (this.StairsNum).ToString();
    }
}
