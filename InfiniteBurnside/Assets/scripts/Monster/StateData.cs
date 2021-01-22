using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateData : MonoBehaviour
{
    public static StateData Instance
    {
        get;
        private set;

    }

    [SerializeField] private float tempMonsterSpeed = 2.5f;
    [SerializeField] private float tempEnemySight = 5f;
    [SerializeField] private float tempRange = 1f;
    
    public static float monsterSpeed => Instance.tempMonsterSpeed;
    public static float enemySight => Instance.tempEnemySight;
    public static float range => Instance.tempRange;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
