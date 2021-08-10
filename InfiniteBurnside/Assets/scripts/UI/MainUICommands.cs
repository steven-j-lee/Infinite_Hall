using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainUICommands : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonList;
    [SerializeField] private GameObject creditScene;

    [SerializeReference]
    private bool isCredit;

    private void Awake()
    {
        isCredit = false;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isCredit)
        {
            foreach (var button in buttonList)
            {
                button.SetActive(true);
            }
            creditScene.SetActive(false);
            isCredit = false;
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(6);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void ShowCredits()
    {
        foreach (var button in buttonList)
        {
            button.SetActive(false);
        }
        creditScene.SetActive(true);
        isCredit = true;
    }
    
}
