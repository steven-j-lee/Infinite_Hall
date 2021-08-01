using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySpawner : MonoBehaviour
{
    [SerializeField] private CartonFactory milkSpawner;
    [SerializeField] private ObstacleFactory obstacleSpawner;

    public float rate;
    public int counter;
    private int guesser;
    
    void Update()
    {
        float target = Time.time * (rate / 60f);
        while (target > counter)
        {
            guesser = (int) Random.Range(0, 60);
            if (guesser % 2 == 0)
            {
                var cFactInst = milkSpawner.GetNewInstance();
                cFactInst.transform.position = new Vector3(-2.34f,
                    Random.Range(45.38f, 55.1f),
                    117.12f);
                counter++;
            }
            else
            {
                var obsInst = obstacleSpawner.GetNewInstance();
                obsInst.transform.position = new Vector3(-2.57f,
                    Random.Range(55.16f, 65.69f),
                    110.62f);
                counter++;
            }
        }
    }
}
