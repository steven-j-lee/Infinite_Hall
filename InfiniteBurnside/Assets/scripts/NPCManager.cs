using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> npcList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var npc in npcList)
        {
            Vector3 newPos = new Vector3(player.transform.position.x
                , npc.transform.position.y, player.transform.position.z);
            npc.transform.LookAt(newPos);
        }
    }
}
