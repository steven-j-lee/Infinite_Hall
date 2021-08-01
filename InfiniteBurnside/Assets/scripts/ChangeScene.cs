using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int level;

    public bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding && Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene(level);
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Colliding with changer");
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
}
