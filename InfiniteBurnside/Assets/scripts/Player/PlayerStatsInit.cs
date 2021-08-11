using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsInit : MonoBehaviour
{
    public Player_Data playerData;
    public string name;
    //green, yellow, red
    [SerializeField] Sprite[] sanityLevels;
    [SerializeField] TextMeshProUGUI outputName;
    [SerializeField] private Image uiBar;

    private void Awake()
    {
        playerData.health = 3000;
    }

    void Start()
    {
        outputName.text = playerData.name;
    }
    
    void Update()
    {
        if (playerData.health >= 600)
        {
            uiBar.sprite = sanityLevels[0];
        }
        else if (playerData.health >= 200 && playerData.health <= 599)
        {
            uiBar.sprite = sanityLevels[1];
        }
        else if(playerData.health <= 199)
        {
            uiBar.sprite = sanityLevels[2];
        }

        if (playerData.health == 0)
        {
            SceneManager.LoadScene(7);
        }
    }
}
