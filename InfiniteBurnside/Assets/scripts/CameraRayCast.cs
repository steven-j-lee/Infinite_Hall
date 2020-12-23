using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    [SerializeField] private int rayCastLenght = 50;
    [SerializeField] private LayerMask interactableLayer;
    private GameObject raycastedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit collision;
        Vector3 line = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position,
            line,
            out collision,
            rayCastLenght,
            interactableLayer.value))
        {
            if (collision.collider.CompareTag("monster"))
            {
                
            }
        }
    }
}
