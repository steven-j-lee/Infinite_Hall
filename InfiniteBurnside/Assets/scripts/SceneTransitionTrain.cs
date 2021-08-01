using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionTrain : MonoBehaviour
{
    [SerializeField] private TrainManager trainManager;
    [SerializeField] private GameObject trainEntranceSign;


    void Update()
    {
        if (trainManager.canBoard)
        {
            trainEntranceSign.SetActive(true);
        }
        else
        {
            trainEntranceSign.SetActive(false);
        }
        
    }
}
