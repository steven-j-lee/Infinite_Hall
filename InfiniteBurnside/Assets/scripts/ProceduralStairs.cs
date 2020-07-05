using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProceduralStairs : MonoBehaviour
{
    [SerializeField] private GameObject stairsPrefab;
    [SerializeField] private GameObject lastStairs;

    private int stairsNum = 1;

    public static System.Action OnTriggerNewStairs;

    void Start()
    {
        OnTriggerNewStairs += CreateNewStairs;
    }

    private void CreateNewStairs()
    {
            float yRot = lastStairs.transform.rotation.eulerAngles.y > 10 ? 0 : 180;
            Quaternion rot = Quaternion.Euler(new Vector3(0, yRot, 0));
            Vector3 pos = lastStairs.transform.position;
            //pos.y -= 1.3f;
            pos.y -= 9.4f;
            //pos.z = pos.z > 1 ? 0 : 7.3f;
            pos.z = pos.z > 1 ? 0 : 0.2f;
        
            if(stairsNum % 2 != 0)
            {
                pos.x = pos.x > 1 ? 0 : 6.43f;
            }
            else if(stairsNum % 2 == 0)
            {
                pos.x = pos.x > 1 ? 0 : 0.43f;
            }
   
            GameObject newStairs = Instantiate(stairsPrefab, pos, rot);
            SetUpNewStairs(newStairs);
            lastStairs = newStairs;
       
    }

    private void SetUpNewStairs(GameObject newStairs)
    {
        stairsNum++;
        newStairs.GetComponentInChildren<TextMeshPro>().text = (stairsNum).ToString();
    }
}
