using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStairsTrigger : MonoBehaviour
{

    //tells the stairs to create another staircase
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ProceduralStairs.OnTriggerNewStairs?.Invoke();
            Destroy(gameObject);
        }
    }
}
