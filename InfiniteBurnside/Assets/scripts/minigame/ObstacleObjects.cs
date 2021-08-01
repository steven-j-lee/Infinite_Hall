using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjects : MonoBehaviour
{
    public float speed;
    public float offset;
    public bool isGameOver;
    [SerializeReference] private bool isColliding;
    private GameObject player;

    [SerializeField] private GameObject minigameField;

    void Start()
    {
        isGameOver = false;
        isColliding = false;
        
    }
    void FixedUpdate()
    {
        if (isColliding)
        {
            isGameOver = true;
            Destroy(gameObject);
        }
        gameObject.transform.position -= new Vector3(0, 0, speed  * offset);
        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("playerShip"))
        {
            isColliding = true;
            player = GameObject.FindWithTag("playerShip");
            player.GetComponent<ShipMovement>().lives -= 1;
        }
    }
    
    
    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
